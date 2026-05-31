---
id: getting-started
title: Getting Started
sidebar_label: Getting Started
sidebar_position: 2
description: Get up and running with Photo Locator in minutes. Download, install and load your first photos.
---

# Getting Started

This guide will walk you through downloading Photo Locator, setting it up for the first time, and loading your first set of photos.

## Step 1 — Download

Download the latest installer from the GitHub releases page:

➡️ **[Download Photo Locator v1.0 (.msi)](https://github.com/mzbrau/photo-locator/raw/master/Releases/1.0/Photo%20Locator.msi)**

## Step 2 — Install

Run the downloaded `.msi` installer and follow the on-screen steps. See the [Installation](./installation) page for detailed instructions.

## Step 3 — Configure Bing Maps

Photo Locator requires a free **Bing Maps API key** to display the map and look up addresses. When you launch the app for the first time, a settings dialog will appear automatically.

See [Configuration](./configuration) for instructions on obtaining a free key.

## Step 4 — Open Photos

1. Launch **Photo Locator** from the Start Menu or desktop shortcut.
2. Click the **Open** button (or use the File menu).
3. Browse to a folder containing photos with GPS data.
4. Select one or more image files and click **Open**.

Photos that contain GPS coordinates will immediately appear as numbered pins on the map.

## Step 5 — Explore

- **Click a pin number** in the list to centre the map on that photo's location.
- **Click a map pin** to highlight the corresponding photo in the list.
- **Click a photo thumbnail** to open it in your default image viewer.
- Use the **filter bar** to search by address or photo number.

## Quick Tips

:::tip Multiple Selection
Hold `Ctrl` or `Shift` while selecting files in the Open dialog to load multiple photos at once.
:::

:::tip No GPS Data?
If a photo does not have GPS metadata, it will still appear in the list with the address shown as **"Unknown Location"**, but no pin will be placed on the map.
:::

:::note
Photos that have already been loaded are not duplicated if you open them again — Photo Locator tracks file paths to prevent duplicates.
:::

## Next Steps

- [Features → Map View](./features/map-view) — learn how to navigate the map
- [Features → CSV Export](./features/csv-export) — export your photo locations
- [Features → Rename Photos](./features/rename-photos) — batch-rename by location
