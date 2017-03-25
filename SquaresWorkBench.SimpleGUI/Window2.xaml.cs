﻿using SquaresWorkBench.CommonEngine;
using SquaresWorkBench.TypicalCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SquaresWorkBench.SimpleGUI
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();

            mScene = new Scene(mSw);

            CreateMainScene();
            //CreateRoomScene();
        }

        private Scene mScene = null;

        private void CreateMainScene()
        {
            var tmpSceneCreator = new TSTSoftCreator();

            tmpSceneCreator.Run(mScene);
        }

        private void CreateRoomScene()
        {
            var tmpSceneCreator = new Room_1_SoftCreator();

            tmpSceneCreator.Run(mScene);
        }
    }
}
