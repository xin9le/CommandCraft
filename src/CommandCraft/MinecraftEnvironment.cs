namespace CommandCraft
{
    /// <summary>
    /// Represents runtime environment of Minecraft server.
    /// </summary>
    internal sealed class MinecraftEnvironment
    {
        #region Properties
        /// <summary>
        /// Gets edition.
        /// </summary>
        public MinecraftEdition Edition { get; }


        /// <summary>
        /// Gets version.
        /// </summary>
        public MinecraftVersion Version { get; }
        #endregion


        #region Constructors
        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="edition"></param>
        /// <param name="version"></param>
        public MinecraftEnvironment(MinecraftEdition edition, MinecraftVersion version)
        {
            this.Edition = edition;
            this.Version = version;
        }
        #endregion
    }
}
