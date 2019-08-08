namespace CommandCraft.Commands
{
    /// <summary>
    /// Represents absolute or relative position.
    /// </summary>
    public readonly struct Position
    {
        #region Properties
        private double Value { get; }
        private bool IsRelative { get; }
        #endregion


        #region Constructors
        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="value">Position value</param>
        /// <param name="isRelative">If true, relative. If false, absolute.</param>
        public Position(double value, bool isRelative = false)
        {
            this.Value = value;
            this.IsRelative = isRelative;
        }
        #endregion


        #region Overrides
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => this.Build();
        #endregion


        #region Operators
        /// <summary>
        /// Converts to <see cref="Position"/> from <seealso cref="double"/> implicitly.
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Position(double value)
            => new Position(value);
        #endregion


        #region Build
        /// <summary>
        /// Build command string.
        /// </summary>
        /// <returns></returns>
        internal string Build()
            => this.IsRelative ? $"^{this.Value}" : this.Value.ToString();
        #endregion
    }
}
