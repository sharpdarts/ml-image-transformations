# Crop Operations
You can perform crop operations with MLIT using the `--crop` argument. If this flag is set to `true` the following arguments will be required:
- cropwidth (integer)
- cropheight (integer)

**NOTE**: Currently the crop is performed from the center of the image only.

## Examples
Consider the following image, found in a directory titled `my-images` with a name of `red-jacket.jpg`:

<p align="left">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 1800 x 2400</em>
</p>

We can crop this image using the following commands:

### Crop to a 244 x 244 Square

```
./MLImageTransformer --inputfolder=my-images --outputfolder=my-images --flipmodes=None --rotatemodes=None --crop=true --cropwidth=244 --cropheight=244
```
<p align="left">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket_None_None_crop_example1.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 244 x 244</em>
</p>

### Crop to a 500 x 750 Square

```
./MLImageTransformer --inputfolder=my-images --outputfolder=my-images --flipmodes=None --rotatemodes=None --crop=true --cropwidth=500 --cropheight=750
```
<p align="left">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket_None_None_crop_example2.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 500 x 750</em>
</p>