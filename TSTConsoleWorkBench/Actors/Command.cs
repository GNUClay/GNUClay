﻿using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class Command: ICommand
    {
        public Command() { }
        public Command(string name)
        {
            Name = name;
        }

        public Command(string name, string target)
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

        public override int GetHashCode()
        {
            var result = 0;

            if (!string.IsNullOrWhiteSpace(Name))
            {
                result ^= Name.GetHashCode();
            }

            if (!string.IsNullOrWhiteSpace(Target))
            {
                result ^= Target.GetHashCode();
            }

            if (Params != null)
            {
                foreach(var paramItem in Params)
                {
                    result ^= paramItem.Key.GetHashCode();

                    var paramValue = paramItem.Value;

                    if(paramValue != null)
                    {
                        result ^= paramValue.GetHashCode();
                    }
                }
            }

            return result;
        }
    }
}
