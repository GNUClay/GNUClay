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
        public CommandFiltersStorageParamsFilter(ActionCommandFilter filter)
        {
            mFilter = filter;
        }

        private ActionCommandFilter mFilter = null;

        public ActionCommandFilter Filter
        {
            get
            {
                return mFilter;
            }
        }

        public bool Check(Command command)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"Check command = {command}");

            return true;//tmp
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

    public class CommandFiltersStorageTargetsFilter
    {
        private Dictionary<int, CommandFiltersStorageParamsFilter> mDict = new Dictionary<int, CommandFiltersStorageParamsFilter>();

        public void AddFilter(ActionCommandFilter filter)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var targetHashCode = filter.GetHashCode();

            if (mDict.ContainsKey(targetHashCode))
            {
                return;
            }

            var targetStorage = new CommandFiltersStorageParamsFilter(filter);
            mDict.Add(targetHashCode, targetStorage);
        }

        public ActionCommandFilter FindFilter(Command command)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"FindFilter command = {command}");

            foreach(var item in mDict)
            {
                var value = item.Value;

                if(value.Check(command))
                {
                    return value.Filter;
                }
            }

            return null;
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

    public class CommandFiltersStorageCommandFilter
    {
        public void AddFilter(ActionCommandFilter filter)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var targetName = filter.Target;

            CommandFiltersStorageTargetsFilter targetStorage = null;

            if (mDict.ContainsKey(targetName))
            {
                targetStorage = mDict[targetName];
            }
            else
            {
                targetStorage = new CommandFiltersStorageTargetsFilter();
                mDict.Add(targetName, targetStorage);
            }

            targetStorage.AddFilter(filter);
        }

        public ActionCommandFilter FindFilter(Command command)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"FindFilter command = {command}");

            var targetName = command.Target;

            if (mDict.ContainsKey(targetName))
            {
                return mDict[targetName].FindFilter(command);
            }

            return null;
        }

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
        public void AddFilter(ActionCommandFilter filter)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var commandName = filter.CommandName;

            CommandFiltersStorageCommandFilter targetStorage = null;

            if (mDict.ContainsKey(commandName))
            {
                targetStorage = mDict[commandName];
            }
            else
            {
                targetStorage = new CommandFiltersStorageCommandFilter();
                mDict.Add(commandName, targetStorage);
            }

            targetStorage.AddFilter(filter);
        }

        public ActionCommandFilter FindFilter(Command command)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"FindFilter command = {command}");

            var commandName = command.Name;

            if (mDict.ContainsKey(commandName))
            {
                return mDict[commandName].FindFilter(command);
            }

            return null;
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
