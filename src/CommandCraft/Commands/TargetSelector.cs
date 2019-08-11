using System;
using System.Collections.Generic;
using System.Text;



namespace CommandCraft.Commands
{
    /// <summary>
    /// Provides target selection for <see cref="MinecraftCommand"/>.
    /// </summary>
    public sealed class TargetSelector
    {
        #region Properties
        private TargetAt At { get; }
        private IReadOnlyCollection<TargetFilter> Filters { get; }
        #endregion


        #region Constructors
        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="at">Target at</param>
        /// <param name="filters">Target filtering condition</param>
        public TargetSelector(TargetAt at, params TargetFilter[] filters)
            : this(at, filters as IReadOnlyCollection<TargetFilter>)
        {}


        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="at">Target at</param>
        /// <param name="filters">Target filtering condition</param>
        public TargetSelector(TargetAt at, IReadOnlyCollection<TargetFilter> filters)
        {
            this.At = at;
            this.Filters = filters ?? throw new ArgumentNullException(nameof(filters));
        }
        #endregion


        #region Build
        /// <summary>
        /// Build command string.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="environment"></param>
        internal void Build(StringBuilder builder, MinecraftEnvironment environment)
        {
            var at = this.At.ToCommandString();
            builder.Append(at);
            if (this.Filters.Count <= 0)
                return;

            var isFirst = true;
            builder.Append('[');
            foreach (var x in this.Filters)
            {
                if (!isFirst)
                    builder.Append(',');

                x.Build(builder, environment);
                isFirst = false;
            }
            builder.Append(']');
        }
        #endregion
    }
}
