using System;
using System.Text;



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
            : this(mode)
            => this.Selector = selector ?? throw new ArgumentNullException(nameof(selector));
        #endregion


        #region Overrides
        protected override void Build(StringBuilder builder, MinecraftEnvironment environment)
        {
            var mode = (int)this.Mode;
            builder.Append("/gamemode ");
            builder.Append(mode);
            if (this.Player != null)
            {
                builder.Append(' ');
                builder.Append(this.Player);
            }
            else if (this.Selector != null)
            {
                builder.Append(' ');
                this.Selector.Build(builder, environment);
            }
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
