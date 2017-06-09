using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public interface IContextOfLogicalProcesses
    {
        void AddFilter(CommandFilter filter);
        ulong GetKey(string val);
        ulong GetTypeKey(object value);
        double GetTypeInheritanceRank(ulong subKey, ulong superKey);
        Blackboard Blackboard { get; }
        EntityAction ExecuteCommand(Command command);
        EntityAction ExecuteCommand(Command command, EntityAction initiator);
        EntityAction ExecuteCommand(EntityAction action);
        void SetExclusiveGroupProcess(EntityAction action);
        void RemoveExclusiveGroupProcess(EntityAction action);
        void SetProcessAsCurrent(EntityAction action);
        void RemoveProcessAsCurrent(EntityAction action);
    }

    public interface ICommonClassOfLogicalProcesses
    {
        IContextOfLogicalProcesses Context { get; }
    }
}
