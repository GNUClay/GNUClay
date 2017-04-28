using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine.TemporaryLogical
{
    public class EntityActionEventsFilter: BaseCommandFilter
    {

    }

    public class EntityActionNotificator
    {
        public EntityActionNotificator(IGnuClayEntityConnection entityConnection, CSharpTypesRegistry cSharpTypesRegistry)
        {
            mCommandFiltersStorage = new CommandFiltersStorage<EntityActionEventsFilter>(entityConnection, cSharpTypesRegistry);
        }

        private CommandFiltersStorage<EntityActionEventsFilter> mCommandFiltersStorage = null;

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

                NLog.LogManager.GetCurrentClassLogger().Info($"AddEntityAction NEXT entityAction.OnFinish action.Status = {action.Status} action.Command = {action.Command}");
            });
        }
    }
}
