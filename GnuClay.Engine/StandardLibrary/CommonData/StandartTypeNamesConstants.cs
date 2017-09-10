using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.CommonData
{
    public class StandartTypeNamesConstants
    {
        #region names of types
        public const string UniversalTypeName = "⊤";
        public const string UndefinedTypeMame = "undefined";
        public const string NullTypeName = "null";
        public const string NumberName = "number";
        public const string Boolean = "boolean";
        public const string ArrayName = "array";
        public const string IteratorName = "iterator";
        public const string PropertyName = "__property";
        public const string LogicalPropertyName = "_logical property";
        public const string PropertyActionName = "__property action";
        public const string PropertyResultName = "_property result";
        public const string PropertyResultIteratorName = "_property result iterator";
        public const string LogicalRuleName = "logical rule";
        public const string FactName = "fact";
        public const string SelfName = "self";
        public const string EntityActionTypeName = "__entity action";
        public const string ErrorTypeName = "error";
        public const string UncaughtReferenceErrorTypeName = "Uncaught Reference Error";
        #endregion

        #region names of assing operators
        public const string AssignOperatorName = "=";
        public const string PlusAssingOperatorName = "+=";
        public const string MinusAssingOperatorName = "-=";
        public const string MulAssingOperatorName = "*=";
        public const string DivAssingOperatorName = "/=";
        public const string AssingFactOperatorName = "<<";
        public const string PlusAssingFactOperatorName = "+<<";
        #endregion

        #region names of arithmetic operators
        public const string AddOperatorName = "+";
        public const string SubOperatorName = "-";
        public const string MulOperatorName = "*";
        public const string DivOperatorName = "/";
        #endregion

        #region names of logical operators
        public const string EqualOperatorName = "==";
        public const string NotEqualOperatorName = "!=";
        public const string MoreOperatorName = ">";
        public const string LessOperatorName = "<";
        public const string AndOperatorName = "&";
        public const string OrOperatorName = "|";
        public const string MoreOrEqualOperatorName = ">=";
        public const string LessOrEqualOperatorName = "<=";
        #endregion

        #region names of common operators
        public const string PointOperatorName = ".";
        #endregion

        #region names of standard variables
        public const string FirstParamName = "$param1";
        public const string SecondParamName = "$param2";
        #endregion
    }
}
