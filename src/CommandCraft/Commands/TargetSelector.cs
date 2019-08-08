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
        private string BuiltString { get; set; }
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


        #region Abstracts
        /// <summary>
        /// Build target selector string.
        /// </summary>
        /// <returns></returns>
        internal string Build()
        {
            //--- If cache exists
            if (this.BuiltString != null)
                return this.BuiltString;

            //--- Calculate filters
            var at = this.At.ToCommandString();
            if (this.Filters.Count <= 0)
            {
                this.BuiltString = at;
            }
            else
            {
                var isFirst = true;
                var builder = new StringBuilder(at);
                builder.Append('[');
                foreach (var x in this.Filters)
                {
                    if (!isFirst)
                        builder.Append(',');
                    builder.Append(x.BuiltString);
                    isFirst = false;
                }
                builder.Append(']');
                this.BuiltString = builder.ToString();
            }
            return this.BuiltString;
        }
        #endregion


        #region Overrides
        /// <summary>
        /// Convert to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => this.Build();
        #endregion
    }
}
