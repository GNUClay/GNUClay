using GnuClay.CommonUtils.Tasking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SquaresWorkBench.CommonEngine
{
    public abstract class ActiveEntity : BaseEntity
    {
        protected ActiveEntity()
        {
            mActiveObject = new ActiveObject();
            mActiveObject.Priority = ThreadPriority.BelowNormal;
            mActiveObject.RunAction = NRun;
        }

        private ActiveObject mActiveObject = null;

        public override ActiveContext CurrActiveContext
        {
            get
            {
                return mActiveObject.Context;
            }

            set
            {
                mActiveObject.Context = value;
            }
        }

        private Camera mSimpleCamera = null;
        private Camera mSecondCamera = null;

        public override void ActivateEntity()
        {
            mActiveObject.IsShouldAutoActivateOnBeginning = true;
            mActiveObject.Run();
        }

        public override void StopEntity()
        {
            mActiveObject.IsShouldAutoActivateOnBeginning = false;
            mActiveObject.Stop();
        }

        protected override void OnSetViewer()
        {
            if (CurrViewer != null)
            {
                mSimpleCamera = new Camera(this, CurrViewer.CurrRTree);
                mSecondCamera = new Camera(this, CurrViewer.CurrRTree);
                //mSecondCamera.TSTDrawContext = CurrViewer.CurrCanvas;
            }
        }

        protected override void OnSetMovator()
        {
        }

        protected virtual void OnSeen(List<VisibleResultItem> items)
        {
        }

        private async void OnSeenAsync(List<VisibleResultItem> items)
        {
            await OnSeenAsyncTask(items);
        }

        private Task OnSeenAsyncTask(List<VisibleResultItem> items)
        {
            var tmpT = new Task(() =>
            {
                OnSeen(items);
            });

            tmpT.Start();

            return tmpT;
        }

        private void NRun()
        {
            if (mSimpleCamera == null)
            {
                return;
            }

            //mSimpleCamera.Scan();

            //OnSeen(mSimpleCamera.Result);

            Thread.Sleep(500);
        }

        private void ActiveRunning()
        {
            while (true)
            {
                NRun();
            }
        }

        public override void Scan()
        {
            if (mSimpleCamera == null)
            {
                return;
            }

            //mSimpleCamera.TSTDrawContext = CurrViewer.CurrCanvas;
            //mSecondCamera.TSTDrawContext = CurrViewer.CurrCanvas;

            NLog.LogManager.GetCurrentClassLogger().Info("Begin Scan");

            mSimpleCamera.Scan();

            NLog.LogManager.GetCurrentClassLogger().Info("End Scan");

            OnSeen(mSimpleCamera.Result);
        }

        protected override void CollideWith(BaseEntity entity)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info("CollideWith => {0}", entity.Id);

            Hit(entity.Damage);

            //NLog.LogManager.GetCurrentClassLogger().Info("Durability = {0}", Durability);
            //NLog.LogManager.GetCurrentClassLogger().Info("Threshold = {0}", Threshold);
            //NLog.LogManager.GetCurrentClassLogger().Info("IsBroken = {0}", IsBroken);

            if (IsBroken)
            {
                Alive = false;
            }
        }

        private bool mAlive = true;

        [PersistentKVPProperty]
        public bool Alive
        {
            get
            {
                return mAlive;
            }

            set
            {
                if (mAlive == value)
                {
                    return;
                }

                mAlive = value;

                if (mAlive)
                {
                    ActivateEntity();
                }
                else
                {
                    StopEntity();

                    GoDirection = GoDirectionFlag.Stop;
                }

                OnSetAlive();

                UpdateView();
            }
        }

        protected virtual void OnSetAlive()
        {
        }

        protected override bool CanSetGoDirection(GoDirectionFlag value)
        {
            if (!mAlive)
            {
                return false;
            }

            return true;
        }

        protected EntityAction ExcecuteAction(string objectId, string actionName)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ExcecuteAction objectId = {objectId}  actionName = {actionName}");

            mSecondCamera.Scan();

            var result = mSecondCamera.Result;

            var targetItem = result.FirstOrDefault(p => p.VisibleEntity.Id == objectId);

            if(targetItem == null)
            {
                return ErrorEntityAction();
            }

            var minDistance = targetItem.VisiblePoints.Min(p => p.Radius);

            NLog.LogManager.GetCurrentClassLogger().Info($"ExcecuteAction minDistance = {minDistance}");

            if(minDistance > 20)
            {
                return ErrorEntityAction();
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"ExcecuteAction NEXT objectId = {objectId}  actionName = {actionName}");

            if(actionName == "take")
            {
                return ExcecuteTakeAction(targetItem.VisibleEntity);
            }

            if(actionName == "release")
            {
                return ExcecuteReleaseAction(targetItem.VisibleEntity);
            }

            return targetItem.VisibleEntity.DispatchExternalAction(actionName);
        }

        private EntityAction ExcecuteTakeAction(BaseEntity targetObject)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ExcecuteTakeAction targetObject.Id = {targetObject.Id}");

            if(!targetObject.CanTaken())
            {
                return ErrorEntityAction();
            }

            if(IsChild(targetObject))
            {
                return ErrorEntityAction();
            }

            AddChild(targetObject);

            targetObject.CurrAngle = CurrAngle;

            NLog.LogManager.GetCurrentClassLogger().Info($"ExcecuteTakeAction targetObject.RelativePos = {targetObject.RelativePos}");

            var newRelativePos = new Point(0, targetObject.RelativePos.Y);

            //if (targetObject.RelativePos.X > 5)
            //{
            //    targetObject.RelativePos = new Point(5, targetObject.RelativePos.Y);
            //}

            targetObject.CurrPos = GetCentralPos();

            NLog.LogManager.GetCurrentClassLogger().Info($"ExcecuteTakeAction (2)targetObject.RelativePos = {targetObject.RelativePos}");

            //targetObject.RelativePos = new Point(10, 0);?????

            return SuccessEntityAction();
        }

        private EntityAction ExcecuteReleaseAction(BaseEntity targetObject)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ExcecuteReleaseAction targetObject.Id = {targetObject.Id}");

            if (!IsChild(targetObject))
            {
                return ErrorEntityAction();
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"ExcecuteReleaseAction NEXT targetObject.Id = {targetObject.Id}");

            targetObject.CurrPos = GetCentralPos(25);

            RemoveChild(targetObject);

            return SuccessEntityAction();
        }

        public void TSTExecuteCommand(string objectId, string actionName)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTExecuteCommand objectId = {objectId}  actionName = {actionName}");

            var result = ExcecuteAction(objectId, actionName);

            NLog.LogManager.GetCurrentClassLogger().Info($"TSTExecuteCommand result = {result}");
        }
    }
}
