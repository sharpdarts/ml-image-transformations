using System.IO;
using System.Linq;
using App;
using App.Objects;
using SixLabors.ImageSharp.Processing;
using Xunit;
using CsvHelper;
using System.Globalization;
using System.Collections.Generic;

namespace Tests;

public class TestCropImages
{
    [Fact]
    public void TestResize1()
    {
        string outputFolder = "../../../../Tests/testruns/resize_crop_grayscale_png_sample_csv";
        if (Directory.Exists(outputFolder))
            Directory.Delete(outputFolder, true);

        var t = new Transformer();
        t.InputFolderPath = "../../../../Tests/images";
        t.OutputFolderPath = outputFolder;
        t.ImageOperations!.FlipModes!.Add(FlipMode.Vertical);
        t.ImageOperations.FlipModes.Add(FlipMode.None);
        t.ImageOperations!.RotateModes!.Add(RotateMode.Rotate90);
        t.ImageOperations.RotateModes.Add(RotateMode.None);
        t.ImageOperations.Resize = true;
        t.ImageOperations.ResizeMode = ResizeMode.Stretch;
        t.ImageOperations!.ResizeDimensions!.Height = 1200;
        t.ImageOperations.ResizeDimensions.Width = 1200;
        t.ImageOperations.Grayscale = false;
        t.EncodeType = EncodeType.PNG;
        t.Sample = 4;
        t.ImageOperations.Crop = true;
        t.ImageOperations!.CropDimensions!.Height = 600;
        t.ImageOperations.CropDimensions.Width = 600;
        t.ExportCsv = true;

        new ImageTransformer().PerformImageTransformations(t);

        // Performing 2 operations on a sample of 4 + exporting csv, total files should be 17
        var allFiles = Directory.GetFiles(outputFolder);
        Assert.Equal(17, allFiles.Count());

        // Ensure a CSV file was exported and named appropriately
        var csvFile = Directory.EnumerateFiles(outputFolder)
                .Where(file => file.ToLower().EndsWith("csv"))
                .FirstOrDefault();
        Assert.Equal(true, csvFile != null);
        Assert.Equal("transformations.csv", new FileInfo(csvFile!).Name);

        // Ensure the CSV has the correct number of rows
        List<Csv> records = new List<Csv>();
        using (var reader = new StreamReader(csvFile!))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            records = csv.GetRecords<Csv>().ToList();
        }
        Assert.Equal(16, records.Count());
    }
}