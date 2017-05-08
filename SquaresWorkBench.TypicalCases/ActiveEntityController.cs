using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.LocalHost;
using SquaresWorkBench.CommonEngine;
using SquaresWorkBench.CommonEngine.TemporaryLogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.TypicalCases
{
    public class FoolingGoal
    {
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintJsonToStringInformation(this);
        }
    }

    public class FoolingDistanceGoal
    {
        public double Distance { get; set; }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintJsonToStringInformation(this);
        }
    }

    public class ActiveEntityController : BaseLogicalEntity
    {
        public ActiveEntityController()
        {
            RegisterInheritances();
            RegisterTypes();
            RegFactories();

            var filter = new ActionCommandFilter();
            filter.CommandName = "fire";
            filter.Target = "gun";
            filter.Handler = TSTFireGunExecute;

            AddFilter(filter);

            filter = new ActionCommandFilter();
            filter.CommandName = "fooling";
            var filterParameter = new CommandFilterParam();
            filter.Params.Add("distance", filterParameter);
            filter.Handler = TSTFooling_1;

            AddFilter(filter);

            filter = new ActionCommandFilter();
            filter.CommandName = "fooling";

            filterParameter = new CommandFilterParam();
            filterParameter.TypeKey = mEntityConnection.GetKey("fooling goal");
            filterParameter.IsAnyType = false;
            filter.Params.Add("goal", filterParameter);

            filter.Handler = TSTFooling_2;

            AddFilter(filter);

            filter = new ActionCommandFilter();
            filter.CommandName = "fooling";

            filterParameter = new CommandFilterParam();
            filterParameter.TypeKey = mEntityConnection.GetKey("fooling distance goal");
            filterParameter.IsAnyType = false;
            filter.Params.Add("goal", filterParameter);

            filter.Handler = TSTFooling_4;

            AddFilter(filter);

            filter = new ActionCommandFilter();
            filter.CommandName = "fooling";
            filter.Handler = TSTFooling_3;

            AddFilter(filter);

            filter = new ActionCommandFilter();
            filter.CommandName = "walk";
            filter.Handler = TSTFooling_5;

            AddFilter(filter);

            var command = new Command();
            command.Name = "fooling";
            command.Params.Add("goal", new FoolingGoal() {
                Subject = "Kyle"
            });

            var eventsFilter = new EntityActionEventsFilter();
            eventsFilter.CommandName = "fooling";
            eventsFilter.IfCompleted = true;
            eventsFilter.Handler += (EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info($"constructor eventsFilter (fooling) Fired!!!!!! action = {action}");
            };

            mEntityActionNotificator.AddFilter(eventsFilter);

            var result = ExecuteCommand(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"constructor result = {result}");

            result.OnFinish((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info($"constructor result.OnFinish action = {action}");
            });

            mLogicalProcessFactoriesRegistry.StartAutomaticallyProcesses();

            command = new Command();
            command.Name = "walk";
            command.Params.Add("distance", (double)10);
            command.Params.Add("speed", (double)5);

            result = ExecuteCommand(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"constructor result (2) = {result}");

            result.OnFinish((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info($"constructor (2) result.OnFinish action = {action}");
            });
        }

        private void RegisterInheritances()
        {
            var humanKey = mEntityConnection.GetKey("human");

            var roundHumanKey = mEntityConnection.GetKey("round human");
            var squareHumanKey = mEntityConnection.GetKey("square human");

            var limeHumanKey = mEntityConnection.GetKey("lime human");
            var redHumanKey = mEntityConnection.GetKey("red human");
            var whiteHumanKey = mEntityConnection.GetKey("white human");

            var limeRoundHumanKey = mEntityConnection.GetKey("lime round human");
            var redRoundHumanKey = mEntityConnection.GetKey("red round human");
            var whiteRoundHumanKey = mEntityConnection.GetKey("white round human");

            var limeSquareHumanKey = mEntityConnection.GetKey("lime square human");
            var redSquareHumanKey = mEntityConnection.GetKey("red square human");
            var whiteSquareHumanKey = mEntityConnection.GetKey("white square human");

            var gunKey = mEntityConnection.GetKey("gun");

            var glassKey = mEntityConnection.GetKey("glass");

            var doorKey = mEntityConnection.GetKey("door");

            var blockKey = mEntityConnection.GetKey("block");

            var treeKey = mEntityConnection.GetKey("tree");

            mEntityConnection.SetInheritance(roundHumanKey, humanKey, 1);
            mEntityConnection.SetInheritance(squareHumanKey, humanKey, 1);

            mEntityConnection.SetInheritance(limeHumanKey, humanKey, 1);
            mEntityConnection.SetInheritance(redHumanKey, humanKey, 1);
            mEntityConnection.SetInheritance(whiteHumanKey, humanKey, 1);

            mEntityConnection.SetInheritance(limeRoundHumanKey, roundHumanKey, 1);
            mEntityConnection.SetInheritance(limeRoundHumanKey, limeHumanKey, 1);
            mEntityConnection.SetInheritance(redRoundHumanKey, roundHumanKey, 1);
            mEntityConnection.SetInheritance(redRoundHumanKey, redHumanKey, 1);
            mEntityConnection.SetInheritance(whiteRoundHumanKey, roundHumanKey, 1);
            mEntityConnection.SetInheritance(whiteRoundHumanKey, whiteHumanKey, 1);

            mEntityConnection.SetInheritance(limeSquareHumanKey, squareHumanKey, 1);
            mEntityConnection.SetInheritance(limeSquareHumanKey, limeHumanKey, 1);
            mEntityConnection.SetInheritance(redSquareHumanKey, squareHumanKey, 1);
            mEntityConnection.SetInheritance(redSquareHumanKey, redHumanKey, 1);
            mEntityConnection.SetInheritance(whiteSquareHumanKey, squareHumanKey, 1);
            mEntityConnection.SetInheritance(whiteSquareHumanKey, whiteHumanKey, 1);
        }

        private void RegisterTypes()
        {
            mCSharpTypesRegistry.AddType(typeof(double), "number");
            mCSharpTypesRegistry.AddType(typeof(decimal), "number");
            mCSharpTypesRegistry.AddType(typeof(float), "number");
            mCSharpTypesRegistry.AddType(typeof(short), "number");
            mCSharpTypesRegistry.AddType(typeof(ushort), "number");
            mCSharpTypesRegistry.AddType(typeof(int), "number");
            mCSharpTypesRegistry.AddType(typeof(uint), "number");
            mCSharpTypesRegistry.AddType(typeof(long), "number");
            mCSharpTypesRegistry.AddType(typeof(ulong), "number");

            mCSharpTypesRegistry.AddType(typeof(FoolingGoal), "fooling goal");
            mCSharpTypesRegistry.AddType(typeof(FoolingDistanceGoal), "fooling distance goal");

            mCSharpTypesRegistry.AddType<Side>("side");
        }

        private void RegFactories()
        {
            AddProcessFactory<AntiCollideProcess>();
            AddProcessFactory<WalkProcess>();
        }

        private void TSTFooling_1(EntityAction actionResult, Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTFooling_1 command = {command}");

            actionResult.Status = EntityActionStatus.Completed;
        }

        private void TSTFooling_2(EntityAction actionResult, Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTFooling_2 command = {command}");

            actionResult.Status = EntityActionStatus.Completed;
        }

        private void TSTFooling_3(EntityAction actionResult, Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTFooling_3 command = {command}");

            actionResult.Status = EntityActionStatus.Completed;
        }

        private void TSTFooling_4(EntityAction actionResult, Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTFooling_4 command = {command}");

            actionResult.Status = EntityActionStatus.Completed;
        }

        private void TSTFooling_5(EntityAction actionResult, Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTFooling_5 command = {command}");

            actionResult.Status = EntityActionStatus.Completed;
        }

        private string mMyCurrentGun = string.Empty;

        private void TSTFireGunExecute(EntityAction actionResult, Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTFireGunExecute command = {command}");
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTFireGunExecute mMyCurrentGun = {mMyCurrentGun}");

            if (string.IsNullOrWhiteSpace(mMyCurrentGun))
            {
                actionResult.Status = EntityActionStatus.Faulted;
                return;
            }

            var newCommand = new Command();
            newCommand.Name = command.Name;
            newCommand.Target = mMyCurrentGun;

            ExecuteCommand(actionResult, newCommand);
        }
       
        public void ExecuteUserCommand(Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteUserCommand command = {command}");

            if (command == null)
            {
                return;
            }

            var actionName = command.Name;
            var objectId = command.Target;

            var result = ExecuteCommand(command);

            result.OnComlplete((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteUserCommand result.OnComlplete actionName = '{actionName}' objectId = {objectId}");

                if (actionName == "take")
                {
                    if (ObjectsRegistry.Is(objectId, "gun"))
                    {
                        NLog.LogManager.GetCurrentClassLogger().Info("ExecuteUserCommand actionName == 'take' Yess mObjectsRegistry.Is(objectId, 'gun')");

                        mMyCurrentGun = objectId;
                    }
                }
                else
                {
                    if (actionName == "release")
                    {
                        if (ObjectsRegistry.Is(objectId, "gun"))
                        {
                            NLog.LogManager.GetCurrentClassLogger().Info("ExecuteUserCommand actionName == 'release' Yess mObjectsRegistry.Is(objectId, 'gun')");

                            mMyCurrentGun = string.Empty;
                        }
                    }
                }
            });

            NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteUserCommand result = {result}");
        }

        public void DumpCoords()
        {
            ActiveEntity.DumpCoords();
        }
    }
}
