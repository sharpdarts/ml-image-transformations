---
---

<p align="center">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/mlit-logo.png" alt="logo" width="400" align="center"/>
</p>

# Simplify data augmentation with image datasets
The ML Image Transformations (MLIT) is a CLI & Docker image to transform images for machine learning tasks where you need to perform data augmentation to generate multiple versions of an image to increase your dataset size. This tool allows you to specify a folder of images and then specify the transformations to take place, such as:

- Flip: Horizontal, Vertical
- Rotate: 90, 180, 270

In addition you can also specify the following:

- Resize
- Grayscale
- Crop

MLIT is written to take advantage of all the available processors on your machine, so the more cores you have the faster it will run.

## How It Works
Consider the following directory structure:

- Parent Directory
  - images (this folder holds all the images we want to transform)
    - person1.jpg
    - person2.jpg


From the parent directory run the following command:

```
./MLImageTransformer --inputfolder=images --outputfolder=images/ouput --flipmodes=Vertical --rotatemodes=Rotate90 Rotate180
```

This will create the directory `output` in the `images` directory with the following files:
- person1_Vertical_Rotate90.jpg
- person1_Vertical_Rotate180.jpg
- person2_Vertical_Rotate90.jpg
- person2_Vertical_Rotate180.jpg

The CLI will produce the following output to indicate what it performed:
```
Output folder path does not exist, creating directory.
Number of files to transform: 2, with 2 of operations to complete.
Starting transformations...
Finished person1_Vertical_Rotate90.jpg - 1 of 4 files...
Finished person1_Vertical_Rotate180.jpg - 2 of 4 files...
Finished person2_Vertical_Rotate180.jpg - 3 of 4 files...
Finished person2_Vertical_Rotate90.jpg - 4 of 4 files...
Image conversion was successful: True
Number of files: 4, Number of conversions: 4
RunTime 00:00:04.52
```

The following lines indicate a success or partial failure:
```
Image conversion was successful: True
Number of files: 4, Number of conversions: 4
```

The CLI will not fail completely if it encounteres an error. Instead it will attempt to complete as many conversions as possible. For instance, if you have 100 conversions to perform, but only 99 complete, the CLI will indicate a the conversion was not successful even though it completed 99 of the 100 conversions.

## Using the CLI
Consider the following directory structure:

- Parent Directory
  - images (this folder holds all the images we want to transform)

From the parent directory run the following command:

```
./MLImageTransformer --inputfolder=images --outputfolder=images --sample=2 --flipmodes=Vertical --rotatemodes=None
```

## Using the Docker Image
Consider the following directory structure:

- Parent Directory
  - images (this folder holds all the images we want to transform)

You can run the following command from the parent directory:

```
docker run -v $(pwd)/images:/images sharpdartsgithub/mlit --inputfolder=/images --outputfolder=/images --sample=2 --flipmodes=Vertical --rotatemodes=None
```

You need to mount the `images` directory to the internal `images` folder in the Docker container. You can then pass `/images` to the `inputfolder` and `outputfolder` arguments.

## Arguments
The following arguments are accepted by the CLI:

- **inputfolder** (string, **REQUIRED**): The folder where the images you want to process are located. This should be a single folder of images, the CLI will not perform any recurssion on the folder.

`--inputfolder=my_directory`

- **outputfolder** (string): The folder where the output images will be placed. This can be the same folder as the input or something different. If the output folder does not exist, the CLI will attempt to create it.

`--outputfolder=my_other_directory`

- **sample** (integer): You can use this to limit the number of conversions to perform. This is a convenience argument so you can test the conversions on a couple of images only rather than processing the entire folder.

`--sample=2`

- **flipmodes** (space delimited string array, **REQUIRED**): The requested flips to perform on the images. Options are None, Horizontal, and/or Vertical, these options must be capitalized! At least one value is required.

`--flipmodes=None`, will perform no flip operations on the images

`--flipmodes=Horizontal Vertical`, will perform both horizontal and vertical flips on the images, this creates two additional images

- **rotatemodes** (space delimited string array, **REQUIRED**): The requested rotates to perform on the images. Options are None, Rotate90, Rotate180, and/or Rotate270, these options must be capitalized! At least one value is required.

`--rotatemodes=None`, will perform no rotate operations on the images

`--rotatemodes=Rotate90 Rotate180`, will perform both 90 degree rotation and a 180 degree rotation on the images, this creates two additional images

- **grayscale** (boolean): Flag to indicate whether you want the images to be converted to grayscale.

`--grayscale=true`

- **resize** (boolean): Flag to indicate whether you want to resize the images.

`--resize=true`

- **resizemode** (string **REQUIRED IF** if indicate a resize should take place): Flag to indicate how the resize should be performed. Options are Crop, Pad, BoxPad, Max, Min, and Stretch, these options must be capitalized.

`--resizemode=Stretch`, will stretch the image if the aspect ration changes during the resize operation.

- **resizeheight** (integer **REQUIRED IF** if indicate a resize should take place): Height of the new image if a resize operation is taking place.

`--resizeheight=244`, sets the height of the new image to 244

- **resizewidth** (integer **REQUIRED IF** if indicate a resize should take place): Width of the new image if a resize operation is taking place.

`--resizewidth=244`, sets the width of the new image to 244

- **crop** (boolean): Flag to indicate whether you want to crop the images. **NOTE**: Currently crops take place from the center of the image, this is the only option available.

`--crop=true`

- **cropheight** (integer **REQUIRED IF** if indicate a crop should take place): Height of the new image if a crop operation is taking place.

`--cropheight=244`, sets the height of the new image to 244

- **cropwidth** (integer **REQUIRED IF** if indicate a crop should take place): Width of the new image if a crop operation is taking place.

`--cropwidth=244`, sets the width of the new image to 244

- **exportcsv** (boolean): Flag to indicate whether you want a CSV of all the image file names to be exported.

`--exportcsv=true`, exports a CSV of filenames after processing is complete.

## Releases
You can view all the releases here: https://github.com/sharpdarts/ml-image-transformations/releases

Releases are available for Linux, Windows, and MacOS.
