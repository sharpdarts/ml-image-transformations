# Quickstart
There are two ways to use the MLIT tool, CLI or Docker container. Both provide the same functionality and can be used almost identically.

## CLI
The CLI is available in the following versions:
- Windows
- Linux
- MacOS

You can find all the releases on the GitHub repo located here: https://github.com/sharpdarts/ml-image-transformations/releases

Once you download the CLI simply place it anywhere you like and then invoke it via the following command:

Linux example:
```
./MLImageTransformer --help
```

## Docker
The Docker container is located in Docker Hub and can be pulled via the following command:

```
docker pull sharpdartsgithub/mlit:latest
```

To run the image, you can use the folliwng command:

```
docker run sharpdarts-mlit --help
```

The only difference when running with Docker is you must mount the volume where your images are located:

```
docker run -v $(pwd)/images:/images mlit --inputfolder=/images
```