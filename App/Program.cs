using App.Objects;
using CommandLine;
using SixLabors.ImageSharp.Processing;

namespace App
{
    class Program
    {
        public class Options
        {
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

            [Option("resizeheight", Default = 224, Required = false, HelpText = "Resize height is resize is true.")]
            public int? OptResizeHeight { get; set; }

            [Option("resizewidth", Default = 224, Required = false, HelpText = "Resize width is resize is true.")]
            public int? OptResizeWidth { get; set; }
        }

        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       Transformer transformer = new Transformer();

                       foreach (var flip in o.OptFlipModes!)
                           transformer.ImageOperations!.FlipModes!.Add((FlipMode)Enum.Parse(typeof(FlipMode), flip));

                       foreach (var rotate in o.OptRotateModes!)
                           transformer.ImageOperations!.RotateModes!.Add((RotateMode)Enum.Parse(typeof(RotateMode), rotate));

                       transformer.ImageOperations!.Grayscale = (bool)o.OptGrayscale!;
                       transformer.ImageOperations!.ResizeMode = (ResizeMode)Enum.Parse(typeof(ResizeMode), o.OptResizeMode!);
                       transformer.ImageOperations.ResizeDimensions!.Height = (int)o.OptResizeHeight!;
                       transformer.ImageOperations.ResizeDimensions!.Width = (int)o.OptResizeWidth!;
                       transformer.Sample = (int)o.OptSample!;

                       //new ImageTransformer().PerformImageTransformations(transformer);
                   });
        }
    }
}