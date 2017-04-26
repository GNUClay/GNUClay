using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using SquaresWorkBench.CommonEngine.TemporaryLogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public class CommandFiltersStorageParamsFilter
    {
        public CommandFiltersStorageParamsFilter(ActionCommandFilter filter, IGnuClayEntityConnection entityConnection, CSharpTypesRegistry cSharpTypesRegistry)
        {
            mEntityConnection = entityConnection;
            mCSharpTypesRegistry = cSharpTypesRegistry;
            mFilter = filter;
        }

        private IGnuClayEntityConnection mEntityConnection = null;
        private CSharpTypesRegistry mCSharpTypesRegistry = null;
        private ActionCommandFilter mFilter = null;

        public ActionCommandFilter Filter
        {
            get
            {
                return mFilter;
            }
        }

        public double GetRank(Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"GetRank command = {command}");

            NLog.LogManager.GetCurrentClassLogger().Info($"GetRank mFilter.Params.Count = {mFilter.Params.Count}");
            NLog.LogManager.GetCurrentClassLogger().Info($"GetRank command.Params.Count = {command.Params.Count}");

            if(_ListHelper.IsEmpty(mFilter.Params))
            {
                return 0.01;
            }

            NLog.LogManager.GetCurrentClassLogger().Info("GetRank NEXT");

            var commandParams = command.Params;

            double result = 1;

            foreach (var filterParamKVP in mFilter.Params)
            {
                var paramName = filterParamKVP.Key;
                NLog.LogManager.GetCurrentClassLogger().Info($"GetRank paramName = {paramName}");

                if(!commandParams.ContainsKey(paramName))
                {
                    return 0;
                }

                var targetCommandParam = commandParams[paramName];

                var filterParam = filterParamKVP.Value;

                NLog.LogManager.GetCurrentClassLogger().Info($"GetRank targetCommandParam = {targetCommandParam}");
                NLog.LogManager.GetCurrentClassLogger().Info($"GetRank filterParam = {filterParam}");

                if (filterParam.IsAnyType)
                {
                    result *= 0.1;
                }
                else
                {
                    var commandParamTypeKey = mCSharpTypesRegistry.GetTypeKey(targetCommandParam);

                    NLog.LogManager.GetCurrentClassLogger().Info($"GetRank commandParamTypeKey = {commandParamTypeKey}");

                    if(commandParamTypeKey == filterParam.TypeKey)
                    {
                        result *= 2;
                    }
                    else
                    {
                        var rank = mEntityConnection.GetInheritanceRank(commandParamTypeKey, filterParam.TypeKey);

                        NLog.LogManager.GetCurrentClassLogger().Info($"GetRank rank = {rank}");

                        result *= rank;
                    }
                }

                NLog.LogManager.GetCurrentClassLogger().Info($"GetRank NEXT NEXT result = {result}");
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"GetRank result = {result}");

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

    public class CommandFiltersStorageTargetsFilter
    {
        public CommandFiltersStorageTargetsFilter(IGnuClayEntityConnection entityConnection, CSharpTypesRegistry cSharpTypesRegistry)
        {
            mEntityConnection = entityConnection;
            mCSharpTypesRegistry = cSharpTypesRegistry;
        }

        private IGnuClayEntityConnection mEntityConnection = null;
        private CSharpTypesRegistry mCSharpTypesRegistry = null;

        private Dictionary<int, CommandFiltersStorageParamsFilter> mDict = new Dictionary<int, CommandFiltersStorageParamsFilter>();

        public void AddFilter(ActionCommandFilter filter)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var targetHashCode = filter.GetHashCode();

            if (mDict.ContainsKey(targetHashCode))
            {
                return;
            }

            var targetStorage = new CommandFiltersStorageParamsFilter(filter, mEntityConnection, mCSharpTypesRegistry);
            mDict.Add(targetHashCode, targetStorage);
        }

        public ActionCommandFilter FindFilter(Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FindFilter command = {command}");

            var targetFilters = new List<KeyValuePair<double, ActionCommandFilter>>();

            NLog.LogManager.GetCurrentClassLogger().Info($"FindFilter mDict.Count = {mDict.Count}");

            foreach (var item in mDict)
            {
                var value = item.Value;

                var rank = value.GetRank(command);

                NLog.LogManager.GetCurrentClassLogger().Info($"FindFilter rank = {rank}");

                if(rank == 0)
                {
                    continue;
                }

                targetFilters.Add(new KeyValuePair<double, ActionCommandFilter>(rank, value.Filter));
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"FindFilter NEXT targetFilters.Count = {targetFilters.Count}");

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
        public CommandFiltersStorageCommandFilter(IGnuClayEntityConnection entityConnection, CSharpTypesRegistry cSharpTypesRegistry)
        {
            mEntityConnection = entityConnection;
            mCSharpTypesRegistry = cSharpTypesRegistry;
        }

        private IGnuClayEntityConnection mEntityConnection = null;
        private CSharpTypesRegistry mCSharpTypesRegistry = null;

        public void AddFilter(ActionCommandFilter filter)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var targetName = filter.Target;

            CommandFiltersStorageTargetsFilter targetStorage = null;

            if (mDict.ContainsKey(targetName))
            {
                targetStorage = mDict[targetName];
            }
            else
            {
                targetStorage = new CommandFiltersStorageTargetsFilter(mEntityConnection, mCSharpTypesRegistry);
                mDict.Add(targetName, targetStorage);
            }

            targetStorage.AddFilter(filter);
        }

        public ActionCommandFilter FindFilter(Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FindFilter command = {command}");

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
        public CommandFiltersStorage(IGnuClayEntityConnection entityConnection, CSharpTypesRegistry cSharpTypesRegistry)
        {
            mEntityConnection = entityConnection;
            mCSharpTypesRegistry = cSharpTypesRegistry;
        }

        private IGnuClayEntityConnection mEntityConnection = null;
        private CSharpTypesRegistry mCSharpTypesRegistry = null;

        public void AddFilter(ActionCommandFilter filter)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var commandName = filter.CommandName;

            CommandFiltersStorageCommandFilter targetStorage = null;

            if (mDict.ContainsKey(commandName))
            {
                targetStorage = mDict[commandName];
            }
            else
            {
                targetStorage = new CommandFiltersStorageCommandFilter(mEntityConnection, mCSharpTypesRegistry);
                mDict.Add(commandName, targetStorage);
            }

            targetStorage.AddFilter(filter);
        }

        public ActionCommandFilter FindFilter(Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FindFilter command = {command}");

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
