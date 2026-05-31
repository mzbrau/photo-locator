---
id: photo-list
title: Photo List
sidebar_label: Photo List
sidebar_position: 2
description: How to use the photo list panel in Photo Locator to browse, preview and manage your loaded photos.
---

# Photo List

The photo list panel displays all loaded photos in a scrollable, sortable list. Each entry shows a thumbnail, metadata and quick-action controls.

## List Layout

Each row in the photo list contains:

| Element | Description |
|---|---|
| **Thumbnail** | A 120 px wide preview of the photo with automatic rotation correction |
| **Index number** | Sequential number assigned when the photo was loaded |
| **Filename** | The current filename of the photo |
| **Address** | The reverse-geocoded street address, or "Unknown Location" |
| **Date taken** | Extracted from EXIF `Date/Time` tag; falls back to file creation date |
| **Coordinates** | Latitude and longitude (blank if no GPS data) |

## Sorting

Photos are sorted by **date taken** in ascending order. This sorting is applied automatically and cannot be changed in the current version.

## Selecting a Photo

Click anywhere on a photo row to select it. The selected photo is highlighted. Selecting a photo also:

- Updates the **SelectedPhoto** binding used by detail views
- Enables the **Open Image** action

## Opening a Photo

Click the **photo thumbnail** to open the full-size image in your default image viewer (e.g., Windows Photos, Paint.NET).

:::info
Photo Locator passes the file path to `Process.Start()`, which uses the system default application for the file type.
:::

## Navigating to a Photo on the Map

Click the **index number** (the numbered badge on each row) to centre the map on that photo's location. If the photo has no GPS data, the map view is not changed.

## Finding a Photo from the Map

Click any **map push-pin** to select and scroll to the matching photo in the list.

## Thumbnail Rotation

Photo Locator automatically corrects the orientation of thumbnails based on the EXIF orientation tag. Rotations of 90°, 180° and 270° are supported, ensuring portrait photos are displayed upright.

## Photos Without GPS Data

Photos without GPS metadata still appear in the list. Their address reads **"Unknown Location"** and no push-pin is placed on the map. All other list columns (filename, date, index) are populated normally.

## Duplicate Prevention

If you open the same file a second time, Photo Locator checks whether the file path is already in the list. Duplicates are silently ignored — the photo count does not increase.

## Loading More Photos

You can load additional photos at any time by clicking **Open** again. New photos are appended to the existing list and the map view is updated to include all photos.
