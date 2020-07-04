using System;
using BirthdayReminder.Framework;
using StardewModdingAPI;
using StardewValley;

namespace BirthdayReminder
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        /*********
        ** Fields
        *********/
        /// <summary>The mod configuration.</summary>
        private ModConfig Config;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            Config = this.Helper.ReadConfig<ModConfig>();

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

            // Check for today's birthday
            if (Config.ShowBirthdayToday)
            {
                NPC bdayNPC = Utility.getTodaysBirthdayNPC(Game1.currentSeason, Game1.dayOfMonth);
                if (bdayNPC != null)
                {
                    bdayNPC = Utility.getTodaysBirthdayNPC(Game1.currentSeason, Game1.dayOfMonth);
                    string bdayMsg = Helper.Translation.Get("bday-today") + bdayNPC.getName();
                    Game1.addHUDMessage(new HUDMessage(bdayMsg, 2));
                }
            }

            // Check for tomorrow's birthday
            if (Config.ShowBirthdayTomorrow)
            {
                NPC bdayTomorrowNPC;

                // Tomorrow could be in another season. We have to take this into account.
                if (Game1.dayOfMonth <= 27)
                    bdayTomorrowNPC = Utility.getTodaysBirthdayNPC(Game1.currentSeason, Game1.dayOfMonth + 1);
                else
                {
                    string nextSeason = Game1.currentSeason;
                    switch (Game1.currentSeason)
                    {
                        case "spring":
                            nextSeason = "summer";
                            break;
                        case "summer":
                            nextSeason = "fall";
                            break;
                        case "fall":
                            nextSeason = "winter";
                            break;
                        case "winter":
                            nextSeason = "spring";
                            break;
                    }
                    bdayTomorrowNPC = Utility.getTodaysBirthdayNPC(nextSeason, 1);
                }

                if (bdayTomorrowNPC != null)
                {
                    string bdayTomorrowMsg = Helper.Translation.Get("bday-tomorrow") + bdayTomorrowNPC.getName();
                    Game1.addHUDMessage(new HUDMessage(bdayTomorrowMsg, 2));
                }
            }
        }
    }
}