using System;



namespace CommandCraft.Commands
{
    /// <summary>
    /// Provides '/gamemode' command. 
    /// </summary>
    public sealed class GameModeCommand : MinecraftCommand
    {
        #region Properties
        private GameMode Mode { get; }
        private string Player { get; }
        private TargetSelector Selector { get; }
        #endregion


        #region Constructors
        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="mode"></param>
        public GameModeCommand(GameMode mode)
            => this.Mode = mode;


        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="playerName"></param>
        public GameModeCommand(GameMode mode, string playerName)
            : this(mode)
            => this.Player = playerName ?? throw new ArgumentNullException(nameof(playerName));


        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="selector"></param>
        public GameModeCommand(GameMode mode, TargetSelector selector)
            => this.Selector = selector ?? throw new ArgumentNullException(nameof(selector));
        #endregion


        #region Overrides
        /// <summary>
        /// Build command string.
        /// </summary>
        /// <returns></returns>
        protected override string Build()
        {
            var mode = (int)this.Mode;
            var selector = this.Player ?? this.Selector?.Build();
            return selector == null
                ? $"/gamemode {mode}"
                : $"/gamemode {mode} {selector}";
        }
        #endregion
    }



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
}
