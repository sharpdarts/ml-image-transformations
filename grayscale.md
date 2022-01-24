# Grayscale Operations
You can perform a grayscale operation with MLIT using the `--grayscale` argument.

## Examples
Consider the following image, found in a directory titled `my-images` with a name of `red-jacket.jpg`:

<p align="left">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 1800 x 2400</em>
</p>

We can grayscale this image using the following commands:

### Grayscale

```
./MLImageTransformer --inputfolder=my-images --outputfolder=my-images --flipmodes=None --rotatemodes=None --grayscale=true
```
<p align="left">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket_None_None_graysacle.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 1800 x 2400</em>
</p>

### More Examples
You can find more detailed examples here: [Examples Page](https://sharpdarts.github.io/ml-image-transformations/examples.html)