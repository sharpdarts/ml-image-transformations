# Flip Operations
You can perform the following flip operations with MLIT:
- Horizontal
- Vertical

This is done using the `--flipmodes` argument which is required when invoking the MLIT. The following arguments are accepted, and you must pass at least one in:

- **None**: Do not perform any flip operations
- **Horizontal**: Perform a horizontal flip on the images
- **Vertical**: Perform a vertical flip on the images

These arguments are passed as a space delimited string and **MUST BE** capitalized, for instance:

```
--flipmodes=Vertical Horizontal
```

```
--flipmodes=None
```

## Examples
Consider the following image, found in a directory titled `my-images` with a name of `red-jacket.jpg`:

<p align="left">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 1800 x 2400</em>
</p>

We can flip this image using the following commands:

### Vertical Flip

```
./MLImageTransformer --inputfolder=my-images --flipmodes=Vertical --rotatemodes=None
```
<p align="left">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket_Vertical_None.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 1800 x 2400</em>
</p>

### Horizontal Flip

```
./MLImageTransformer --inputfolder=my-images --flipmodes=Horizontal --rotatemodes=None
```
<p align="left">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket_Horizontal_None.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 1800 x 2400</em>
</p>

### Vertical & Horizontal Flip

```
./MLImageTransformer --inputfolder=my-images --flipmodes=Horizontal Vertical --rotatemodes=None
```
<p align="left">
<img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket_Vertical_None.jpg" alt="logo" width="200"/>
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket_Horizontal_None.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 1800 x 2400</em>
</p>

### More Examples
You can find more detailed examples here: https://sharpdarts.github.io/ml-image-transformations/examples.html