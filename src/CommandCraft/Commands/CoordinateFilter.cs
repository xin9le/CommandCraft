using System;



namespace CommandCraft.Commands
{
    /// <summary>
    /// Provides coordinate filter.
    /// </summary>
    public abstract class CoordinateFilter : TargetFilter
    {
        #region Properties
        private Axis Axis { get; }
        private Position Position { get; }
        #endregion


        #region Constructors
        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="position"></param>
        private protected CoordinateFilter(Axis axis, Position position)
        {
            this.Axis = axis;
            this.Position = position;
        }
        #endregion


        #region Overrides
        /// <summary>
        /// Build command string.
        /// </summary>
        /// <returns></returns>
        protected override string Build()
        {
            var axis = this.Axis switch
            {
                Axis.X => 'x',
                Axis.Y => 'y',
                Axis.Z => 'z',
                _ => throw new InvalidOperationException(),
            };
            return $"{axis}={this.Position.Build()}";
        }
        #endregion
    }



    /// <summary>
    /// Provides X coordinate filter.
    /// </summary>
    public sealed class XFilter : CoordinateFilter
    {
        #region Constructors
        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="value">Position value</param>
        /// <param name="isRelative">If true, relative. If false, absolute.</param>
        public XFilter(double value, bool isRelative = false)
            : base(Axis.X, new Position(value, isRelative))
        { }


        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="position"></param>
        public XFilter(Position position)
            : base(Axis.X, position)
        { }
        #endregion
    }



    /// <summary>
    /// Provides Y coordinate filter.
    /// </summary>
    public sealed class YFilter : CoordinateFilter
    {
        #region Constructors
        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="value">Position value</param>
        /// <param name="isRelative">If true, relative. If false, absolute.</param>
        public YFilter(double value, bool isRelative = false)
            : base(Axis.Y, new Position(value, isRelative))
        { }


        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="position"></param>
        public YFilter(Position position)
            : base(Axis.Y, position)
        { }
        #endregion
    }



    /// <summary>
    /// Provides Z coordinate filter.
    /// </summary>
    public sealed class ZFilter : CoordinateFilter
    {
        #region Constructors
        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="value">Position value</param>
        /// <param name="isRelative">If true, relative. If false, absolute.</param>
        public ZFilter(double value, bool isRelative = false)
            : base(Axis.Z, new Position(value, isRelative))
        { }


        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="position"></param>
        public ZFilter(Position position)
            : base(Axis.Z, position)
        { }
        #endregion
    }



    /// <summary>
    /// Represents coordinate axis.
    /// </summary>
    internal enum Axis
    {
        X = 0,
        Y,
        Z,
    }
}
