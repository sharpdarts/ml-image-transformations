using System.Diagnostics;
using System.Globalization;
using App.Objects;
using CsvHelper;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace App
{
    public class ImageTransformer
    {
        private int _numOfFiles = 0;
        private int _numOfOperations = 0;
        private int _totalNumOfFilesToProcess = 0;
        private int _totalNumOfProcessedFiles = 0;
        private List<Csv> _filesConverted = new List<Csv>();

        public void PerformImageTransformations(Transformer transformer)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            if (!Directory.Exists(transformer.InputFolderPath!))
            {
                Console.WriteLine($"Input folder path does not exist.");
                return;
            }

            if (!Directory.Exists(transformer.OutputFolderPath!))
            {
                Console.WriteLine($"Output folder path does not exist, creating directory.");
                Directory.CreateDirectory(transformer.OutputFolderPath!);
            }

            // Get all the images to transform, order by name for logging purposes, ToList to avoid any possible lazy loading
            List<string> files = Directory.EnumerateFiles(transformer.InputFolderPath!)
                .Where(file => file.ToLower().EndsWith("png")
                    || file.ToLower().EndsWith("jpg")
                    || file.ToLower().EndsWith("jpeg")
                    || file.ToLower().EndsWith("tga")
                    || file.ToLower().EndsWith("bmp"))
                .ToList();

            if (files.Count() == 0)
            {
                Console.WriteLine($"Folder path is empty.");
                return;
            }

            // If user has requested a sample, just take that
            if (transformer.Sample > 0)
            {
                files = files.Take((int)transformer.Sample).ToList();
            }

            _numOfFiles = files.Count();

            // Figure out how many operations will take place
            var numOfFlips = transformer.ImageOperations!.FlipModes!.Count();
            var numOfRotates = transformer.ImageOperations!.RotateModes!.Count();

            // Calculate the total number of operations
            _numOfOperations += numOfFlips * numOfRotates;

            // Used for logging/display
            _totalNumOfFilesToProcess = _numOfFiles * _numOfOperations;

            Console.WriteLine($"Number of files to transform: {_numOfFiles}, with {_numOfOperations} of operations to complete.");
            Console.WriteLine($"Starting transformations...");

            // Parallelize the processing of each file for speed
            Parallel.ForEach(files, file =>
            {
                try
                {
                    // Get the FileInfo object to get to the name of the file
                    FileInfo fi = new FileInfo(file);
                    var filename = fi.Name;

                    // Convert the image to bytes to avoid any file locks while processsing the same image 3 times
                    byte[] imageArray = File.ReadAllBytes($"{transformer.InputFolderPath}/{filename}");

                    Parallel.ForEach(transformer.ImageOperations!.FlipModes!, flipMode =>
                    {
                        Parallel.ForEach(transformer.ImageOperations!.RotateModes!, rotateMode =>
                        {
                            // Create the final file name that includes all the operations that took place
                            var f = Enum.GetName(typeof(FlipMode), flipMode);
                            var r = Enum.GetName(typeof(RotateMode), rotateMode);
                            var e = Enum.GetName(typeof(EncodeType), transformer.EncodeType!);
                            string filename = $"{fi.Name.Split('.')[0]}_{f}_{r}.{e!.ToLower()}";

                            // Load the image and perform the flip/rotate
                            var i = Image.Load<Rgba32>(imageArray);
                            i.Mutate(x => x.RotateFlip(rotateMode, flipMode));

                            // Crop operations must take place before any resize operations
                            if (transformer.ImageOperations.Crop)
                            {
                                var cropRectangle = new Rectangle((i.Width - transformer.ImageOperations!.CropDimensions!.Width) / 2,
                                    (i.Height - transformer.ImageOperations!.CropDimensions!.Height) / 2,
                                    transformer.ImageOperations!.CropDimensions!.Width,
                                    transformer.ImageOperations!.CropDimensions!.Height);

                                i.Mutate(x => x.Crop(cropRectangle));
                            }

                            // Perfrom any resize operations
                            if (transformer.ImageOperations.Resize)
                            {
                                ResizeOptions opts = new ResizeOptions();
                                opts.Mode = transformer.ImageOperations.ResizeMode;
                                opts.Size = new Size
                                {
                                    Height = transformer.ImageOperations.ResizeDimensions!.Height,
                                    Width = transformer.ImageOperations.ResizeDimensions!.Width
                                };
                                i.Mutate(x => x.Resize(opts));
                            }

                            // Convert to grayscale if requested
                            if (transformer.ImageOperations.Grayscale)
                            {
                                i.Mutate(x => x.Grayscale());
                            }

                            // Save the file using the final file name
                            i.Save($"{transformer.OutputFolderPath!}/{filename}");

                            _filesConverted.Add(new Csv { Filename = filename });
                            _totalNumOfProcessedFiles++;
                            Console.WriteLine($"Finished {filename} - {_totalNumOfProcessedFiles} of {_totalNumOfFilesToProcess} files...");
                        });
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"EXCEPTION: {ex.Message} : {ex.StackTrace}");
                }
            });

            Console.WriteLine($"Image conversion was successful: {_totalNumOfFilesToProcess == _totalNumOfProcessedFiles}");
            Console.WriteLine($"Number of files: {_totalNumOfFilesToProcess}, Number of conversions: {_totalNumOfProcessedFiles}");

            // Try to save the CSV export if requested
            if ((bool)transformer.ExportCsv!)
            {
                try
                {
                    Console.WriteLine($"Generating CSV file...");
                    using (var writer = new StreamWriter($"{transformer.OutputFolderPath!}/transformations.csv"))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(_filesConverted);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Encountered an error while trying to save the CSV file: {ex.Message}");
                }
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
}