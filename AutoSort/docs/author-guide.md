Here's your README reformatted to a maximum of 80 characters per line:

This document is for mod authors who'd like their mods to
automatically configure AutoSort to sort items in custom
inventories or chests.

---

**For players, see the [main readme](README.md) instead.**

---

# About the Mod
## Inventory Sorting

The mod triggers inventory sorting under two conditions:

1. Toggling Autosort to `enabled` mode (`OnButtonPressed`).
2. Adding one or more items to the player's inventory
   (`OnInventoryChanged`).

### Toggling Autosort to `enabled`

The mod's logic to toggle it on or off utilizes Stardew Modding
API (SMAPI)'s `OnButtonPressed` event.

When SMAPI triggers `OnButtonPressed`, this mod checks if the
pressed button matches the configured toggle keys. If it is a
match, the mod toggles its auto-sort behavior.

### Adding items to inventory

## Chest Sorting

## Default Behavior
By default Autosave is `disabled` until toggled on, and the
default toggle key is `Left Shift + k`.

---

# Extending the Mod
## Enabling auto sort for custom item sets and chest types
As described above, this mod triggers auto sort behavior based on
the `OnChestInventoryChanged` and `OnInventoryChanged` events. As
long as your inventory and/or chest customizations are compatible
with those events, this mod will still apply to your custom
types.

If you encounter a bug or other issues with mod
inter-compatibility, please file a bug against this mod's GitHub
project.