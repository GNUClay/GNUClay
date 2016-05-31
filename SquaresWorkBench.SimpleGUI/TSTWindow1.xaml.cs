using SquaresWorkBench.CommonEngine;
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
    /// Interaction logic for TSTWindow1.xaml
    /// </summary>
    public partial class TSTWindow1 : Window
    {
        public TSTWindow1()
        {
            InitializeComponent();

            mScene = new Scene(mSW);

            CreateMainScene();
        }

        private Scene mScene = null;

        private void CreateMainScene()
        {
            var tmpSceneCreator = new TSTSoftCreator();

            tmpSceneCreator.Run(mScene);
        }
    }
}
