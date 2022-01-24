# Rotate Operations
You can perform the following rotate operations with MLIT:
- Rotate90
- Rotate180
- Roteate270

This is done using the `--rotatemodes` argument which is required when invoking the MLIT. The following arguments are accepted, and you must pass at least one in:

- **None**: Do not perform any rotate operations
- **Rotate90**: Perform a 90 degree rotate on the images
- **Rotate180**: Perform a 180 degree rotate on the images
- **Rotate270**: Perform a 270 degree rotate on the images

These arguments are passed as a space delimited string and **MUST BE** capitalized, for instance:

```
--rotatemodes=Rotate90 Rotate180
```

```
--rotatemodes=None
```

## Examples
Consider the following image, found in a directory titled `my-images` with a name of `red-jacket.jpg`:

<p align="left">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 1800 x 2400</em>
</p>

We can flip this image using the following commands:

### 90 Degree Rotation

```
./MLImageTransformer --inputfolder=my-images --flipmodes=None --rotatemodes=Rotate90
```
<p align="left">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket_None_Rotate90.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 1800 x 2400</em>
</p>

### 180 Degree Rotation

```
./MLImageTransformer --inputfolder=my-images --flipmodes=None --rotatemodes=Rotate180
```
<p align="left">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket_None_Rotate180.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 1800 x 2400</em>
</p>

### 270 Degree Rotation

```
./MLImageTransformer --inputfolder=my-images --flipmodes=None Vertical --rotatemodes=Rotate270
```
<p align="left">
<img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket_None_Rotate270.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 1800 x 2400</em>
</p>

### 90, 180, & 270 Degree Rotation

```
./MLImageTransformer --inputfolder=my-images --flipmodes=None Vertical --rotatemodes=Rotate90 Rotate180 Rotate270
```
<p align="left">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket_None_Rotate90.jpg" alt="logo" width="200"/>
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket_None_Rotate180.jpg" alt="logo" width="200"/>
<img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket_None_Rotate270.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 1800 x 2400</em>
</p>

### More Examples
You can find more detailed examples here: [Examples Page](https://sharpdarts.github.io/ml-image-transformations/examples.html)
