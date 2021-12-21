using App.Objects;
using CommandLine;
using SixLabors.ImageSharp.Processing;

namespace App
{
    class Program
    {
        public class Options
        {
            [Option("inputfolder", Default = "", Required = false, HelpText = "Input folder.")]
            public string? OptInputFolder { get; set; }

            [Option("outputfolder", Default = "", Required = false, HelpText = "Output folder.")]
            public string? OptOutputFolder { get; set; }

            [Option("sample", Default = 0, Required = false, HelpText = "Only perform operations on a sample set, used for quick validation.")]
            public int? OptSample { get; set; }

            [Option("flipmodes", Required = true, HelpText = "The flipmodes to be used, options are Horizontal, Vertical, or None.")]
            public IEnumerable<string>? OptFlipModes { get; set; }

            [Option("rotatemodes", Required = true, HelpText = "The rotatemodes to be used, options are Rotate90, Rotate180, Rotate270, or None.")]
            public IEnumerable<string>? OptRotateModes { get; set; }

            [Option("grayscale", Default = false, Required = false, HelpText = "Should all the images be in grayscale.")]
            public bool? OptGrayscale { get; set; }

            [Option("resize", Default = false, Required = false, HelpText = "Should all the images be resized.")]
            public bool? OptResize { get; set; }

            [Option("resizemode", Default = "Stretch", Required = false, HelpText = "Resize mode to use, options are Crop, Pad, BoxPad, Manual, Min, Max, Stretch.")]
            public string? OptResizeMode { get; set; }

            [Option("resizeheight", Default = 0, Required = false, HelpText = "Resize height if resize is true.")]
            public int? OptResizeHeight { get; set; }

            [Option("resizewidth", Default = 0, Required = false, HelpText = "Resize width if resize is true.")]
            public int? OptResizeWidth { get; set; }

            [Option("crop", Default = false, Required = false, HelpText = "Should all the images be cropped.")]
            public bool? OptCrop { get; set; }

            [Option("cropheight", Default = 0, Required = false, HelpText = "Crop height if crop is true.")]
            public int? OptCropHeight { get; set; }

            [Option("cropwidth", Default = 0, Required = false, HelpText = "Crop width if crop is true.")]
            public int? OptCropWidth { get; set; }

            [Option("exportcsv", Default = false, Required = false, HelpText = "Should a CSV of all filenames be generated.")]
            public bool? OptExportCsv { get; set; }
        }

        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       Transformer transformer = new Transformer();

                       transformer.Sample = (int)o.OptSample!;
                       transformer.ExportCsv = (bool)o.OptExportCsv!;

                       foreach (var flip in o.OptFlipModes!)
                           transformer.ImageOperations!.FlipModes!.Add((FlipMode)Enum.Parse(typeof(FlipMode), flip));

                       foreach (var rotate in o.OptRotateModes!)
                           transformer.ImageOperations!.RotateModes!.Add((RotateMode)Enum.Parse(typeof(RotateMode), rotate));

                       transformer.ImageOperations!.Grayscale = (bool)o.OptGrayscale!;

                       transformer.ImageOperations!.Resize = (bool)o.OptResize!;
                       transformer.ImageOperations!.ResizeMode = (ResizeMode)Enum.Parse(typeof(ResizeMode), o.OptResizeMode!);
                       transformer.ImageOperations.ResizeDimensions!.Height = (int)o.OptResizeHeight!;
                       transformer.ImageOperations.ResizeDimensions!.Width = (int)o.OptResizeWidth!;

                       transformer.ImageOperations!.Crop = (bool)o.OptCrop!;
                       transformer.ImageOperations.CropDimensions!.Height = (int)o.OptCropHeight!;
                       transformer.ImageOperations.CropDimensions!.Width = (int)o.OptCropWidth!;

                       transformer.InputFolderPath = (string)o.OptInputFolder!;
                       transformer.OutputFolderPath = (string)o.OptOutputFolder!;

                       new ImageTransformer().PerformImageTransformations(transformer);
                   });
        }
    }
}