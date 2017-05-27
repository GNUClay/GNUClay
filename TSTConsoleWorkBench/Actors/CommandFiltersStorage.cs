using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class CommandFiltersStorageParamsFilter<T, C> 
        where T : BaseCommandFilter
        where C : IContextOfLogicalProcesses
    {
        public CommandFiltersStorageParamsFilter(T filter, C context)
        {
            Context = context;
            mFilter = filter;
        }

        private C Context = default(C);
        private T mFilter = null;

        public T Filter
        {
            get
            {
                return mFilter;
            }
        }

        public double GetRank(Command command)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"GetRank command = {command}");

            //NLog.LogManager.GetCurrentClassLogger().Info($"GetRank mFilter.Params.Count = {mFilter.Params.Count}");
            //NLog.LogManager.GetCurrentClassLogger().Info($"GetRank command.Params.Count = {command.Params.Count}");

            if (_ListHelper.IsEmpty(mFilter.Params))
            {
                return 0.01;
            }

            //NLog.LogManager.GetCurrentClassLogger().Info("GetRank NEXT");

            var commandParams = command.Params;

            double result = 1;

            foreach (var filterParamKVP in mFilter.Params)
            {
                var paramName = filterParamKVP.Key;
                //NLog.LogManager.GetCurrentClassLogger().Info($"GetRank paramName = {paramName}");

                if (!commandParams.ContainsKey(paramName))
                {
                    return 0;
                }

                var targetCommandParam = commandParams[paramName];

                var filterParam = filterParamKVP.Value;

                //NLog.LogManager.GetCurrentClassLogger().Info($"GetRank targetCommandParam = {targetCommandParam}");
                //NLog.LogManager.GetCurrentClassLogger().Info($"GetRank filterParam = {filterParam}");

                if (filterParam.IsAnyType)
                {
                    result *= 0.1;
                }
                else
                {
                    var commandParamTypeKey = Context.GetTypeKey(targetCommandParam);// 

                    //NLog.LogManager.GetCurrentClassLogger().Info($"GetRank commandParamTypeKey = {commandParamTypeKey}");

                    if (commandParamTypeKey == filterParam.TypeKey)
                    {
                        result *= 2;
                    }
                    else
                    {
                        var rank = Context.GetTypeInheritanceRank(commandParamTypeKey, filterParam.TypeKey);

                        //NLog.LogManager.GetCurrentClassLogger().Info($"GetRank rank = {rank}");

                        if (rank == 0)
                        {
                            return 0;
                        }

                        result *= rank;
                    }
                }

                //NLog.LogManager.GetCurrentClassLogger().Info($"GetRank NEXT NEXT result = {result}");

                if (filterParam.IsAnyValue)
                {
                    result *= 0.1;
                }
                else
                {
                    if (targetCommandParam == filterParam.Value)
                    {
                        result *= 2;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            //NLog.LogManager.GetCurrentClassLogger().Info($"GetRank result = {result}");

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

    public class CommandFiltersStorageTargetsFilter<T, C> 
        where T : BaseCommandFilter
        where C : IContextOfLogicalProcesses
    {
        public CommandFiltersStorageTargetsFilter(C context)
        {
            Context = context;
        }

        private C Context = default(C);
        private Dictionary<int, CommandFiltersStorageParamsFilter<T, C>> mDict = new Dictionary<int, CommandFiltersStorageParamsFilter<T, C>>();

        public void AddFilter(T filter)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var targetHashCode = filter.GetHashCode();

            if (mDict.ContainsKey(targetHashCode))
            {
                return;
            }

            var targetStorage = new CommandFiltersStorageParamsFilter<T, C>(filter, Context);
            mDict.Add(targetHashCode, targetStorage);
        }

        public List<T> FindFilter(Command command)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"FindFilter command = {command}");

            var targetFilters = new List<KeyValuePair<double, T>>();

            //NLog.LogManager.GetCurrentClassLogger().Info($"FindFilter mDict.Count = {mDict.Count}");

            foreach (var item in mDict)
            {
                var value = item.Value;

                var rank = value.GetRank(command);

                //NLog.LogManager.GetCurrentClassLogger().Info($"FindFilter rank = {rank}");

                if (rank == 0)
                {
                    continue;
                }

                targetFilters.Add(new KeyValuePair<double, T>(rank, value.Filter));
            }

            //NLog.LogManager.GetCurrentClassLogger().Info($"FindFilter NEXT targetFilters.Count = {targetFilters.Count}");

            if (_ListHelper.IsEmpty(targetFilters))
            {
                return new List<T>();
            }

            return targetFilters.OrderByDescending(p => p.Key).Select(p => p.Value).ToList();
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

    public class CommandFiltersStorageCommandFilter<T, C> 
        where T : BaseCommandFilter
        where C : IContextOfLogicalProcesses
    {
        public CommandFiltersStorageCommandFilter(C context)
        {
            Context = context;
        }

        private C Context = default(C); 

        public void AddFilter(T filter)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var targetName = filter.Target;

            CommandFiltersStorageTargetsFilter<T, C> targetStorage = null;

            if (mDict.ContainsKey(targetName))
            {
                targetStorage = mDict[targetName];
            }
            else
            {
                targetStorage = new CommandFiltersStorageTargetsFilter<T, C>(Context);
                mDict.Add(targetName, targetStorage);
            }

            targetStorage.AddFilter(filter);
        }

        public List<T> FindFilter(Command command)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"FindFilter command = {command}");

            var targetName = command.Target;

            if (mDict.ContainsKey(targetName))
            {
                return mDict[targetName].FindFilter(command);
            }

            return new List<T>();
        }

        private Dictionary<string, CommandFiltersStorageTargetsFilter<T, C>> mDict = new Dictionary<string, CommandFiltersStorageTargetsFilter<T, C>>();

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintJsonToStringInformation(this);
        }
    }

    public class CommandFiltersStorage<T, C> 
        where T : BaseCommandFilter
        where C : IContextOfLogicalProcesses
    {
        public CommandFiltersStorage(C context)
        {
            Context = context;
        }

        private C Context = default(C);

        public void AddFilter(T filter)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var commandName = filter.CommandName;

            CommandFiltersStorageCommandFilter<T, C> targetStorage = null;

            if (mDict.ContainsKey(commandName))
            {
                targetStorage = mDict[commandName];
            }
            else
            {
                targetStorage = new CommandFiltersStorageCommandFilter<T, C>(Context);
                mDict.Add(commandName, targetStorage);
            }

            targetStorage.AddFilter(filter);
        }

        public List<T> FindFilter(Command command)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"FindFilter command = {command}");

            var commandName = command.Name;

            if (mDict.ContainsKey(commandName))
            {
                return mDict[commandName].FindFilter(command);
            }

            return new List<T>();
        }

        private Dictionary<string, CommandFiltersStorageCommandFilter<T, C>> mDict = new Dictionary<string, CommandFiltersStorageCommandFilter<T, C>>();

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
