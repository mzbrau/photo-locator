---
id: troubleshooting
title: Troubleshooting
sidebar_label: Troubleshooting
sidebar_position: 6
description: Solutions to common issues with Photo Locator, including map display problems, missing GPS data and file errors.
---

# Troubleshooting

This page covers common issues and how to resolve them.

## Map Is Blank or Grey

**Symptoms:** The map area displays as a blank/grey panel with no tiles.

**Causes and fixes:**

| Cause | Fix |
|---|---|
| No Bing Maps API key entered | Open **Settings** and enter a valid key (see [Configuration](./configuration)) |
| Invalid or expired API key | Create a new key at [bingmapsportal.com](https://www.bingmapsportal.com) |
| No internet connection | Connect to the internet — Bing Maps requires a live connection |
| Firewall blocking Bing Maps | Allow outbound HTTPS to `*.virtualearth.net` in your firewall |

---

## Addresses Show "No Address Found"

**Symptoms:** Photos appear on the map with pins, but the address column shows "No Address Found" instead of a street address.

**Causes and fixes:**

| Cause | Fix |
|---|---|
| Bing Maps key over free quota | Wait until the quota resets or create a new key |
| No internet connection | Reconnect and reload photos |
| GPS coordinates in a remote area | Some coordinates (ocean, mountains) have no address — this is expected |

---

## Photos Show "Unknown Location"

**Symptoms:** Photos appear in the list but with "Unknown Location" address and no map pin.

**Cause:** The photo does not contain GPS EXIF metadata.

**Fixes:**

- **iPhone users:** Go to iOS **Settings → Camera → Formats** and set to **Most Compatible**. Ensure **Location Services** is enabled for Camera under **Settings → Privacy → Location Services → Camera**.
- **Android users:** Ensure your camera app has location permissions and that GPS is enabled when taking photos.
- **Older cameras:** Many point-and-shoot cameras do not record GPS. Consider using a photo geotagging tool to add coordinates manually.

---

## Application Crashes on Startup

**Symptoms:** Photo Locator closes immediately after opening, possibly with an error dialog.

**Fixes:**

1. Ensure **.NET Framework 4.x** is installed (it is included with Windows 10/11 by default — run Windows Update if unsure).
2. Try running as Administrator: right-click the shortcut → **Run as administrator**.
3. Check the Windows Event Viewer (**Event Viewer → Windows Logs → Application**) for error details.
4. Reinstall Photo Locator using the latest MSI installer.

---

## Cannot Open a Photo

**Symptoms:** Clicking a photo thumbnail shows a message like *"Unable to open photo"*.

**Fixes:**

- Check that the file still exists at its original path. If you moved it after loading, Photo Locator cannot find it.
- Ensure your default image viewer is configured correctly in Windows default apps settings.
- Try opening the file directly from File Explorer to confirm the file is not corrupt.

---

## Rename Fails with an Error

**Symptoms:** After clicking Rename All, the result dialog reports errors.

**Common error messages and fixes:**

| Error | Cause | Fix |
|---|---|---|
| Access denied | File is locked or read-only | Close any other app using the file; remove the read-only attribute |
| File in use | Another application has the file open | Close other applications using the photo |
| Path too long | Renamed path exceeds Windows limit (260 chars) | Move photos to a shorter folder path before renaming |

---

## CSV File Does Not Open Automatically

**Symptoms:** Export completes but the CSV file does not open.

**Fixes:**

- Navigate manually to your Desktop — the file will be there.
- Set a default application for `.csv` files: **Settings → Apps → Default apps → Choose defaults by file type → .csv**.

---

## Duplicate Photos in the List

**Symptoms:** The same photo appears twice.

This should not normally happen. Photo Locator checks for duplicate file paths before adding. If you see duplicates, try:

1. Closing and restarting the application.
2. Loading photos fresh from a single Open dialog rather than multiple dialogs.

---

## Getting More Help

If you encounter an issue not covered here, please [open an issue on GitHub](https://github.com/mzbrau/photo-locator/issues) with:

- A description of the problem
- Steps to reproduce it
- Your Windows version and .NET Framework version
- Any error messages shown
