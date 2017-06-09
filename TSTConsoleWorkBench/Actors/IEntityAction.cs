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
        void OnComlplete(Action<EntityAction> action);
        void OnFail(Action<EntityAction> action);
        void OnCancel(Action<EntityAction> action);
        void OnFinish(Action<EntityAction> action);
    }
}
