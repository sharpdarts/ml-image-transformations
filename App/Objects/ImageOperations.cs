using SixLabors.ImageSharp.Processing;

namespace App.Objects
{
    public class ImageOperations
    {
        public List<FlipMode>? FlipModes { get; set; }
        public List<RotateMode>? RotateModes { get; set; }
        public bool Resize { get; set; }
        public ResizeMode ResizeMode { get; set; }
        public ResizeDimensions? ResizeDimensions { get; set; }
        public bool Grayscale { get; set; }

        public ImageOperations()
        {
            this.FlipModes = new List<FlipMode>();
            this.RotateModes = new List<RotateMode>();
            this.ResizeDimensions = new ResizeDimensions();
        }
    }
}