using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public delegate void OnFiledDispatchOfCommand(IEntityAction command);

    public interface IContextOfLogicalProcesses
    {
        void AddFilter(CommandFilter filter);
        ulong GetKey(string val);
        ulong GetTypeKey(object value);
        double GetTypeInheritanceRank(ulong subKey, ulong superKey);
        Blackboard Blackboard { get; }
        IEntityAction ExecuteCommand(ICommand command);
        IEntityAction ExecuteCommand(ICommand command, IEntityAction initiator);
        IEntityAction ExecuteCommand(IEntityAction action);
        void SetExclusiveGroupProcess(IEntityAction action);
        void RemoveExclusiveGroupProcess(IEntityAction action);
        void SetProcessAsCurrent(IEntityAction action);
        void RemoveProcessAsCurrent(IEntityAction action);
        void SetFiledDispatchOfCommandHandler(OnFiledDispatchOfCommand handler);
    }

    public interface ICommonClassOfLogicalProcesses
    {
        IContextOfLogicalProcesses Context { get; }
    }
}
