using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.ScriptExecutor.AST.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public enum Associativity
    {
        Undefined,
        Right,
        Left
    }

    public enum ClassOfNode
    {
        Undefined
    }

    public class InternalCodeExpressionNode : IToStringData
    {
        public InternalCodeExpressionNode Parent = null;
        public ExpressionKind Kind { get; set; } = ExpressionKind.Undefined;
        public ulong TypeKey = 0;
        public InternalCodeExpressionNode Left = null;
        public InternalCodeExpressionNode Right = null;
        public List<InternalCodeExpressionNode> Params = null;
        public InternalCodeExpressionNode CalledMember = null;
        public object Value = null;
        public int Priority = 0;
        public ClassOfNode ClassOfNode = ClassOfNode.Undefined;
        //public Associativity Associativity = Associativity.Undefined;

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        /// <summary>
        /// Provides string data for method ToString.
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public string ToStringData()
        {
            return ToString(null, 0);
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="dataDictionary">An instance of the DataDictionary for human readable presentation.</param>
        /// <param name="indent">Indent for better formatting.</param>
        /// <returns>The string representation of this instance.</returns>
        public string ToString(IReadOnlyStorageDataDictionary dataDictionary, int indent)
        {
            var spacesString = _ObjectHelper.CreateSpaces(indent);
            var nextIndent = indent + 4;
            var tmpSb = new StringBuilder();

            if(dataDictionary != null)
            {
                tmpSb.AppendLine($"{spacesString}Begin InternalCodeExpressionNode");
            }

            tmpSb.AppendLine($"{spacesString}{nameof(Kind)} = {Kind}");
            tmpSb.AppendLine($"{spacesString}{nameof(TypeKey)} = {TypeKey}");
            if(dataDictionary != null)
            {
                tmpSb.AppendLine($"{spacesString}TypeName = {dataDictionary.GetValue(TypeKey)}");
            }
            tmpSb.AppendLine($"{spacesString}{nameof(Value)} = {Value}");
            tmpSb.AppendLine($"{spacesString}{nameof(Priority)} = {Priority}");            
            tmpSb.AppendLine($"{spacesString}{nameof(ClassOfNode)} = {ClassOfNode}");
            //tmpSb.AppendLine($"{spacesString}{nameof(Associativity)} = {Associativity}");

            if (Left == null)
            {
                tmpSb.AppendLine($"{spacesString}{nameof(Left)} = null");
            }
            else
            {
                tmpSb.AppendLine($"{spacesString}{nameof(Left)} =");
                tmpSb.AppendLine(Left.ToString(dataDictionary, nextIndent));
            }

            if (Right == null)
            {
                tmpSb.AppendLine($"{spacesString}{nameof(Right)} = null");
            }
            else
            {
                tmpSb.AppendLine($"{spacesString}{nameof(Right)} =");
                tmpSb.AppendLine(Right.ToString(dataDictionary, nextIndent));
            }

            if (CalledMember == null)
            {
                tmpSb.AppendLine($"{spacesString}{nameof(CalledMember)} = null");
            }
            else
            {
                tmpSb.AppendLine($"{spacesString}{nameof(CalledMember)} =");
                tmpSb.AppendLine(CalledMember.ToString(dataDictionary, nextIndent));
            }

            if (Params == null)
            {
                tmpSb.AppendLine($"{spacesString}{nameof(Params)} = null");
            }
            else
            {
                tmpSb.AppendLine($"{spacesString}Begin {nameof(Params)}");
                foreach(var item in Params)
                {
                    tmpSb.AppendLine(item.ToString(dataDictionary, nextIndent));
                }
                tmpSb.AppendLine($"{spacesString}End {nameof(Params)}");
            }

            if (dataDictionary != null)
            {
                tmpSb.AppendLine($"{spacesString}End InternalCodeExpressionNode");
            }

            return tmpSb.ToString();
        }
    }
}
