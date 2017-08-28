using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    [Serializable]
    public class FunctionModel : IToStringData
    {
        public ScriptCommand FirstCommand
        {
            get
            {
                return mFirstCommand;
            }
        }

        public void AddCommand(ScriptCommand cmd)
        {
            if (mFirstCommand == null)
            {
                mFirstCommand = cmd;
            }
            else
            {
                mLastCommand.Next = cmd;
            }
            mLastCommand = cmd;
            Commands.Add(cmd);
            mCount++;
            cmd.Position = mCount;
            LinesDict[mCount] = cmd;
        }

        public ScriptCommand this[int lineNumber]
        {
            get
            {
                return LinesDict[lineNumber];
            }
        }

        private List<ScriptCommand> Commands = new List<ScriptCommand>();

        private ScriptCommand mFirstCommand = null;

        private ScriptCommand mLastCommand = null;

        private int mCount = 0;

        private Dictionary<int, ScriptCommand> LinesDict = new Dictionary<int, ScriptCommand>();

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
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine(_ListHelper._ToString(Commands, nameof(Commands)));
            tmpSb.Append($"{nameof(FirstCommand)} = {FirstCommand}");

            return tmpSb.ToString();
        }
    }
}
