# CSV Generation
You can generate a CSV file of all the images processed by passing the `--exportcsv` argument.

## Examples
Consider the following image, found in a directory titled `my-images` with a name of `red-jacket.jpg`:

<p align="left">
  <img src="https://raw.githubusercontent.com/sharpdarts/ml-image-transformations/gh-pages/_images/red-jacket.jpg" alt="logo" width="200"/>
  <br />
  <em>Image size 1800 x 2400</em>
</p>

We can export a CSV file using the following commands:

### CSV Generation

```
./MLImageTransformer --inputfolder=my-images --outputfolder=my-images --flipmodes=Vertical Horizontal --rotatemodes=Rotate90 Rotate180 Rotate270 --exportcsv=true
```
The following CSV file will be generated:

```
Filename
red-jacket_Horizontal_Rotate180.jpg
red-jacket_Vertical_Rotate180.jpg
red-jacket_Vertical_Rotate90.jpg
red-jacket_Vertical_Rotate270.jpg
red-jacket_Horizontal_Rotate270.jpg
red-jacket_Horizontal_Rotate90.jpg
```