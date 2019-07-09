namespace CommandCraft.Commands
{
    /// <summary>
    /// Represents Minecraft command basic interface.
    /// </summary>
    public interface IMinecraftCommand
    {
        /// <summary>
        /// Build command string.
        /// </summary>
        /// <returns></returns>
        string Build();
    }
}
