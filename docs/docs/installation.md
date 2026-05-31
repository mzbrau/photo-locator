---
id: installation
title: Installation
sidebar_label: Installation
sidebar_position: 3
description: Step-by-step instructions for installing Photo Locator on Windows using the MSI installer.
---

# Installation

Photo Locator is distributed as a standard Windows Installer (`.msi`) package. Installation takes less than a minute.

## Prerequisites

Before installing, ensure your system meets the following requirements:

| Requirement | Details |
|---|---|
| **OS** | Windows 10 or Windows 11 |
| **.NET Framework** | 4.x — included with Windows 10/11 by default |
| **Disk space** | ~10 MB |
| **Internet** | Required at runtime for map display and address lookup |

## Download

Download the installer from the GitHub repository:

➡️ **[Photo Locator v1.0 — Photo Locator.msi](https://github.com/mzbrau/photo-locator/raw/master/Releases/1.0/Photo%20Locator.msi)**

## Installation Steps

1. **Run the installer**
   Double-click the downloaded `Photo Locator.msi` file.

2. **User Account Control prompt**
   If Windows asks *"Do you want to allow this app to make changes to your device?"*, click **Yes**.

3. **Welcome screen**
   Click **Next** to proceed through the installation wizard.

4. **Choose installation folder**
   The default location is `C:\Program Files\Photo Locator\`. You can change this if needed, then click **Next**.

5. **Confirm installation**
   Click **Install** to begin copying files.

6. **Finish**
   Click **Finish** when installation completes. A desktop shortcut and Start Menu entry are created automatically.

## First Launch

When you first launch Photo Locator, the **Settings** dialog opens automatically because no Bing Maps API key has been configured yet.

See [Configuration](./configuration) for instructions on getting a free key.

## Uninstalling

To uninstall Photo Locator:

1. Open **Settings → Apps → Installed apps** (Windows 11) or **Control Panel → Programs and Features** (Windows 10).
2. Find **Photo Locator** in the list.
3. Click **Uninstall** and follow the prompts.

:::note
User settings (including your Bing Maps key) are stored in the Windows registry under `HKEY_CURRENT_USER`. These are **not** removed automatically during uninstall. To remove them, you can delete the key at:
```
HKEY_CURRENT_USER\Software\PhotoLocator
```
:::

## Upgrading

To upgrade to a newer version:

1. Download the latest installer.
2. Run it — the installer will detect the existing installation and update it in place.
3. Your settings are preserved automatically.
