---
id: intro
title: Introduction
sidebar_label: Introduction
sidebar_position: 1
slug: /intro
description: An overview of Photo Locator — a free Windows desktop application for visualising photo GPS locations on an interactive map.
---

# Introduction

**Photo Locator** is a free, easy-to-use Windows desktop application written in .NET that reads GPS metadata from your photos and displays their locations on an interactive Bing Maps map.

![Photo Locator screenshot](https://github.com/mzbrau/photo-locator/blob/master/Screenshots/PhotoLocator.PNG?raw=true)

## What is Photo Locator?

Most modern cameras and smartphones embed GPS coordinates into the EXIF metadata of every photo they take. Photo Locator reads this hidden information and plots each photo on a map, giving you an instant visual overview of where your photos were taken.

Whether you are organising a travel album, reviewing photos from a family event, or just curious about where your memories were made, Photo Locator makes it effortless.

## Key Features

| Feature | Description |
|---|---|
| **Interactive Map** | View all photo locations on a Bing Maps map with push-pin markers |
| **GPS Extraction** | Automatically reads EXIF GPS metadata from JPEG, PNG, BMP, GIF and TIFF files |
| **Address Lookup** | Reverse-geocodes coordinates to human-readable street addresses |
| **Photo List** | Scrollable list with thumbnails, addresses and timestamps |
| **Filtering** | Instant search across addresses and photo indices |
| **CSV Export** | Export all photo metadata to a semi-colon delimited CSV file |
| **Smart Renaming** | Rename photos to `Date Time Address` format in bulk |
| **Conflict-safe** | Duplicate filename detection prevents accidental overwrites |

## System Requirements

- **Operating System:** Windows 10 or later
- **Runtime:** .NET Framework 4.x (included with Windows)
- **Internet access:** Required for Bing Maps display and reverse geocoding
- **Bing Maps API Key:** Free for personal use (see [Configuration](./configuration))

## Supported File Formats

Photo Locator supports the following image formats:

- JPEG / JPG
- PNG
- BMP
- GIF
- TIFF

:::info iPhone Users
To use Photo Locator with iPhone photos, set your camera format to **Most Compatible** in iOS Settings → Camera → Formats. This ensures photos are saved as standard JPEG files with compatible EXIF metadata.
:::

## Next Steps

- [Getting Started](./getting-started) — download and launch the app
- [Installation](./installation) — step-by-step installation guide
- [Configuration](./configuration) — set up your Bing Maps API key
