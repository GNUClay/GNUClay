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
    public class Room_1_SoftCreator : BaseSoftCreator
    {
        protected override void OnRun(ISceneForSoftCreator scene)
        {
            var tmpRoom = new BaseRoom();

            tmpRoom.CurrMainContext = scene.CurrContext;

            tmpRoom.Height = 400;
            tmpRoom.Width = 400;

            tmpRoom.CurrPos = new Point(250, 250);

            var tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Height = 50;

            tmpBlock.RelativePos = new Point(-196.5, -175);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Height = 50;

            tmpBlock.RelativePos = new Point(-196.5, -125);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Height = 50;

            tmpBlock.RelativePos = new Point(-196.5, -75);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Height = 50;

            tmpBlock.RelativePos = new Point(-196.5, -25);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Height = 50;

            tmpBlock.RelativePos = new Point(-196.5, 25);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Height = 50;

            tmpBlock.RelativePos = new Point(-196.5, 75);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Height = 50;

            tmpBlock.RelativePos = new Point(-196.5, 125);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Height = 50;

            tmpBlock.RelativePos = new Point(-196.5, 175);

            //--
            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Height = 50;

            tmpBlock.RelativePos = new Point(196.5, -175);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Height = 50;

            tmpBlock.RelativePos = new Point(196.5, -125);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Height = 50;

            tmpBlock.RelativePos = new Point(196.5, -75);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Height = 50;

            tmpBlock.RelativePos = new Point(196.5, -25);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Height = 50;

            tmpBlock.RelativePos = new Point(196.5, 25);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Height = 50;

            tmpBlock.RelativePos = new Point(196.5, 75);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Height = 50;

            tmpBlock.RelativePos = new Point(196.5, 125);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Height = 50;

            tmpBlock.RelativePos = new Point(196.5, 175);
            //--

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Width = 50;

            tmpBlock.RelativePos = new Point(-170, -196.5);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Width = 50;

            tmpBlock.RelativePos = new Point(-20, -196.5);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Width = 50;

            tmpBlock.RelativePos = new Point(130, -196.5);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Width = 37;

            tmpBlock.RelativePos = new Point(175, -196.5);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Width = 50;

            tmpBlock.RelativePos = new Point(-170, 196.5);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Width = 50;

            tmpBlock.RelativePos = new Point(-120, 196.5);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Width = 50;

            tmpBlock.RelativePos = new Point(-70, 196.5);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Width = 50;

            tmpBlock.RelativePos = new Point(-20, 196.5);

            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Width = 50;

            tmpBlock.RelativePos = new Point(30, 196.5);


            tmpBlock = new Block();

            //tmpRoom.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Width = 50;

            tmpBlock.RelativePos = new Point(140, 196.5);

            tmpBlock = new Block();

            

            tmpBlock.CurrMainContext = scene.CurrContext;

            tmpBlock.CurrPlatform = tmpRoom;

            tmpBlock.Width = 27;

            tmpBlock.RelativePos = new Point(180, 196.5);
            //--
            var tmpDoor = new Door();

            tmpDoor.CurrMainContext = scene.CurrContext;

            tmpDoor.CurrPlatform = tmpRoom;

            tmpDoor.RelativePos = new Point(85, 196.5);

            tmpDoor.Width = 60;

            var tmpWindowEntity = new Glass();

            tmpWindowEntity.CurrMainContext = scene.CurrContext;

            tmpWindowEntity.CurrPlatform = tmpRoom;

            tmpWindowEntity.RelativePos = new Point(-95, -196.5);

            tmpWindowEntity.Width = 100;

            tmpWindowEntity = new Glass();

            tmpWindowEntity.CurrMainContext = scene.CurrContext;

            tmpWindowEntity.CurrPlatform = tmpRoom;

            tmpWindowEntity.RelativePos = new Point(55, -196.5);

            tmpWindowEntity.Width = 100;
        }
    }
}
