using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    [Serializable]
    public class FunctionModel : ISmartToString
    {
        public FunctionModel()
        {
        }

        public FunctionModel(List<ScriptCommand> commands)
        {
            Commands = commands;
            mFirstCommand = Commands.FirstOrDefault();
            LinesDict = Commands.ToDictionary(p => p.Position, p => p);
        }

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
            tmpSb.AppendLine($"{spacesString}Begin FunctionModel");
            tmpSb.AppendLine($"{spacesString}Begin Commands");
            foreach(var cmd in Commands)
            {
                tmpSb.AppendLine(cmd.ToString(dataDictionary, nextIndent));
            }
            tmpSb.Append($"{spacesString}{nameof(FirstCommand)} = {FirstCommand?.ToString(dataDictionary, nextIndent)}");
            tmpSb.AppendLine($"{spacesString}End Commands");
            tmpSb.AppendLine($"{spacesString}Begin FunctionModel");
            return tmpSb.ToString();
        }
    }
}
