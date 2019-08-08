using System;



namespace CommandCraft.Commands
{
    /// <summary>
    /// Target selector variables
    /// </summary>
    public enum TargetAt
    {
        /// <summary>
        /// @a : All players
        /// </summary>
        A,

        /// <summary>
        /// @c : Your agent [Education Edition Only]
        /// </summary>
        C,

        /// <summary>
        /// @e : All entities
        /// </summary>
        E,

        /// <summary>
        /// @p : Nearest player
        /// </summary>
        P,

        /// <summary>
        /// @r : Random player
        /// </summary>
        R,

        /// <summary>
        /// @s : The entity executing the command
        /// </summary>
        S,

        /// <summary>
        /// @v : All agents [Education Edition Only]
        /// </summary>
        V,
    }



    /// <summary>
    /// Provides extension methods for <see cref="TargetAt"/>.
    /// </summary>
    internal static class TargetAtExtensions
    {
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="at"></param>
        /// <returns></returns>
        public static string ToCommandString(this TargetAt at)
            => at switch
            {
                TargetAt.A => "@a",
                TargetAt.C => "@c",
                TargetAt.E => "@e",
                TargetAt.P => "@p",
                TargetAt.R => "@r",
                TargetAt.S => "@s",
                TargetAt.V => "@v",
                _ => throw new ArgumentOutOfRangeException(nameof(at)),
            };
    }
}
