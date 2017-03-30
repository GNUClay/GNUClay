using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public class ActiveEntityController
    {
        public ActiveEntityController(ActiveEntity entity)
        {
            mEntity = entity;
        }

        private ActiveEntity mEntity = null;
        public List<KeyValuePair<string, string>> ExistingObjectsList { get; set; } = new List<KeyValuePair<string, string>>();

        public void GoAhead()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("GoAhead");

            //mEntity.GoDirection = GoDirectionFlag.Go;

            var result = mEntity.ExecuteCommand(new Command("go ahead"));

            NLog.LogManager.GetCurrentClassLogger().Info($"GoAhead result = {result}");
        }

        public void Stop()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Stop");

            //mEntity.GoDirection = GoDirectionFlag.Stop;

            var result = mEntity.ExecuteCommand(new Command("stop"));

            NLog.LogManager.GetCurrentClassLogger().Info($"Stop result = {result}");
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

            //mEntity.GoDirection = GoDirectionFlag.RotateLeft;

            var result = mEntity.ExecuteCommand(new Command("rotate left"));

            NLog.LogManager.GetCurrentClassLogger().Info($"RotateLeft result = {result}");
        }

        public void RotateRight()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RotateRight");

            //mEntity.GoDirection = GoDirectionFlag.RotateRight;

            var result = mEntity.ExecuteCommand(new Command("rotate right"));

            NLog.LogManager.GetCurrentClassLogger().Info($"RotateRight result = {result}");
        }

        public void SetSpeed(int speed)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"SetSpeed speed = {speed}");

            //mEntity.Speed = speed;

            var command = new Command("set speed");

            command.Params["value"] = speed;

            var result = mEntity.ExecuteCommand(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"SetSpeed result = {result}");
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

            var result = mEntity.ExecuteCommand(new Command(actionName, objectId));

            NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteCommand result = {result}");
        }
    }
}
