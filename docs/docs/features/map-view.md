---
id: map-view
title: Map View
sidebar_label: Map View
sidebar_position: 1
description: Learn how to use the interactive Bing Maps map view in Photo Locator to explore photo locations.
---

# Map View

The map view is the centrepiece of Photo Locator. It shows a push-pin marker for every photo that contains GPS coordinates, plotted on an interactive Bing Maps map.

## Overview

When photos are loaded, Photo Locator:

1. Reads the GPS EXIF metadata from each file.
2. Places a numbered **push-pin** on the map at the corresponding coordinates.
3. Automatically zooms and pans the map to fit all loaded photos into view.

Each push-pin displays a **number** corresponding to the photo's index in the photo list, making it easy to cross-reference map locations with the list.

## Navigating the Map

Photo Locator uses the standard Bing Maps WPF control. You can navigate the map using:

| Action | How to do it |
|---|---|
| **Pan** | Click and drag the map |
| **Zoom in** | Scroll the mouse wheel up, or double-click |
| **Zoom out** | Scroll the mouse wheel down |
| **Zoom to all photos** | Click the **Show All** button in the toolbar |
| **Zoom to one photo** | Click the index number next to a photo in the list |

## Push-Pin Tooltips

Hovering over a push-pin shows a tooltip with the photo's **filename** (or, after renaming, the new descriptive name).

## Selecting a Photo from the Map

Click any push-pin on the map to **select** the corresponding photo in the photo list. The list will scroll to show the selected photo and highlight it.

## Centering on a Photo

To centre the map on a specific photo, click the **index number** next to that photo in the list panel. The map will zoom to show the photo's location with a comfortable margin.

## Show All Button

The **Show All** button in the toolbar resets the map view to show all loaded photos at once. It calculates a bounding box from all photo coordinates and adds a 10% margin for context.

:::tip Single Photo
When only one photo is loaded (or selected), the Show All/Centre view uses a fixed 0.009° margin (~1 km) so the view is not too zoomed in on a single point.
:::

## Photos Without Location Data

Photos that do not contain GPS EXIF data are **not** shown on the map. They still appear in the photo list with the address displayed as **"Unknown Location"**. No push-pin is created for them.

## Map Style

The map uses the standard Bing Maps road view. The map style and tile provider cannot currently be changed within the application.

## Technical Notes

- Map rendering is provided by the **Microsoft.Maps.MapControl.WPF** library.
- Coordinates are read from the **GPS IFD** EXIF tags using the MetadataExtractor library.
- A valid **Bing Maps API key** is required for the map to load. See [Configuration](../configuration).
