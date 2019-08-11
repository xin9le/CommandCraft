using System.Text;



namespace CommandCraft.Commands
{
    /// <summary>
    /// Represents basis of Minecraft command.
    /// </summary>
    /// <remarks>https://minecraft.gamepedia.com/Commands</remarks>
    public abstract class MinecraftCommand
    {
        /// <summary>
        /// Build command string.
        /// </summary>
        /// <returns></returns>
        internal string Build(MinecraftEnvironment environment)
        {
            var builder = new StringBuilder();
            this.Build(builder, environment);
            return builder.ToString();
        }


        /// <summary>
        /// Build command string.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="environment"></param>
        protected abstract void Build(StringBuilder builder, MinecraftEnvironment environment);
    }
}
