using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public class CommandFiltersStorageParamsFilter<T> where T : BaseCommandFilter
    {
        public CommandFiltersStorageParamsFilter(T filter)
        {
            mFilter = filter;
        }

        private T mFilter = null;

        public T Filter
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

    public class CommandFiltersStorageTargetsFilter<T> where T : BaseCommandFilter
    {
        private Dictionary<int, CommandFiltersStorageParamsFilter<T>> mDict = new Dictionary<int, CommandFiltersStorageParamsFilter<T>>();

        public void AddFilter(T filter)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var targetHashCode = filter.GetHashCode();

            if (mDict.ContainsKey(targetHashCode))
            {
                return;
            }

            var targetStorage = new CommandFiltersStorageParamsFilter<T>(filter);
            mDict.Add(targetHashCode, targetStorage);
        }

        public T FindFilter(Command command)
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

    public class CommandFiltersStorageCommandFilter<T> where T : BaseCommandFilter
    {
        public void AddFilter(T filter)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var targetName = filter.Target;

            CommandFiltersStorageTargetsFilter<T> targetStorage = null;

            if (mDict.ContainsKey(targetName))
            {
                targetStorage = mDict[targetName];
            }
            else
            {
                targetStorage = new CommandFiltersStorageTargetsFilter<T>();
                mDict.Add(targetName, targetStorage);
            }

            targetStorage.AddFilter(filter);
        }

        public T FindFilter(Command command)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"FindFilter command = {command}");

            var targetName = command.Target;

            if (mDict.ContainsKey(targetName))
            {
                return mDict[targetName].FindFilter(command);
            }

            return null;
        }

        private Dictionary<string, CommandFiltersStorageTargetsFilter<T>> mDict = new Dictionary<string, CommandFiltersStorageTargetsFilter<T>>();

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintJsonToStringInformation(this);
        }
    }

    public class CommandFiltersStorage<T> where T: BaseCommandFilter
    {
        public void AddFilter(T filter)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var commandName = filter.CommandName;

            CommandFiltersStorageCommandFilter<T> targetStorage = null;

            if (mDict.ContainsKey(commandName))
            {
                targetStorage = mDict[commandName];
            }
            else
            {
                targetStorage = new CommandFiltersStorageCommandFilter<T>();
                mDict.Add(commandName, targetStorage);
            }

            targetStorage.AddFilter(filter);
        }

        public T FindFilter(Command command)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"FindFilter command = {command}");

            var commandName = command.Name;

            if (mDict.ContainsKey(commandName))
            {
                return mDict[commandName].FindFilter(command);
            }

            return null;
        } 

        private Dictionary<string, CommandFiltersStorageCommandFilter<T>> mDict = new Dictionary<string, CommandFiltersStorageCommandFilter<T>>();

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
