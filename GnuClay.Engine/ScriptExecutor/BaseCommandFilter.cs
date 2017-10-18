﻿using GnuClay.CommonClientTypes.CommonData;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class BaseCommandFilter : ILongHashableObject
    {
        public BaseCommandFilter()
        {
        }

        public BaseCommandFilter(IExternalCommandFilter source)
        {
            FunctionKey = source.FunctionKey;
            TargetKey = source.TargetKey;
            HolderKey = source.HolderKey;

            foreach (var param in source.Params)
            {
                Params[param.Key] = new CommandFilterParam(param.Value);
            }
        }

        public ulong FunctionKey { get; set; }
        public ulong TargetKey { get; set; }
        public ulong HolderKey { get; set; }
        public Dictionary<ulong, CommandFilterParam> Params { get; set; } = new Dictionary<ulong, CommandFilterParam>();
        public bool WithOutClause { get; set; } = true;

        /// <summary>
        /// Serves as the hash function that has size as ulong.
        /// </summary>
        /// <returns>Return value of the hash.</returns>
        public ulong GetLongHashCode()
        {
            var result = 100*FunctionKey + 100*TargetKey + 100*HolderKey;

            foreach (var item in Params)
            {
                result += item.Value.GetLongHashCode();
            }

            return result;
        }

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
