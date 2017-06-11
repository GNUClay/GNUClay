﻿using GnuClay.CommonUtils.Actors;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class OtherCommand: ICommand
    {
        public OtherCommand() { }
        public OtherCommand(string name)
        {
            Name = name;
        }

        public OtherCommand(string name, string target)
        {
            Name = name;
            Target = target;
        }

        public string Name { get; set; } = string.Empty;
        public string Target { get; set; } = string.Empty;
        public Dictionary<string, object> Params { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintJsonToStringInformation(this);
        }
    }
}
