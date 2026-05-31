---
id: configuration
title: Configuration
sidebar_label: Configuration
sidebar_position: 4
description: How to obtain and configure a Bing Maps API key for use with Photo Locator.
---

# Configuration

Photo Locator relies on the **Bing Maps API** for two things:

1. **Displaying the interactive map** — the map tiles and navigation controls
2. **Reverse geocoding** — converting GPS coordinates into human-readable street addresses

You need a free Bing Maps API key to use these features.

## Obtaining a Free Bing Maps Key

A Bing Maps API key is free for personal, non-commercial use (up to 125,000 transactions per year).

Follow these steps to get your key:

1. **Sign in to Bing Maps Dev Center**
   Visit [https://www.bingmapsportal.com](https://www.bingmapsportal.com) and sign in with a Microsoft account (Outlook, Hotmail, or any Microsoft account).

2. **Create an account if needed**
   If you do not have a Bing Maps Dev Center account, click **Create** and fill in the registration form.

3. **Create a new key**
   - In the top navigation, click **My Account → My Keys**.
   - Click **Create a new key**.
   - Fill in the form:
     | Field | Recommended value |
     |---|---|
     | **Application name** | Photo Locator |
     | **Application URL** | *(leave blank or enter your PC name)* |
     | **Key type** | Basic |
     | **Application type** | Public Website |
   - Click **Create**.

4. **Copy your key**
   Your new API key will appear in the key list. Copy the key string — it looks like a long alphanumeric sequence, e.g.:
   ```
   AbCdEfGhIjKlMnOpQrStUvWxYz1234567890AbCdEfGhIjKl
   ```

:::info Official Docs
For full details, see the [Microsoft documentation on obtaining a Bing Maps key](https://docs.microsoft.com/en-us/bingmaps/getting-started/bing-maps-dev-center-help/getting-a-bing-maps-key).
:::

## Entering the Key in Photo Locator

### On First Launch

When Photo Locator detects that no key has been saved, it opens the **Settings** dialog automatically. Paste your key into the **Bing Maps Key** field and click **OK**.

### Changing the Key Later

1. Open Photo Locator.
2. Click the **Settings** button (gear icon) in the toolbar.
3. Update the **Bing Maps Key** field.
4. Click **OK** — the key is saved immediately and takes effect without restarting.

## Where is the Key Stored?

The API key is stored in the Windows application settings file, managed by the .NET settings system. It is saved to:

```
%LOCALAPPDATA%\PhotoLocator\PhotoLocator.exe_Url_...\<version>\user.config
```

The key persists across application restarts and upgrades automatically.

## Troubleshooting the Key

| Symptom | Likely cause | Fix |
|---|---|---|
| Map is blank / grey | Key not entered or invalid | Open Settings and re-enter the key |
| Addresses show "No Address Found" | Key has exceeded rate limits | Wait and retry, or create a new key |
| Map loads but no pins | Photos have no GPS metadata | See [Troubleshooting](./troubleshooting) |

:::warning
Do not share your Bing Maps API key publicly. If you publish your key, others may exhaust your quota.
:::
