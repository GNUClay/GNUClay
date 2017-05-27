using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public delegate void ActionEventsNotificatorHandler(EntityAction action);

    public class EntityActionEventsFilter : BaseCommandFilter
    {
        public bool IfCompleted { get; set; }
        public bool IfFaulted { get; set; }
        public bool IfCanceled { get; set; }
        public bool IfFinished { get; set; }
        public bool IfFinishedWithOutErrors { get; set; }

        public event ActionEventsNotificatorHandler Handler;

        public void Emit(EntityAction action)
        {
            Handler?.Invoke(action);
        }
    }

    public class EntityActionNotificator<C>
        where C : IContextOfLogicalProcesses
    {
        public EntityActionNotificator(C context)
        {
            mCommandFiltersStorage = new CommandFiltersStorage<EntityActionEventsFilter, C>(context);
        }

        private CommandFiltersStorage<EntityActionEventsFilter, C> mCommandFiltersStorage = null;

        public void AddFilter(EntityActionEventsFilter filter)
        {
            mCommandFiltersStorage.AddFilter(filter);
        }

        public void AddEntityAction(EntityAction entityAction)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddEntityAction entityAction.Command = {entityAction.Command}");

            entityAction.OnFinish((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info($"AddEntityAction entityAction.OnFinish action.Status = {action.Status} action.Command = {action.Command}");

                var actionsList = mCommandFiltersStorage.FindFilter(entityAction.Command);

                if (_ListHelper.IsEmpty(actionsList))
                {
                    return;
                }

                NLog.LogManager.GetCurrentClassLogger().Info($"AddEntityAction NEXT entityAction.OnFinish actionsList.Count = {actionsList.Count} action.Status = {action.Status} action.Command = {action.Command}");

                var status = action.Status;

                switch (status)
                {
                    case EntityActionStatus.Completed:
                        actionsList = actionsList.Where(p => p.IfCompleted || p.IfFinished || p.IfFinishedWithOutErrors).ToList();
                        break;

                    case EntityActionStatus.Canceled:
                        actionsList = actionsList.Where(p => p.IfCanceled || p.IfFinished || p.IfFinishedWithOutErrors).ToList();
                        break;

                    case EntityActionStatus.Faulted:
                        actionsList = actionsList.Where(p => p.IfFaulted || p.IfFinished).ToList();
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(status), status, null);
                }

                if (_ListHelper.IsEmpty(actionsList))
                {
                    return;
                }

                NLog.LogManager.GetCurrentClassLogger().Info($"AddEntityAction NEXT NEXT entityAction.OnFinish actionsList.Count = {actionsList.Count} action.Status = {action.Status} action.Command = {action.Command}");

                foreach (var item in actionsList)
                {
                    Task.Run(() => {
                        item.Emit(action);
                    });
                }
            });
        }
    }
}
