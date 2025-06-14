using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Inventories;
using System;

namespace AutoSort
{
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry : Mod
    {

        /*********
        ** Properties
        *********/
        /// <summary>The mod configuration from the player.</summary>
        private ModConfig Config;

        /// <summary>Whether or not auto sort is active</summary>
        private bool isAutoSortEnabled;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.Player.InventoryChanged += this.OnInventoryChanged;
            helper.Events.World.ChestInventoryChanged += this.OnChestInventoryChanged;
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;

            this.Config = this.Helper.ReadConfig<ModConfig>();
            this.isAutoSortEnabled = false;
        }


        /*********
        ** Private methods
        *********/
        private void OnButtonPressed(object? sender, ButtonPressedEventArgs e)
        {
            if (this.Config.ToggleKey.JustPressed())
            {
                this.Monitor.Log($"isAutoSortEnabled toggled to {this.isAutoSortEnabled}", LogLevel.Debug);
                this.isAutoSortEnabled = !this.isAutoSortEnabled;
            }
        }

        private void OnChestInventoryChanged(object? sender, ChestInventoryChangedEventArgs e)
        {
            if (this.isAutoSortEnabled)
            {
                // if add, insert in sorted order
                if (e.Added != null && e.Added.Count() > 0)
                {
                    this.Monitor.Log($"{Game1.player.Name} added to chest inventory, sorting", LogLevel.Debug);
                    List<Item> sortedChestItems = SortItems(e.Chest.Items.ToList());
                    for (int i = 0; i < e.Chest.Items.Count; i++)
                    {
                        e.Chest.Items[i] = null; // Clear each slot
                    }
                    for (int i = 0; i < sortedChestItems.Count; i++)
                    {
                        e.Chest.Items[i] = sortedChestItems[i]; // Set each slot
                    }
                }
                else
                {
                    this.Monitor.Log($"{Game1.player.Name} changed inventory of chest {e.Chest}, but didn't add anything.", LogLevel.Debug);
                }
            }
            else
            {
                this.Monitor.Log($"{Game1.player.Name} changed chest inventory of chest {e.Chest}, but auto sort is disabled", LogLevel.Debug);
            }
        }

        private void OnInventoryChanged(object? sender, InventoryChangedEventArgs e)
        {
            if (this.isAutoSortEnabled)
            {
                // if add, insert in sorted order
                if (e.Added != null && e.Added.Count() > 0)
                {
                    this.Monitor.Log($"{Game1.player.Name} added to inventory, sorting", LogLevel.Debug);
                    List<Item> sortedInventory = SortItems(Game1.player.Items.ToList());
                    for (int i = 0; i < Game1.player.Items.Count; i++)
                    {
                        Game1.player.Items[i] = null; // Clear each slot
                    }
                    for (int i = 0; i < sortedInventory.Count; i++)
                    {
                        Game1.player.Items[i] = sortedInventory[i]; // Set each slot
                    }
                }
                else
                {
                    this.Monitor.Log($"{Game1.player.Name} changed inventory, but didn't add anything.", LogLevel.Debug);
                }
            }
            else
            {
                this.Monitor.Log($"{Game1.player.Name} changed inventory, but auto sort is disabled", LogLevel.Debug);
            }
        }

        /// <summary>Sorts the current player's inventory.</summary>
        private List<Item> SortItems(List<Item> items)
        {
            // 1. Filter out null (empty) slots and create a temporary list of actual items.
            var actualItems = items.Where(item => item != null).ToList();

            // 2. Define sorting criteria.
            var sortedItems = actualItems
                .OrderBy(item => item.Category) // Primary sort: By category
                .ThenBy(item => item.ParentSheetIndex) // Secondary sort: By item ID
                .ThenByDescending(item => item.Quality) // Tertiary sort: By quality (Iridium, Gold, Silver, None)
                .ThenByDescending(item => item.Stack)   // Quaternary sort: By stack size (full stacks before partial)
                .ToList();

            return sortedItems;
        }
    }
}