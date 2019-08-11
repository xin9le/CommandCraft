using System.Text;



namespace CommandCraft.Commands
{
    /// <summary>
    /// Provides filter of <see cref="TargetSelector"/>.
    /// </summary>
    public abstract class TargetFilter
    {
        /// <summary>
        /// Build command string.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="environment"></param>
        internal protected abstract void Build(StringBuilder builder, MinecraftEnvironment environment);
    }
}
