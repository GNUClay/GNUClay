using SquaresWorkBench.CommonEngine;
using SquaresWorkBench.TypicalVisualComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SquaresWorkBench.TypicalCases
{
    public class TSTSoftCreator : BaseSoftCreator
    {
        protected override void OnRun(ISceneForSoftCreator scene)
        {
            var mPlaceEntity = new PlaceEntity();

            mPlaceEntity.CurrMainContext = scene.CurrContext;
            mPlaceEntity.CurrPos = new Point(200, 620);

            var mSimplePlatform = new SimplePlatform();

            mSimplePlatform.CurrMainContext = scene.CurrContext;


            mSimplePlatform.CurrPos = new Point(600, 1100);


            mSimplePlatform.Speed = 10;
            //mSimplePlatform.GoDirection = NewGoDirectionFlag.GoAndRotateLeft;

            var mDoll_1 = new Block();

            mDoll_1.CurrMainContext = scene.CurrContext;


            mDoll_1.CurrPlatform = mSimplePlatform;

            //mDoll_1.RelativePos = new Point(0, 0);
            mDoll_1.RelativePos = new Point(-40, -80);
            mDoll_1.CurrAngle = 0;

            var mGoodHuman = new GoodHuman();

            mGoodHuman.CurrMainContext = scene.CurrContext;

            mGoodHuman.CurrPos = new Point(600, 900);
            //mGoodHuman.CurrPos = new Point(1600, 900);

            //mGoodHuman.CurrPos = new Point(620, 1250);

            //mGoodHuman.CurrAngle = 180;

            //mSimplePlatform.AddChild(mGoodHuman);

            var mBadHuman = new BadHuman();

            mBadHuman.CurrMainContext = scene.CurrContext;

            //mBadHuman.CurrPos = new Point(620, 1200);

            //mBadHuman.CurrPlatform = mSimplePlatform;

            //mBadHuman.RelativePos = new Point(20, 20);

            mBadHuman.CurrPos = new Point(200, 500);
            //mBadHuman.CurrPos = new Point(500, 1000);
            //mBadHuman.CurrPos = new Point(600, 500);
            //mBadHuman.CurrPos = new Point(650, 800);
            //mBadHuman.CurrPos = new Point(650, 1070);
            //mBadHuman.CurrPos = new Point(620, 1200);

            //NLog.LogManager.GetCurrentClassLogger().Info(mBadHuman.RelativePos);

            mBadHuman.CurrAngle = 180;

            mBadHuman.Speed = 4;

            mBadHuman.GoDirection = GoDirectionFlag.Go;

            //NLog.LogManager.GetCurrentClassLogger().Info(mBadHuman.CurrentGeometry.Bounds);

            mGoodHuman.Speed = 4;

            var mDoor = new Door();

            mDoor.CurrMainContext = scene.CurrContext;

            mDoor.CurrPos = new Point(600, 750);
            //mDoor.CurrPos = new Point(600, 850);

            mDoor.Width = 100;

            //mDoor.CurrPos = new Point(100, 100);

            //mGoodHuman.GoDirection = NewGoDirectionFlag.Go;


            var mWindowEntity = new Glass();
            //mWindowEntity.Id = "mWindowEntity";

            mWindowEntity.CurrMainContext = scene.CurrContext;

            mWindowEntity.Width = 100;

            //mWindowEntity.CurrPos = new Point(100, 100);
            mWindowEntity.CurrPos = new Point(600, 850);

            NLog.LogManager.GetCurrentClassLogger().Info("mWindowEntity.Durability = {0}", mWindowEntity.Durability);
            NLog.LogManager.GetCurrentClassLogger().Info("mWindowEntity.Threshold = {0}", mWindowEntity.Threshold);
            NLog.LogManager.GetCurrentClassLogger().Info("mWindowEntity.IsBroken = {0}", mWindowEntity.IsBroken);

            var mGun = new Gun();

            //mGun.Id = "mGun";

            mGun.CurrMainContext = scene.CurrContext;

            mGun.CurrPos = new Point(50, 50);

            mGoodHuman.AddChild(mGun);

            mGun.RelativePos = new Point(0, -10);
        }
    }
}
