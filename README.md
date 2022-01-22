# ML Image Transformations - MLIT
The ML Image Transformations (MLIT) is a CLI & Docker image to transform images for machine learning tasks where you need to perform data augmentation to generate multiple versions of an image to increase your dataset size. This tool allows you to specify a folder of images and then specify the transformations to take place, such as:

- Flip: Horizontal, Vertical
- Rotate: 90, 180, 270

In addition you can also specify the following:

- Resize
- Grayscale
- Crop

MLIT is written to take advantage of all the available processors on your machine, so the more cores you have the faster it will run.

## Docs
Please check out our documentation for a complete walk-through of using MLIT.

https://sharpdarts.github.io/ml-image-transformations/

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
docker run -v $(pwd)/images:/images sharpdarts-mlit --inputfolder=/images --outputfolder=/images --sample=2 --flipmodes=Vertical --rotatemodes=None
```

You need to mount the `images` directory to the internal `images` folder in the Docker container. You can then pass `/images` to the `inputfolder` and `outputfolder` arguments.

## Arguments
The following arguments are accepted by the CLI:

- **inputfolder** (string): The folder where the images you want to process are located. This should be a single folder of images, the CLI will not perform any recurssion on the folder.
- **outputfolder** (string): The folder where the output images will be placed. This can be the same folder as the input or something different. If the output folder does not exist, the CLI will attempt to create it.
- **sample** (integer): You can use this to limit the number of conversions to perform. This is a convenience argument so you can test the conversions on a couple of images only rather than processing the entire folder.
- **flipmodes** (space delimited string array)

## Releases
You can view all the releases here: https://github.com/sharpdarts/ml-image-transformations/releases

Releases are available for Linux, Windows, and MacOS.
