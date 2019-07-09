namespace CommandCraft.Commands
{
    /// <summary>
    /// Represents basis of Minecraft command.
    /// </summary>
    public abstract class MinecraftCommand
    {
        /// <summary>
        /// Build command string.
        /// </summary>
        /// <returns></returns>
        protected internal abstract string Build();


        /// <summary>
        /// Convert to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => this.Build();
    }
}
