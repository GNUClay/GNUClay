namespace GnuClay.CommonClientTypes
{
    /// <summary>
    /// The kind of some expression node.
    /// </summary>
    public enum ExpressionNodeKind
    {
        /// <summary>
        /// Represents default value.
        /// </summary>
        Unknown,

        /// <summary>
        /// Represents `And` node.
        /// </summary>
        And,

        /// <summary>
        /// Represents `Or` node.
        /// </summary>
        Or,

        /// <summary>
        /// Represents `Not` node.
        /// </summary>
        Not,

        /// <summary>
        /// Represents some relation.
        /// </summary>
        Relation,

        /// <summary>
        /// Represents some entity.
        /// </summary>
        Entity,

        /// <summary>
        /// Represents some variable.
        /// </summary>
        Var,

        /// <summary>
        /// Represents some value.
        /// </summary>
        Value,

        /// <summary>
        /// Represents reference to a fact.
        /// </summary>
        Fact
    }
}