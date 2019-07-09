using System;



namespace CommandCraft.Commands
{
    /// <summary>
    /// Provides '/time set' command. 
    /// </summary>
    public sealed class TimeSetCommand : MinecraftCommand
    {
        #region Properties
        private int Amount { get; }
        #endregion


        #region Constructors
        public TimeSetCommand(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            this.Amount = amount;
        }


        public TimeSetCommand(SpecificTime time)
            : this((int)time)
        {}
        #endregion


        #region Overrides
        protected internal override string Build()
            => $"/time set {this.Amount}";
        #endregion
    }


    /// <summary>
    /// Represents specific time.
    /// </summary>
    public enum SpecificTime
    {
        Day = 1000,
        Noon = 6000,
        Night = 13000,
        Midnight = 18000,
        Sunset = 84000,
        Sunrise = 95000,
    }
}
