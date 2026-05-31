---
id: csv-export
title: CSV Export
sidebar_label: CSV Export
sidebar_position: 4
description: Export all photo metadata — filenames, addresses, dates and GPS coordinates — to a CSV file from Photo Locator.
---

# CSV Export

Photo Locator can export the details of all loaded photos to a **CSV (Comma-Separated Values) file** for use in spreadsheet applications such as Microsoft Excel, Google Sheets, or LibreOffice Calc.

## Exporting

1. Load the photos you want to export (see [Getting Started](../getting-started)).
2. Click the **Export** button in the toolbar.
3. Photo Locator generates the CSV file and opens it automatically.

The file is saved to your **Desktop** with a timestamped filename:

```
Photo Locator Export - 2024-06-15 143022.csv
```

## CSV Format

The file uses a **semi-colon (`;`) delimiter** rather than a comma. This avoids conflicts with addresses that may contain commas.

### Columns

| Column | Description | Example |
|---|---|---|
| `Name` | Filename of the photo | `IMG_1234.JPG` |
| `Address` | Reverse-geocoded street address | `10 Downing St, London, UK` |
| `Date Taken` | Date and time the photo was taken | `01/06/2024 14:30:00` |
| `Latitude` | GPS latitude in decimal degrees | `51.5034` |
| `Longitude` | GPS longitude in decimal degrees | `-0.1276` |
| `File Path` | Full file path on disk | `C:\Photos\Holiday\IMG_1234.JPG` |

### Example Output

```
Name;Address;Date Taken;Latitude;Longitude;File Path
IMG_1234.JPG;10 Downing St, Westminster, London, UK;01/06/2024 14:30:00;51.5034;-0.1276;C:\Photos\IMG_1234.JPG
IMG_5678.JPG;Eiffel Tower, Paris, France;02/06/2024 09:15:00;48.8584;2.2945;C:\Photos\IMG_5678.JPG
IMG_9999.JPG;Unknown Location;;;C:\Photos\IMG_9999.JPG
```

:::note
Photos without GPS data will have empty `Latitude` and `Longitude` columns.
:::

## Opening the CSV

After the file is written, Photo Locator calls `Process.Start()` on the file path, which opens it in your system's default application for `.csv` files (usually Microsoft Excel or Notepad).

If the file cannot be opened automatically, a message box will display the file path so you can navigate there manually.

## File Location

All exports are saved to your **Windows Desktop** (`%USERPROFILE%\Desktop`). The filename includes the current date and time to prevent overwrites:

```
Photo Locator Export - YYYY-MM-DD HHmmss.csv
```

## Tips

:::tip Filtering Before Export
The CSV export always includes **all loaded photos**, regardless of any active filter. To export a subset, load only those specific files.
:::

:::tip Importing into Excel
When opening the CSV in Excel, use **Data → From Text/CSV** and set the delimiter to **semicolon** for correct column parsing. Alternatively, rename the file extension to `.txt` before opening and Excel's import wizard will prompt for the delimiter.
:::
