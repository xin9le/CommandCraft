using System;
using System.Text;



namespace CommandCraft.Commands
{
    /// <summary>
    /// Provides '/weather' command. 
    /// </summary>
    public sealed class WeatherCommand : MinecraftCommand
    {
        #region Properties
        private Weather Weather { get; }
        private int? Duration { get; }
        #endregion


        #region Constructors
        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="weather"></param>
        /// <param name="duration">duration [sec]</param>
        public WeatherCommand(Weather weather, int? duration = null)
        {
            if (duration < 1 || 1000000 < duration)
                throw new ArgumentOutOfRangeException(nameof(duration));

            this.Weather = weather;
            this.Duration = duration;
        }
        #endregion


        #region Overrides
        /// <summary>
        /// Build command string.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="environment"></param>
        protected override void Build(StringBuilder builder, MinecraftEnvironment environment)
        {
            var weather = this.Weather switch
            {
                Weather.Clear => "clear",
                Weather.Rain => "rain",
                Weather.Thunder => "thunder",
                _ => throw new InvalidOperationException(),
            };

            builder.Append("/weather ");
            builder.Append(weather);
            if (this.Duration.HasValue)
            {
                builder.Append(' ');
                builder.Append(this.Duration.Value);
            }
        }
        #endregion
    }



    /// <summary>
    /// Represents defined weather.
    /// </summary>
    public enum Weather
    {
        Clear = 0,
        Rain,
        Thunder,
    }
}
