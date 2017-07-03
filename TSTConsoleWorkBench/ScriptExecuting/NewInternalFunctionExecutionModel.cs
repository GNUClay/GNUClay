using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewInternalFunctionExecutionModel
    {
        public NewInternalFunctionExecutionModel(FunctionModel source)
        {
            mFunction = source;
        }

        private FunctionModel mFunction = null;

        public ScriptCommand FirstCommand
        {
            get
            {
                return mFunction.FirstCommand;
            }
        }

        public ScriptCommand this[int lineNumber]
        {
            get
            {
                return mFunction[lineNumber];
            }
        }

        public Stack<INewValue> ValuesStack { get; set; } = new Stack<INewValue>();

        public void BeginCall()
        {
            FunctionKey = null;
            Target = 0;
            IsCalledByNamedParameters = null;
            CurrentPositionOfParam = -1;
        }

        public INewValue FunctionKey { get; set; }
        public ulong Target { get; set; }

        private bool? mIsCalledByNamedParameters = null;
        public bool? IsCalledByNamedParameters
        {
            get
            {
                return mIsCalledByNamedParameters;
            }

            set
            {
                if(mIsCalledByNamedParameters == value)
                {
                    return;
                }

                mIsCalledByNamedParameters = value;

                if(mIsCalledByNamedParameters.HasValue)
                {
                    if(mIsCalledByNamedParameters.Value)
                    {
                        NamedParams = new List<NewNamedParamInfo>();
                    }
                    else
                    {
                        PositionedParams = new List<NewPositionParamInfo>();
                    }
                }
            }
        }

        public bool? IsSetParamName = false;
        public INewValue CurrentParamName { get; set; }
        public INewValue CurrentParamValue { get; set; }

        public List<NewNamedParamInfo> NamedParams { get; set; }
        public List<NewPositionParamInfo> PositionedParams { get; set; }
        public int CurrentPositionOfParam = -1;

        public void ProcessParam()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessParam");

            if(IsCalledByNamedParameters.Value)
            {
                var tmpNamedParamInfo = new NewNamedParamInfo();
                tmpNamedParamInfo.ParamName = CurrentParamName;
                tmpNamedParamInfo.ParamValue = CurrentParamValue;

                NamedParams.Add(tmpNamedParamInfo);

                return;
            }

            CurrentPositionOfParam++;

            var tmpPositiondedParamInfo = new NewPositionParamInfo();
            tmpPositiondedParamInfo.ParamValue = CurrentParamValue;
            tmpPositiondedParamInfo.Position = CurrentPositionOfParam;

            PositionedParams.Add(tmpPositiondedParamInfo);

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessParam");
        }

        public string ToDbgString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine("Begin ValuesStack");

            foreach (var val in ValuesStack)
            {
                tmpSb.AppendLine(val.ToString());
            }

            tmpSb.AppendLine("End ValuesStack");

            tmpSb.AppendLine($"{nameof(FunctionKey)} = {FunctionKey}");
            tmpSb.AppendLine($"{nameof(Target)} = {Target}");
            tmpSb.AppendLine($"{nameof(IsCalledByNamedParameters)} = {IsCalledByNamedParameters}");
            tmpSb.AppendLine($"{nameof(IsSetParamName)} = {IsSetParamName}");
            tmpSb.AppendLine($"{nameof(CurrentParamName)} = {CurrentParamName}");
            tmpSb.AppendLine($"{nameof(CurrentParamValue)} = {CurrentParamValue}");

            if(NamedParams == null)
            {
                tmpSb.AppendLine($"{nameof(NamedParams)} = null");
            }
            else
            {
                tmpSb.AppendLine($"Begin {nameof(NamedParams)}");

                foreach(var item in NamedParams)
                {
                    tmpSb.AppendLine($"item = {item}");
                }

                tmpSb.AppendLine($"End {nameof(NamedParams)}");
            }

            if(PositionedParams == null)
            {
                tmpSb.AppendLine($"{nameof(PositionedParams)} = null");
            }
            else
            {
                tmpSb.AppendLine($"Begin {nameof(PositionedParams)}");

                foreach (var item in PositionedParams)
                {
                    tmpSb.AppendLine($"item = {item}");
                }

                tmpSb.AppendLine($"End {nameof(PositionedParams)}");
            }

            tmpSb.AppendLine($"{nameof(CurrentPositionOfParam)} = {CurrentPositionOfParam}");
            
            return tmpSb.ToString();
        }
    }
}
