using System.Drawing.Imaging;
using App.Objects;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
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

        public void PerformImageTransformations(Transformer transformer)
        {
            if (!Directory.Exists(transformer.FolderPath!))
            {
                Console.WriteLine($"Folder path does not exist.");
                return;
            }

            // Get all the images to transform, order by name for logging purposes, ToList to avoid any possible lazy loading
            List<string> files = Directory.GetFiles(transformer.FolderPath!).ToList();
            _numOfFiles = files.Count();
            if (_numOfFiles == 0)
            {
                Console.WriteLine($"Folder path is empty.");
                return;
            }

            // Figure out how many operations will take place
            if (transformer.ImageOperations!.FlipModes!.Count() > 0)
                _numOfOperations = _numOfOperations + transformer.ImageOperations!.FlipModes!.Where(x => x != FlipMode.None).Count();
            if (transformer.ImageOperations!.RotateModes!.Count() > 0)
                _numOfOperations = _numOfOperations + transformer.ImageOperations!.RotateModes!.Where(x => x != RotateMode.None).Count();

            // Used for logging/display
            _totalNumOfFilesToProcess = _numOfFiles * _numOfOperations;

            Console.WriteLine($"Number of files to convert: {_numOfFiles}, with {_numOfOperations} of operations to complete.");
            Console.WriteLine($"Starting conversion on {_totalNumOfFilesToProcess} number of files...");

            // Parallelize the processing of each file for speed
            Parallel.ForEach(files, file =>
            {
                try
                {
                    // Get the FileInfo object to get to the name of the file
                    FileInfo fi = new FileInfo(file);
                    var filename = fi.Name;

                    // Convert the image to bytes to avoid any file locks while processsing the same image 3 times
                    byte[] imageArray = File.ReadAllBytes($"{transformer.FolderPath}/{filename}");

                    // For each FlipMode create one
                    Parallel.ForEach(transformer.ImageOperations!.FlipModes!, flipMode =>
                    {
                        Parallel.ForEach(transformer.ImageOperations!.RotateModes!, rotateMode =>
                        {
                            var f = Enum.GetName(typeof(FlipMode), flipMode);
                            var r = Enum.GetName(typeof(RotateMode), rotateMode);
                            string filename = $"{fi.Name}_{f}_{r}.jpg";

                            var i = Image.Load<Rgba32>(imageArray);
                            i.Mutate(x => x.RotateFlip(rotateMode, flipMode));

                            if (transformer.ImageOperations.Resize)
                            {
                                ResizeOptions opts = new ResizeOptions();
                                opts.Mode = transformer.ImageOperations.ResizeMode;
                                opts.Size = new Size
                                {
                                    Height = transformer.ImageOperations.Dimensions!.Height,
                                    Width = transformer.ImageOperations.Dimensions!.Width
                                };
                                i.Mutate(x => x.Resize(opts));
                            }

                            if (transformer.ImageOperations.Grayscale)
                            {
                                i.Mutate(x => x.Grayscale());
                            }

                            i.Save(filename);

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
        }
    }
}