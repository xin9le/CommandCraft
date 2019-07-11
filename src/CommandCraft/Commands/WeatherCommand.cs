using System;



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
        /// 
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
        protected internal override string Build()
        {
            var weather = this.Weather switch
            {
                Weather.Clear => "clear",
                Weather.Rain => "rain",
                Weather.Thunder => "thunder",
                _ => throw new InvalidOperationException(),
            };
            return this.Duration.HasValue
                ? $"/weather {weather} {this.Duration.Value}"
                : $"/weather {weather}";
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
