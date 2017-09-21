﻿using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.SupportingMachines
{
    [Serializable]
    public class BooleanValue : BaseValueType
    {
        public BooleanValue(ulong typeKey, object value)
            : base(typeKey, value)
        {
            OriginalValue = (double)(Value);

            if(OriginalValue < 0 || OriginalValue > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(OriginalValue), OriginalValue, null);
            }
        }

        public double OriginalValue = 0;

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
            return $"{spacesString}BooleanValue {nameof(Value)} = {Value};";
        }
    }
}
