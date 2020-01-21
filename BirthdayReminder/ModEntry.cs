using System;
using StardewModdingAPI;
using StardewValley;

namespace BirthdayReminder
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.DayStarted += this.OnDayStarted;
        }

        /*********
        ** Private methods
        *********/
        /// <summary>The method invoked when a new day starts.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnDayStarted(object sender, EventArgs e)
        {
            if (Utility.getTodaysBirthdayNPC(Game1.currentSeason, Game1.dayOfMonth) != null)
            {
                NPC bdayNPC = Utility.getTodaysBirthdayNPC(Game1.currentSeason, Game1.dayOfMonth);
                string bdayMsg = "Today's birthday: " + bdayNPC.Name;
                Game1.addHUDMessage(new HUDMessage(bdayMsg, 2));
            }
        }
    }
}