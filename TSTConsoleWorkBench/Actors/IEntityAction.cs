using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public enum EntityActionStatus
    {
        Running,
        Completed,
        Faulted,
        Canceled
    }

    public delegate void OnClarifyParams(List<ICommandFilterParam> paramsList);

    public interface IEntityAction
    {
        ICommand Command { get; set; }
        EntityActionStatus Status { get; set; }
        string Name { get; set; }
        ulong NameKey { get; set; }
        Exception Exception { get; set; }
        void Cancel();
        void OnComlplete(Action<IEntityAction> action);
        void OnFail(Action<IEntityAction> action);
        void OnCancel(Action<IEntityAction> action);
        void OnFinish(Action<IEntityAction> action);
        void OnFinishWithOutFail(Action<IEntityAction> action);
        IEntityAction Initiator { get; set; }
        List<IEntityAction> InitiatedActions { get; }
        void AddInitiatedAction(IEntityAction initiatedAction);
        void RemoveInitiatedAction(IEntityAction initiatedAction);
        bool IsAutoCanceled { get; set; }
        void SetOnClarifyParamsByInitiatedActions(OnClarifyParams callBack);
        void ResetOnClarifyParamsByInitiatedActions();
        void ClarifyParamsByInitiatedActions(ICommandFilterParam param);
        void ClarifyParamsByInitiatedActions(List<ICommandFilterParam> paramsList);
        void SetOnClarifyParamsByInitiator(OnClarifyParams callBack);
        void ResetOnClarifyParamsByInitiator();
        void ClarifyParamsByInitiator(ICommandFilterParam param);
        void ClarifyParamsByInitiator(List<ICommandFilterParam> paramsList);
        ulong ExclusiveGroupKey { get; set; }
    }
}
