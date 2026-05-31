---
id: filtering
title: Filtering
sidebar_label: Filtering
sidebar_position: 3
description: Use the filter bar to quickly narrow down photos by address or index number in Photo Locator.
---

# Filtering

Photo Locator includes a real-time filter that lets you narrow down the photo list to quickly find specific photos by address or index.

## Using the Filter Bar

The filter bar is located above the photo list. To filter:

1. Click the filter text box.
2. Start typing a search term.
3. The photo list updates instantly as you type — no need to press Enter.

To clear the filter, delete the text from the filter bar. All photos are shown again.

## What Can Be Searched

The filter matches against two fields:

| Field | Example | Case sensitive? |
|---|---|---|
| **Address** | `London`, `Main St`, `New York` | No — case-insensitive |
| **Index number** | `3`, `12` | N/A — numeric match |

:::tip
Filtering by index number is useful when you clicked a map pin and want to jump straight to the corresponding list entry.
:::

## How Filtering Works

The filter uses a `CollectionViewSource` filter applied to the photos collection. When you type in the filter bar:

1. The `FilterText` property is updated.
2. `PhotoSource.Refresh()` is called to re-evaluate all items.
3. Items that do not match are hidden (not removed) from the list.
4. The underlying `Photos` collection is not modified — clearing the filter restores all items.

## Examples

| You type | What is shown |
|---|---|
| `paris` | All photos with addresses containing "paris" (any case) |
| `2` | Photo #2 and any photo whose address contains the digit "2" |
| `baker street` | Photos with addresses containing "baker street" |
| *(empty)* | All photos |

## Filter and Map Interaction

The filter affects only the **photo list** — the map continues to show **all** push-pins regardless of the current filter. This is by design so you can find a photo in the list while keeping the full map context visible.

## Performance

The filter is designed for real-time use with typical photo collections (hundreds to a few thousand photos). It runs synchronously on the UI thread, so very large collections may cause a brief delay on each keystroke.
