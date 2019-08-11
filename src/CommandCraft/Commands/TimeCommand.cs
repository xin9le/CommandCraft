using System;
using System.Text;



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
        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="amount"></param>
        public TimeSetCommand(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            this.Amount = amount;
        }


        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="time"></param>
        public TimeSetCommand(SpecificTime time)
            : this((int)time)
        {}
        #endregion


        #region Overrides
        /// <summary>
        /// Build command string.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="environment"></param>
        protected override void Build(StringBuilder builder, MinecraftEnvironment environment)
        {
            builder.Append("/time set ");
            builder.Append(this.Amount);
        }
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
