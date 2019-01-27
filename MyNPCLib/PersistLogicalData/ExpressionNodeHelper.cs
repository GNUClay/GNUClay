using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.PersistLogicalData
{
    public static class ExpressionNodeHelper
    {
        public static bool Compare(BaseExpressionNode expressionNode1, BaseExpressionNode expressionNode2)
        {
#if DEBUG
            //LogInstance.Log($"(expressionNode1 == null) = {expressionNode1 == null} (expressionNode2 == null) = {expressionNode2 == null}");
#endif

            if (expressionNode1.IsBaseRef == expressionNode2.IsBaseRef)
            {
#if DEBUG
                //LogInstance.Log($"(expressionNode1.AsBaseRef == null) = {expressionNode1.AsBaseRef == null} (expressionNode2.AsBaseRef == null) = {expressionNode2.AsBaseRef == null}");
#endif

                if(expressionNode1.AsBaseRef == null || expressionNode2.AsBaseRef == null)
                {
                    return false;
                }

                if (expressionNode1.AsBaseRef.Key == expressionNode2.AsBaseRef.Key)
                {
                    return true;
                }

                return false;
            }

            if (expressionNode1.Kind == KindOfExpressionNode.Value && expressionNode2.Kind == KindOfExpressionNode.Value)
            {
#if DEBUG
                //LogInstance.Log($"(expressionNode1.AsValue == null) = {expressionNode1.AsValue == null} (expressionNode2.AsValue == null) = {expressionNode2.AsValue == null}");
#endif

                if (expressionNode1.AsValue.Value == expressionNode2.AsValue.Value)
                {
                    return true;
                }

                return true;
            }

            return true;
        }
    }
}
