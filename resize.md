# Resize Operations
You can perform resize operations with MLIT using the `--resize` argument. If this flag is set to `true` the following arguments will be required:
- resizemode (string)
- resizewidth (integer)
- resizeheight (integer)

The following options are available for the `--resizemode` argument:
- Crop
- Pad
- BoxPad
- Max
- Min
- Stretch

## Examples
Consider the following image, found in a directory titled `my-images` with a name of `red-jacket.jpg`:

<p align="left">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 1800 x 2400</em>
</p>

We can resize this image using the following commands:

### Resize with Stretch

```
./MLImageTransformer --inputfolder=my-images --outputfolder=my-images --flipmodes=None --rotatemodes=None --resize=true --resizemode=Stretch --resizewidth=500 --resizeheight=1600
```
<p align="left">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket_None_None_size1_example.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 1600 x 500</em>
</p>

### Resize with Crop

```
./MLImageTransformer --inputfolder=my-images --outputfolder=my-images --flipmodes=None --rotatemodes=None --resize=true --resizemode=Crop --resizewidth=500 --resizeheight=1600
```
<p align="left">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket_None_None_resize2_example.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 1600 x 500</em>
</p>

### Resize with BoxPad

```
./MLImageTransformer --inputfolder=my-images --outputfolder=my-images --flipmodes=None --rotatemodes=None --resize=true --resizemode=BoxPad --resizewidth=500 --resizeheight=1600
```
<p align="left">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket_None_None_resize3_example.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 1600 x 500</em>
</p>

### More Examples
You can find more detailed examples here: [Examples Page](https://sharpdarts.github.io/ml-image-transformations/examples.html)