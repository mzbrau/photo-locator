# Photo Locator

![screenshot](https://github.com/mzbrau/photo-locator/blob/master/Screenshots/PhotoLocator.PNG)

Photo Locator is an easy to use photo location visualisation tool written in .NET.
It reads the photo metadata and then displays the location of the photos on the map.

It has the following features:
- Open images and display their locations on the map
- Centre the map on the location of an image (click the number)
- Find image in the list (click the pin)
- Filter the image list
- Open the image (click the image)
- Export all photo details to a CSV file (semi-colon delimited)
- Rename all photos to the format 'Date Time Address'

## Bing Maps Key
The application relies on a bing maps API key which you can get for free for private use.
The map key will be set the first time you run the application. It is required for the map and for the GPS coordinate lookups.
See the [Microsoft Website](https://docs.microsoft.com/en-us/bingmaps/getting-started/bing-maps-dev-center-help/getting-a-bing-maps-key) for more details.


## Releases
You can download the release installer here.

[Download v1.0](https://github.com/mzbrau/photo-locator/raw/master/Releases/1.0/Photo%20Locator.msi)


## Note to iPhone users
In order for this app to work with photos taken from an iPhone, the camera must be set to use the 'Most Compatible' format.
![iphone](https://github.com/mzbrau/photo-locator/blob/master/Screenshots/iPhone.PNG)
