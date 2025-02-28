# Reading images

## Read image

```C#
// Read from file.
using (var image = new MagickImage("c:\path\to\Snakeware.jpg"))
{
}

// Read from stream.
using (var memStream = LoadMemoryStreamImage())
{
    using (var image = new MagickImage(memStream))
    {
    }
}

// Read from byte array.
var data = LoadImageBytes();
using (var image = new MagickImage(data))
{
}

// Read image that has no predefined dimensions.
var settings = new MagickReadSettings();
settings.Width = 800;
settings.Height = 600;
using (var image = new MagickImage("xc:yellow", settings))
{
}

using (var image = new MagickImage())
{
    image.Read("c:\path\to\Snakeware.jpg");
    image.Read(memStream);
    image.Read("xc:yellow", settings);

    using (var memStream = LoadMemoryStreamImage())
    {
        image.Read(memStream);
    }
}
```

## Read basic image information:

```C#
// Read from file
var info = new MagickImageInfo("c:\path\to\Snakeware.jpg");

// Read from stream
using (var memStream = LoadMemoryStreamImage())
{
    info = new MagickImageInfo(memStream);
}

// Read from byte array
var data = LoadImageBytes();
info = new MagickImageInfo(data);

info = new MagickImageInfo();
info.Read("c:\path\to\Snakeware.jpg");
using (var memStream = LoadMemoryStreamImage())
{
    info.Read(memStream);
}
info.Read(data);

Console.WriteLine(info.Width);
Console.WriteLine(info.Height);
Console.WriteLine(info.ColorSpace);
Console.WriteLine(info.Format);
Console.WriteLine(info.Density.X);
Console.WriteLine(info.Density.Y);
Console.WriteLine(info.Density.Units);
```

## Read image with multiple layers/frames:

```C#
// Read from file
using (var collection = new MagickImageCollection("c:\path\to\Snakeware.gif"))
{
}

// Read from stream
using (var memStream = LoadMemoryStreamImage())
{
    using (var images = new MagickImageCollection(memStream))
    {
    }
}

// Read from byte array
var data = LoadImageBytes();
using (var images = new MagickImageCollection(data))
{
}

// Read pdf with custom density.
var settings = new MagickReadSettings();
settings.Density = new Density(144);

using (var images = new MagickImageCollection("c:\path\to\Snakeware.pdf", settings))
{
}

using (var images = new MagickImageCollection())
{
    images.Read("c:\path\to\Snakeware.jpg");
    using (var memStream = LoadMemoryStreamImage())
    {
        images.Read(memStream);
    }
    images.Read(data);
    images.Read("c:\path\to\Snakeware.pdf", settings);
}
```
