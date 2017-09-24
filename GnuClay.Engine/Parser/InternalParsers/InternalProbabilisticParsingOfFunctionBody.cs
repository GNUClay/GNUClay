using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.ScriptExecutor.AST.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public delegate ASTStatement TryParse(InternalParserContext context);

    public class InternalProbabilisticParsingOfFunctionBody
    {
        private class ResultOfProbabilisticParsing
        {
            public bool IsSuccess;
            public ASTStatement Result;
            public Exception Exception;
            public InternalParserContext Context;

            /// <summary>
            /// Provides string data for method ToString.
            /// </summary>
            /// <returns>The string representation of this instance.</returns>
            public override string ToString()
            {
                return ToString(null, 0);
            }

            /// <summary>
            /// Converts the value of this instance to its equivalent string representation.
            /// </summary>
            /// <param name="dataDictionary">An instance of the DataDictionary for human readable presentation.</param>
            /// <param name="indent">Indent for better formatting.</param>
            /// <returns>The string representation of this instance.</returns>
            public virtual string ToString(IReadOnlyStorageDataDictionary dataDictionary, int indent)
            {
                var spacesString = _ObjectHelper.CreateSpaces(indent);
                var nextIndent = indent + 4;
                var sb = new StringBuilder();
                sb.AppendLine($"{spacesString}Begin ResultOfProbabilisticParsing");
                sb.AppendLine($"{spacesString}{nameof(IsSuccess)} = {IsSuccess}");
                sb.AppendLine($"{spacesString}Context.Count = {Context?.Count}");
                sb.AppendLine($"{spacesString}{nameof(Exception)} = {Exception}");
                if (Result == null)
                {
                    sb.AppendLine($"{spacesString}{nameof(Result)} = null");
                }
                else
                {
                    sb.AppendLine($"{spacesString}{nameof(Result)} =");
                    sb.AppendLine(Result.ToString(dataDictionary, nextIndent));
                }
                sb.AppendLine($"{spacesString}End ResultOfProbabilisticParsing");
                return sb.ToString();
            }
        }

        public InternalProbabilisticParsingOfFunctionBody(InternalFunctionBodyParser sourceParser)
        {
            mSourceParser = sourceParser;
            mDataDictionary = sourceParser.MainContext.DataDictionary;
        }

        private StorageDataDictionary mDataDictionary = null;
        private InternalFunctionBodyParser mSourceParser;
        private List<TryParse> mBranches = new List<TryParse>();

        public ASTStatement Result;

        public void AddBranch(TryParse handler)
        {
            mBranches.Add(handler);
        }

        public void Run()
        {
            Result = null;

            var tmpSuccessList = new List<ResultOfProbabilisticParsing>();
            var tmpFailedList = new List<ResultOfProbabilisticParsing>();

            foreach (var branch in mBranches)
            {
                var context = mSourceParser.ForkContext();

                var item = new ResultOfProbabilisticParsing();
                item.Context = context;

                try
                {
                    var tmpResult = branch(context);
                    item.IsSuccess = true;
                    item.Result = tmpResult;
                    tmpSuccessList.Add(item);
                }
                catch(Exception e)
                {
                    item.Exception = e;
                    tmpFailedList.Add(item);
                }
            }

            switch(tmpSuccessList.Count)
            {
                case 0:
                    {
                        var minCountOfCharasters = tmpFailedList.Min(p => p.Context.Count);
                        var targetItem = tmpFailedList.FirstOrDefault(p => p.Context.Count == minCountOfCharasters);
                        throw targetItem.Exception;
                    }

                case 1:
                    {
                        var targetItem = tmpSuccessList.First();
                        Result = targetItem.Result;
                        mSourceParser.AssingContext(targetItem.Context);
                    }
                    break;

                case 2:
                    {
                        var targetItem = tmpSuccessList.First();
                        Result = targetItem.Result;
                        mSourceParser.AssingContext(targetItem.Context);
                    }
                    break;

                default: throw new NotSupportedException();
            }
        }
    }
}
