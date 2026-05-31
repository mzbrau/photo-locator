---
id: rename-photos
title: Rename Photos
sidebar_label: Rename Photos
sidebar_position: 5
description: Batch-rename all loaded photos to a descriptive Date Time Address format using Photo Locator.
---

# Rename Photos

Photo Locator can rename all loaded photos at once to a standardised, descriptive filename based on when and where each photo was taken.

## Naming Format

Renamed files follow this pattern:

```
YYYY-MM-DD HHmm - Address.ext
```

### Examples

| Original name | Renamed to |
|---|---|
| `IMG_1234.JPG` | `2024-06-15 1430 - 10 Downing St Westminster London UK.JPG` |
| `DSC_0042.jpg` | `2023-12-25 0900 - Times Square New York NY USA.jpg` |
| `photo.png` | `2024-01-01 1200 - Sydney Opera House Sydney NSW Australia.png` |

The date and time come from the **EXIF Date/Time tag** (falling back to the file creation date if the tag is absent). The address comes from reverse geocoding the GPS coordinates via Bing Maps.

## Renaming All Photos

1. Load the photos you want to rename (see [Getting Started](../getting-started)).
2. Ensure all photos have addresses loaded (addresses are resolved asynchronously — wait for "Unknown Location" to be replaced).
3. Click the **Rename All** button in the toolbar.
4. A confirmation dialog reports how many photos were renamed.

:::warning
Renaming is a **destructive operation** — the original files are moved/renamed on disk. Make sure you have a backup before proceeding.
:::

## Conflict Resolution

If a target filename already exists in the same folder, Photo Locator appends an incrementing number to avoid overwriting:

```
2024-06-15 1430 - Paris France.JPG         ← already exists
2024-06-15 1430 - Paris France(1).JPG      ← used instead
2024-06-15 1430 - Paris France(2).JPG      ← next conflict, etc.
```

## Invalid Character Removal

Street addresses can contain characters that are invalid in Windows filenames (e.g., `/`, `:`, `*`, `?`). Photo Locator automatically strips any invalid characters from the address before constructing the new filename.

## Result Reporting

After renaming, a dialog box summarises the outcome:

| Result | Description |
|---|---|
| **Renamed** | File was successfully renamed |
| **No change** | The file already had the correct target name |
| **Error** | An exception occurred (e.g., file locked, permission denied) |

If any errors occurred, the dialog title reads **"Complete with Errors"** and lists the error messages. Otherwise it reads **"Complete"**.

## Map Pin Updates

After renaming, the map push-pin tooltip for each photo is updated to reflect the new filename, keeping the map and list in sync.

## Photos Without GPS Data

Photos without GPS coordinates have the address **"Unknown Location"**. If you rename all, these photos will be renamed to:

```
2024-06-15 1430 - Unknown Location.JPG
```

To avoid renaming photos without location data, load only photos with GPS metadata before using Rename All.

## Reverting a Rename

Photo Locator does not have an undo feature for renaming. If you need to revert, restore files from a backup or rename them manually.
