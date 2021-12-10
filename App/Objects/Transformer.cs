namespace App.Objects
{
    public class Transformer
    {
        public string? InputFolderPath { get; set; }
        public string? OutputFolderPath { get; set; }
        public EncodeType EncodeType { get; set; }
        public ImageOperations? ImageOperations { get; set; }
    }
}