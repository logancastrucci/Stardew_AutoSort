**AutoSort** is a [Stardew Valley](http://stardewvalley.net/) mod
which automatically sorts your player's inventory and chests.

-----

## Install

The mod is currently in active development and has not yet
been released. Upon release, you can check for the latest
version to download from [Nexus Mods](http://www.nexusmods.com).

### Install in-progress mod (discouraged)

While downloading this mod pre-release is discouraged, you may
do so by downloading the code from GitHub and saving it to
your [Stardew Valley mods directory](
https://stardewvalleywiki.com/Modding:Player\_Guide/Getting\_Started
\#Find\_your\_game\_folder).

-----

## Use

### For players

#### Enabling and disabling the mod

You can toggle this mod on or off at any point by pressing
the toggle keys (`Left Shift + K`). Upon startup, the mod
will be disabled by default. You must enable AutoSort during
gameplay to use the features of this game.

##### Customizing the toggle key

#### Features

##### When enabling the feature

Upon enabling the feature, all items in your inventory and
chests will be sorted based on the logic specified below.

##### When adding new items

While the mod is enabled, any items added to your chests or
inventory will be added in sorted order, instead of the
default game logic (which adds new items to the first open
slot). Items will be sorted based on the logic specified
below.

##### Sorting Order

This mod will sort your inventory and chest items based on
the following logic:

  * First, group and sort items by category
  * Then, sort items by their unique in-game ID
  * Then, prefer higher-quality items (iridium, then gold,
    then silver, then normal)
  * Lastly, prefer larger stacks over smaller stacks

### For mod authors

See the [author guide](https://www.google.com/search?q=author-guide.md) for more info.

-----

### Limitations and future improvements

  * **Single Player Only**: This mod has not yet been tested with
    multiplayer games. Multiplayer support is planned as a future
    feature.
  * **No Sorting Customization**: Only the default sorting
    algorithm is currently available. Custom sorting logic is
    planned as a future feature.
  * **Chests and Inventory Only**: This mod currently only
    sorts items stored in chests and inventory. Other in-game
    storage (like refrigerators) are unaffected.