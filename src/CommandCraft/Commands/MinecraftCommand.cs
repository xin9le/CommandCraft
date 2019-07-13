namespace CommandCraft.Commands
{
    /// <summary>
    /// Represents basis of Minecraft command.
    /// </summary>
    /// <remarks>https://minecraft.gamepedia.com/Commands</remarks>
    public abstract class MinecraftCommand
    {
        #region Properties
        /// <summary>
        /// Gets built command string.
        /// </summary>
        internal string BuiltString
            => this.builtString ??= this.Build();
        private string builtString;
        #endregion


        #region Abstracts
        /// <summary>
        /// Build command string.
        /// </summary>
        /// <returns></returns>
        protected abstract string Build();
        #endregion


        #region Overrides
        /// <summary>
        /// Convert to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => this.BuiltString;
        #endregion
    }
}
