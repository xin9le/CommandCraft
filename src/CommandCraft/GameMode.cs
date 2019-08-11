using System;



namespace CommandCraft
{
    /// <summary>
    /// Represents game mode.
    /// </summary>
    public enum GameMode
    {
        Survival = 0,
        Creative = 1,
        Adventure = 2,
        Spectator = 3,
    }



    /// <summary>
    /// Provides extension methods for <see cref="GameMode"/>.
    /// </summary>
    internal static class TargetAtExtensions
    {
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static string ToCommandString(this GameMode mode)
            => mode switch
            {
                GameMode.Survival => "survival",
                GameMode.Creative => "creative",
                GameMode.Adventure => "adventure",
                GameMode.Spectator => "spectator",
                _ => throw new ArgumentOutOfRangeException(nameof(mode)),
            };
    }
}
