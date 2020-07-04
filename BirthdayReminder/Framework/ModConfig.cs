namespace BirthdayReminder.Framework
{
    internal class ModConfig
    {
        /*********
        ** Accessors
        *********/
        /// <summary>Whether to show birthday reminders for the current day.</summary>
        public bool ShowBirthdayToday { get; set; } = true;

        /// <summary>Whether to show birthday reminders for the next day.</summary>
        public bool ShowBirthdayTomorrow { get; set; } = true;
    }
}
