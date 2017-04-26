using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.LocalHost;
using SquaresWorkBench.CommonEngine;
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

            var command = new Command();
            command.Name = "fooling";
            command.Params.Add("goal", new FoolingGoal() {
                Subject = "Kyle"
            });

            var result = ExecuteCommand(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"constructor result = {result}");

            result.OnFinish((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info($"constructor result.OnFinish action = {action}");
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

        private EntityAction TstExecCmd(Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"TstExecCmd command = {command}");

            return null;
        }

        public List<KeyValuePair<string, string>> ExistingObjectsList { get; set; } = new List<KeyValuePair<string, string>>();

        public void GoAhead()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("GoAhead");

            var command = new Command("walk");
            command.Params.Add("direction", "ahead");
            command.Params.Add("speed", m___CurrSpeed);

            var result = ExecuteCommand(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"GoAhead result = {result}");

            result.OnComlplete((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info("GoAhead result.OnComlplete");
            });

            result.OnFail((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info("GoAhead result.OnFail");
            });
        }

        private GoDirectionFlag m___CurrGoDirection = GoDirectionFlag.Stop;
        private double m___CurrSpeed = 0;

        public void Stop()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Stop");

            m___CurrGoDirection = GoDirectionFlag.Stop;

            var result = ExecuteCommand(new Command("stop"));

            NLog.LogManager.GetCurrentClassLogger().Info($"Stop result = {result}");

            result.OnComlplete((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info("Stop result.OnComlplete");
            });

            result.OnFail((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info("Stop result.OnFail");
            });
        }

        public void GoLeft()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("GoLeft");
        }

        public void GoRight()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("GoRight");
        }

        public void GoBack()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("GoBack");
        }

        public void RotateLeft()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RotateLeft");

            m___CurrGoDirection = GoDirectionFlag.RotateLeft;

            var command = new Command("walk");
            command.Params.Add("direction", "rotate left");
            command.Params.Add("speed", m___CurrSpeed);

            var result = ExecuteCommand(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"RotateLeft result = {result}");

            result.OnComlplete((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info("RotateLeft result.OnComlplete");
            });

            result.OnFail((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info("RotateLeft result.OnFail");
            });
        }

        public void RotateRight()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RotateRight");

            m___CurrGoDirection = GoDirectionFlag.RotateRight;

            var command = new Command("walk");
            command.Params.Add("direction", "rotate right");
            command.Params.Add("speed", m___CurrSpeed);

            var result = ExecuteCommand(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"RotateRight result = {result}");

            result.OnComlplete((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info("RotateRight result.OnComlplete");
            });

            result.OnFail((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info("RotateRight result.OnFail");
            });
        }

        private string GetCurrGoDirectionAsString()
        {
            switch (m___CurrGoDirection)
            {
                case GoDirectionFlag.Go:
                    return "ahead";

                case GoDirectionFlag.RotateLeft:
                    return "rotate left";

                case GoDirectionFlag.RotateRight:
                    return "rotate right";

                default: throw new ArgumentOutOfRangeException(nameof(m___CurrGoDirection), m___CurrGoDirection, null);
            }
        }

        public void SetSpeed(int speed)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"SetSpeed speed = {speed}");

            m___CurrSpeed = speed;

            if (m___CurrGoDirection == GoDirectionFlag.Stop)
            {
                return;
            }

            var command = new Command("walk");
            command.Params.Add("direction", GetCurrGoDirectionAsString());
            command.Params.Add("speed", m___CurrSpeed);

            //mEntity.Speed = speed;

            /*var command = new Command("set speed");

            command.Params["value"] = speed;*/

            var result = ExecuteCommand(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"SetSpeed result = {result}");

            result.OnComlplete((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info("SetSpeed result.OnComlplete");
            });

            result.OnFail((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info("SetSpeed result.OnFail");
            });
        }

        public void ExecuteCommand(string objectId, string actionName)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteCommand objectId = {objectId}  actionName = {actionName}");

            if (string.IsNullOrWhiteSpace(objectId))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(actionName))
            {
                return;
            }

            var result = ExecuteCommand(new Command(actionName, objectId));

            result.OnComlplete((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteCommand result.OnComlplete actionName = '{actionName}' objectId = {objectId}");

                if (actionName == "take")
                {
                    if (ObjectsRegistry.Is(objectId, "gun"))
                    {
                        NLog.LogManager.GetCurrentClassLogger().Info("ExecuteCommand actionName == 'take' Yess mObjectsRegistry.Is(objectId, 'gun')");

                        mMyCurrentGun = objectId;
                    }
                }
                else
                {
                    if (actionName == "release")
                    {
                        if (ObjectsRegistry.Is(objectId, "gun"))
                        {
                            NLog.LogManager.GetCurrentClassLogger().Info("ExecuteCommand actionName == 'release' Yess mObjectsRegistry.Is(objectId, 'gun')");

                            mMyCurrentGun = string.Empty;
                        }
                    }
                }
            });

            NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteCommand result = {result}");
        }

        public void DumpCoords()
        {
            ActiveEntity.DumpCoords();
        }
    }
}
