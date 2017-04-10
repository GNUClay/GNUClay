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

        private EntityAction TSTFireGunExecute(Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTFireGunExecute command = {command}");
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTFireGunExecute mMyCurrentGun = {mMyCurrentGun}");

            if(string.IsNullOrWhiteSpace(mMyCurrentGun))
            {
                return EntityAction.CreateError(command);
            }

            var newCommnad = new Command();
            newCommnad.Name = command.Name;
            newCommnad.Target = mMyCurrentGun;

            return ExecuteCommand(newCommnad);
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

            var result = ExecuteCommand(new Command("go ahead"));

            NLog.LogManager.GetCurrentClassLogger().Info($"GoAhead result = {result}");
        }

        public void Stop()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Stop");

            var result = ExecuteCommand(new Command("stop"));

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

            var result = ExecuteCommand(new Command("rotate left"));

            NLog.LogManager.GetCurrentClassLogger().Info($"RotateLeft result = {result}");
        }

        public void RotateRight()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RotateRight");

            var result = ExecuteCommand(new Command("rotate right"));

            NLog.LogManager.GetCurrentClassLogger().Info($"RotateRight result = {result}");
        }

        public void SetSpeed(int speed)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"SetSpeed speed = {speed}");

            //mEntity.Speed = speed;

            var command = new Command("set speed");

            command.Params["value"] = speed;

            var result = ExecuteCommand(command);

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

            var result = ExecuteCommand(new Command(actionName, objectId));

            if(result.State == EntityActionState.EndSuccess)
            {
                if (actionName == "take")
                {
                    mMyCurrentGun = objectId;
                }
                else
                {
                    if(actionName == "release")
                    {
                        mMyCurrentGun = string.Empty;
                    }
                }
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteCommand result = {result}");
        }

        public override void OnSeen(List<VisibleResultItem> items)
        {
            /*NLog.LogManager.GetCurrentClassLogger().Info("OnSeen");

            if (items == null || items.Count == 0)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Not Sees");

                return;
            }

            foreach (var scanItem in items)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("-----");
                NLog.LogManager.GetCurrentClassLogger().Info($"Id = {scanItem.VisibleEntity.Id} Class = {scanItem.VisibleEntity.Class}");

                foreach (var tmpPoint in scanItem.VisiblePoints)
                {
                    NLog.LogManager.GetCurrentClassLogger().Info($"TargetPoint = {tmpPoint.TargetPoint} Angle = {tmpPoint.Angle} Radius = {tmpPoint.Radius}");
                }
            }*/
        }

        public void DumpCoords()
        {
            ActiveEntity.DumpCoords();
        }
    }
}
