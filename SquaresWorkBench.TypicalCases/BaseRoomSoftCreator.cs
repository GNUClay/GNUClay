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
    public abstract class BaseRoomSoftCreator : BaseSoftCreator
    {
        protected BaseRoom mRoom = null;

        protected Block mBlock_1 = null;

        protected Block mBlock_2 = null;

        protected Block mBlock_3 = null;

        protected Block mBlock_4 = null;

        protected Block mBlock_5 = null;

        protected Block mBlock_6 = null;

        protected Block mBlock_7 = null;

        protected Block mBlock_8 = null;

        protected Block mBlock_9 = null;

        protected Block mBlock_10 = null;

        protected Block mBlock_11 = null;

        protected Block mBlock_12 = null;

        protected Block mBlock_13 = null;

        protected Block mBlock_14 = null;

        protected Block mBlock_15 = null;

        protected Block mBlock_16 = null;

        protected Block mBlock_17 = null;

        protected Block mBlock_18 = null;

        protected Block mBlock_19 = null;

        protected Block mBlock_20 = null;

        protected Block mBlock_21 = null;

        protected Block mBlock_22 = null;

        protected Block mBlock_23 = null;

        protected Block mBlock_24 = null;

        protected Block mBlock_25 = null;

        protected Block mBlock_26 = null;

        protected Block mBlock_27 = null;

        protected Door mDoor = null;

        protected Glass mWindowEntity_1 = null;

        protected Glass mWindowEntity_2 = null;

        protected RedSquareHuman mGnuClayHuman = null;

        protected override void OnRun()
        {
            var existingsObjects = new List<KeyValuePair<string, string>>();

            mRoom = new BaseRoom();
            mRoom.CurrMainContext = Scene.CurrContext;
            mRoom.Height = 400;
            mRoom.Width = 400;

            mRoom.CurrPos = new Point(250, 250);

            mBlock_1 = CreateVBlock();
            mBlock_1.RelativePos = new Point(-196.5, -175);

            mBlock_2 = CreateVBlock();
            mBlock_2.RelativePos = new Point(-196.5, -125);

            mBlock_3 = CreateVBlock();
            mBlock_3.RelativePos = new Point(-196.5, -75);

            mBlock_4 = CreateVBlock();
            mBlock_4.RelativePos = new Point(-196.5, -25);

            mBlock_5 = CreateVBlock();
            mBlock_5.RelativePos = new Point(-196.5, 25);

            mBlock_6 = CreateVBlock();
            mBlock_6.RelativePos = new Point(-196.5, 75);

            mBlock_7 = CreateVBlock();
            mBlock_7.RelativePos = new Point(-196.5, 125);

            mBlock_8 = CreateVBlock();
            mBlock_8.RelativePos = new Point(-196.5, 175);

            mBlock_9 = CreateVBlock();
            mBlock_9.RelativePos = new Point(196.5, -175);

            mBlock_10 = CreateVBlock();
            mBlock_10.RelativePos = new Point(196.5, -125);

            mBlock_11 = CreateVBlock();
            mBlock_11.RelativePos = new Point(196.5, -75);

            mBlock_12 = CreateVBlock();
            mBlock_12.RelativePos = new Point(196.5, -25);

            mBlock_13 = CreateVBlock();
            mBlock_13.RelativePos = new Point(196.5, 25);

            mBlock_14 = CreateVBlock();
            mBlock_14.RelativePos = new Point(196.5, 75);

            mBlock_15 = CreateVBlock();
            mBlock_15.RelativePos = new Point(196.5, 125);

            mBlock_16 = CreateVBlock();
            mBlock_16.RelativePos = new Point(196.5, 175);

            mBlock_17 = CreateHBlock();
            mBlock_17.RelativePos = new Point(-170, -196.5);

            mBlock_18 = CreateHBlock();
            mBlock_18.RelativePos = new Point(-20, -196.5);

            mBlock_19 = CreateHBlock();
            mBlock_19.RelativePos = new Point(130, -196.5);

            mBlock_20 = CreateBlock();
            mBlock_20.Width = 37;
            mBlock_20.RelativePos = new Point(175, -196.5);

            mBlock_21 = CreateHBlock();
            mBlock_21.RelativePos = new Point(-170, 196.5);

            mBlock_22 = CreateHBlock();
            mBlock_22.RelativePos = new Point(-120, 196.5);

            mBlock_23 = CreateHBlock();
            mBlock_23.RelativePos = new Point(-70, 196.5);

            mBlock_24 = CreateHBlock();
            mBlock_24.RelativePos = new Point(-20, 196.5);

            mBlock_25 = CreateHBlock();
            mBlock_25.RelativePos = new Point(30, 196.5);

            mBlock_26 = CreateHBlock();
            mBlock_26.RelativePos = new Point(140, 196.5);

            mBlock_27 = CreateBlock();
            mBlock_27.Width = 27;
            mBlock_27.RelativePos = new Point(180, 196.5);

            mDoor = new Door();
            mDoor.CurrMainContext = Scene.CurrContext;
            mDoor.CurrPlatform = mRoom;
            mDoor.RelativePos = new Point(85, 196.5);
            mDoor.Width = 60;

            existingsObjects.Add(new KeyValuePair<string, string>(mDoor.Id, $"door ({mDoor.Id})"));

            mWindowEntity_1 = new Glass();
            mWindowEntity_1.CurrMainContext = Scene.CurrContext;
            mWindowEntity_1.CurrPlatform = mRoom;
            mWindowEntity_1.RelativePos = new Point(-95, -196.5);
            mWindowEntity_1.Width = 100;

            mWindowEntity_2 = new Glass();
            mWindowEntity_2.CurrMainContext = Scene.CurrContext;
            mWindowEntity_2.CurrPlatform = mRoom;
            mWindowEntity_2.RelativePos = new Point(55, -196.5);
            mWindowEntity_2.Width = 100;

            mGnuClayHuman = new RedSquareHuman();
            mGnuClayHuman.CurrMainContext = Scene.CurrContext;
            mGnuClayHuman.CurrPos = new Point(300, 300);
            //mGnuClayHuman.CurrPlatform = mRoom;
            //mGnuClayHuman.RelativePos = new Point(0, 0);

            var mGun = new Gun();

            //mGun.Id = "mGun";

            mGun.CurrMainContext = Scene.CurrContext;

            mGun.CurrPos = new Point(140, 140);

            //mGnuClayHuman.AddChild(mGun);

            //mGun.RelativePos = new Point(0, -10);

            var badHuman = new RedSquareHuman();
            badHuman.CurrMainContext = Scene.CurrContext;
            badHuman.CurrPos = new Point(250, 500);
            badHuman.CurrAngle = 180;

            existingsObjects.Add(new KeyValuePair<string, string>(mGun.Id, $"gun ({mGun.Id})"));

            Scene.CurrentActiveEntityController = new ActiveEntityController();

            //mGnuClayHuman.SetLogicalEntity(scene.CurrentActiveEntityController);

            //NLog.LogManager.GetCurrentClassLogger().Info($"mGnuClayHuman.Id = {mGnuClayHuman.Id}");

            var roundHuman = new LimeRoundHuman();
            roundHuman.CurrMainContext = Scene.CurrContext;
            roundHuman.CurrPos = new Point(150, 150); 

            roundHuman.SetLogicalEntity(Scene.CurrentActiveEntityController);

            existingsObjects.Add(new KeyValuePair<string, string>("gun", "gun"));

            Scene.CurrentActiveEntityController.ExistingObjectsList = existingsObjects;

            var tree = new Tree();
            tree.Width = 50;
            tree.CurrMainContext = Scene.CurrContext;
            tree.CurrPos = new Point(500, 500);

            tree = new Tree();
            tree.Width = 100;
            tree.CurrMainContext = Scene.CurrContext;
            tree.CurrPos = new Point(600, 600);
        }

        protected Block CreateBlock()
        {
            var tmpBlock = new Block();
            tmpBlock.CurrMainContext = Scene.CurrContext;
            tmpBlock.CurrPlatform = mRoom;
            return tmpBlock;
        }

        protected Block CreateVBlock()
        {
            var tmpBlock = CreateBlock();
            tmpBlock.Height = 50;
            return tmpBlock;
        }

        protected Block CreateHBlock()
        {
            var tmpBlock = CreateBlock();
            tmpBlock.Width = 50;
            return tmpBlock;
        }
    }
}
