using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public class CommandFiltersStorageParamsFilter
    {
        public string CommandName { get; set; } = string.Empty;
        public string Target { get; set; } = string.Empty;
        public Dictionary<string, CommandFilterParam> Params { get; set; } = new Dictionary<string, CommandFilterParam>();
        public object Handler { get; set; } = null;

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintJsonToStringInformation(this);
        }
    }

    public class CommandFiltersStorageTargetsFilter
    {
        private List<CommandFiltersStorageParamsFilter> mList = new List<CommandFiltersStorageParamsFilter>();

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintJsonToStringInformation(this);
        }
    }

    public class CommandFiltersStorageCommandFilter
    {
        private Dictionary<string, CommandFiltersStorageTargetsFilter> mDict = new Dictionary<string, CommandFiltersStorageTargetsFilter>();

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintJsonToStringInformation(this);
        }
    }

    public class CommandFiltersStorage
    {
        public void AddFilter(CommandFilter filter)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            throw new NotImplementedException();
        }

        private Dictionary<string, CommandFiltersStorageCommandFilter> mDict = new Dictionary<string, CommandFiltersStorageCommandFilter>();

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
