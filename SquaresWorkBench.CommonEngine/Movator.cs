using GnuClay.CommonUtils.Tasking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public class Movator
    {
        public Movator()
        {
            mActiveObject = new ActiveObject();
            mActiveObject.BeforeStartAction = NOnStart;
            mActiveObject.RunAction = NRun;
        }

        private ActiveObject mActiveObject = null;

        public ActiveContext CurrActiveContext
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

        private List<BaseEntity> mEntitiesList = new List<BaseEntity>();

        private object mLockObj = new object();

        public List<BaseEntity> EntitiesList
        {
            get
            {
                lock (mLockObj)
                {
                    return mEntitiesList.ToList();
                }
            }
        }

        public void Add(BaseEntity entity)
        {
            lock (mLockObj)
            {
                if (mEntitiesList.Contains(entity))
                {
                    return;
                }

                mEntitiesList.Add(entity);

                if (entity.CurrMovator != this)
                {
                    entity.CurrMovator = this;
                }
            }
        }

        public void Remove(BaseEntity entity)
        {
            lock (mLockObj)
            {
                if (!mEntitiesList.Contains(entity))
                {
                    return;
                }

                mEntitiesList.Remove(entity);

                if (entity.CurrMovator == this)
                {
                    entity.CurrMovator = null;
                }
            }
        }

        public void Start()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Start");

            NLog.LogManager.GetCurrentClassLogger().Info("mEntitiesList.Count = {0}", mEntitiesList.Count);

            mActiveObject.Run();
        }

        private int mOldTime = int.MinValue;

        private bool NOnStart()
        {
            mOldTime = Environment.TickCount;

            return true;
        }

        private void NRun()
        {
            List<BaseEntity> tmpTargetList = null;

            lock (mLockObj)
            {
                tmpTargetList = mEntitiesList.Where(p => p.IsMoving).ToList();
            }

            if (tmpTargetList.Count == 0)
            {
                mOldTime = Environment.TickCount;

                return;
            }

            var tmpCurrTime = Environment.TickCount;

            var tmpFrameTime = tmpCurrTime - mOldTime;

            mOldTime = tmpCurrTime;

            if (tmpFrameTime == 0)
            {
                return;
            }

            var tmpPartOfSecond = 1000 / tmpFrameTime;

            if(tmpPartOfSecond == 0)
            {
                return;
            }

            foreach (var entity in tmpTargetList)
            {
                entity.MoveBySession(tmpPartOfSecond);
            }

            foreach (var entity in tmpTargetList)
            {
                entity.ProcessPostMoving();
            }
        }
    }
}
