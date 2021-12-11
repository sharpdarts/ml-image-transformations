using System.Collections.Generic;
using System.IO;
using App;
using App.Objects;
using SixLabors.ImageSharp.Processing;
using Xunit;

namespace Tests;

public class TestCropImages
{
    [Fact]
    public void TestResizeImages()
    {
        string outputFolder = "../../../../Tests/testruns/resized_stretch_images";
        if (Directory.Exists(outputFolder))
            Directory.Delete(outputFolder, true);

        var t = new Transformer();
        t.InputFolderPath = "../../../../Tests/images";
        t.OutputFolderPath = outputFolder;
        t.ImageOperations.FlipModes.Add(FlipMode.Vertical);
        t.ImageOperations.FlipModes.Add(FlipMode.None);
        t.ImageOperations.RotateModes.Add(RotateMode.Rotate90);
        t.ImageOperations.RotateModes.Add(RotateMode.None);
        t.ImageOperations.Resize = true;
        t.ImageOperations.ResizeMode = ResizeMode.Stretch;
        t.ImageOperations.ResizeDimensions.Height = 224;
        t.ImageOperations.ResizeDimensions.Width = 224;
        t.ImageOperations.Grayscale = true;
        t.EncodeType = EncodeType.PNG;
        t.Sample = 4;

        new ImageTransformer().PerformImageTransformations(t);
    }
}