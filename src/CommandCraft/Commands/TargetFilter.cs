namespace CommandCraft.Commands
{
    /// <summary>
    /// Provides filter of <see cref="TargetSelector"/>.
    /// </summary>
    public abstract class TargetFilter
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
