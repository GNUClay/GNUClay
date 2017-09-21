﻿using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class TstValueType : BaseValueType
    {
        public TstValueType(ulong typeKey, object value)
            : base(typeKey, value)
        {
        }

        public void GetCurrentValue(PropertyAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin GetCurrentValue action = {action}");

            NLog.LogManager.GetCurrentClassLogger().Info($"Begin GetCurrentValue Value = {Value}");

            action.Result = new EntityValue(29);

            NLog.LogManager.GetCurrentClassLogger().Info($"End GetCurrentValue action = {action}");
        }

        public void SetCurrentValue(PropertyAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin SetCurrentValue action = {action}");

            NLog.LogManager.GetCurrentClassLogger().Info($"Begin GetCurrentValue Value = {Value}");

            NLog.LogManager.GetCurrentClassLogger().Info($"End SetCurrentValue action = {action}");
        }

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
        public override string ToString(IReadOnlyStorageDataDictionary dataDictionary, int indent)
        {
            var spacesString = _ObjectHelper.CreateSpaces(indent);
            return $"{spacesString}TstValueType {nameof(TypeKey)} = {TypeKey}; {nameof(Value)} = {Value}";
        }
    }
}
