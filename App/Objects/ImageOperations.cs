using SixLabors.ImageSharp.Processing;

namespace App.Objects
{
    public class ImageOperations
    {
        public List<FlipMode>? FlipModes { get; set; }
        public List<RotateMode>? RotateModes { get; set; }
        public ResizeMode ResizeMode { get; set; }
        public bool Resize { get; set; }
        public Dimensions? Dimensions { get; set; }
        public bool Grayscale { get; set; }
    }

    public class ImageDetails : ImageOperations
    {
        public byte[]? ImageBytes { get; set; }
        public string? Filename { get; set; }
        public FlipMode FlipMode { get; set; }
        public RotateMode RotateMode { get; set; }
    }
}