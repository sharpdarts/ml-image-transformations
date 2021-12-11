using SixLabors.ImageSharp.Processing;

namespace App.Objects
{
    public class ImageOperations
    {
        public List<FlipMode>? FlipModes { get; set; }
        public List<RotateMode>? RotateModes { get; set; }
        public bool Resize { get; set; }
        public ResizeMode ResizeMode { get; set; }
        public Dimensions? ResizeDimensions { get; set; }
        public bool Grayscale { get; set; }
        public bool Crop { get; set; }
        public Dimensions? CropDimensions { get; set; }

        public ImageOperations()
        {
            this.FlipModes = new List<FlipMode>();
            this.RotateModes = new List<RotateMode>();
            this.ResizeDimensions = new Dimensions();
            this.CropDimensions = new Dimensions();
        }
    }
}