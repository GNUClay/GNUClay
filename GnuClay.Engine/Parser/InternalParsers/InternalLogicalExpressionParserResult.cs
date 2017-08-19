using GnuClay.Engine.LogicalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalLogicalExpressionParserResult
    {
        /// <summary>
        /// Target root node.
        /// </summary>
        public ExpressionNode RootNode = null;

        /// <summary>
        /// Links key and relation or entity this key represents in the rule (or fact).
        /// The key is same as in the field KeyOfReference in the instance of ExpressionNode.
        /// </summary>
        public Dictionary<ulong, ExpressionNode> LocalKeysOfReferencesIndexes = new Dictionary<ulong, ExpressionNode>();
    }
}
