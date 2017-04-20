using GnuClay.CommonUtils.TypeHelpers;
using SquaresWorkBench.CommonEngine.TemporaryLogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public class ActiveEntityController: BaseLogicalEntity
    {
        public ActiveEntityController()
        {
            var filter = new ActionCommandFilter();
            filter.CommandName = "fire";
            filter.Target = "gun";
            filter.Handler = TSTFireGunExecute;

            AddFilter(filter);



            /*var command = new Command();
            command.Name = "fire";
            command.Target = "gun";

            var result = ExecuteCommand(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"constructor result = {result}");*/
        }

        private string mMyCurrentGun = string.Empty;

        private void TSTFireGunExecute(EntityAction actionResult, Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTFireGunExecute command = {command}");
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTFireGunExecute mMyCurrentGun = {mMyCurrentGun}");

            if(string.IsNullOrWhiteSpace(mMyCurrentGun))
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

            var command = new Command("go");
            command.Params.Add("direction", "ahead");
            command.Params.Add("speed", m___CurrSpeed);

            var result = ExecuteCommand(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"GoAhead result = {result}");

            result.OnComlplete(() => {
                NLog.LogManager.GetCurrentClassLogger().Info("GoAhead result.OnComlplete");
            });

            result.OnFail(() => {
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

            result.OnComlplete(() => {
                NLog.LogManager.GetCurrentClassLogger().Info("Stop result.OnComlplete");
            });

            result.OnFail(() => {
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

            var command = new Command("go");
            command.Params.Add("direction", "rotate left");
            command.Params.Add("speed", m___CurrSpeed);

            var result = ExecuteCommand(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"RotateLeft result = {result}");

            result.OnComlplete(() => {
                NLog.LogManager.GetCurrentClassLogger().Info("RotateLeft result.OnComlplete");
            });

            result.OnFail(() => {
                NLog.LogManager.GetCurrentClassLogger().Info("RotateLeft result.OnFail");
            });
        }

        public void RotateRight()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RotateRight");

            m___CurrGoDirection = GoDirectionFlag.RotateRight;

            var command = new Command("go");
            command.Params.Add("direction", "rotate right");
            command.Params.Add("speed", m___CurrSpeed);

            var result = ExecuteCommand(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"RotateRight result = {result}");

            result.OnComlplete(() => {
                NLog.LogManager.GetCurrentClassLogger().Info("RotateRight result.OnComlplete");
            });

            result.OnFail(() => {
                NLog.LogManager.GetCurrentClassLogger().Info("RotateRight result.OnFail");
            });
        }

        private string GetCurrGoDirectionAsString()
        {
            switch(m___CurrGoDirection)
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

            if(m___CurrGoDirection == GoDirectionFlag.Stop)
            {
                return;
            }

            var command = new Command("go");
            command.Params.Add("direction", GetCurrGoDirectionAsString());
            command.Params.Add("speed", m___CurrSpeed);

            //mEntity.Speed = speed;

            /*var command = new Command("set speed");

            command.Params["value"] = speed;*/

            var result = ExecuteCommand(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"SetSpeed result = {result}");

            result.OnComlplete(() => {
                NLog.LogManager.GetCurrentClassLogger().Info("SetSpeed result.OnComlplete");
            });

            result.OnFail(() => {
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

            result.OnComlplete(() => {
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
