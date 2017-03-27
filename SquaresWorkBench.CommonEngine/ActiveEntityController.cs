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

            

            mEntity.GoDirection = GoDirectionFlag.Go;
        }

        public void Stop()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Stop");

            mEntity.GoDirection = GoDirectionFlag.Stop;
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

            mEntity.GoDirection = GoDirectionFlag.RotateLeft;
        }

        public void RotateRight()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RotateRight");

            mEntity.GoDirection = GoDirectionFlag.RotateRight;
        }

        public void SetSpeed(int speed)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"SetSpeed speed = {speed}");

            mEntity.Speed = speed;
        }

        public void ExecuteAction(string objectId, string actionName)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteAction objectId = {objectId}  actionName = {actionName}");

            if (string.IsNullOrWhiteSpace(objectId))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(actionName))
            {
                return;
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteAction Next objectId = {objectId}  actionName = {actionName}");
        }
    }
}
