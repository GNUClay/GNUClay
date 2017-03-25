using SquaresWorkBench.CommonEngine;
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
    /// Interaction logic for SceneWindow.xaml
    /// </summary>
    public partial class SceneWindow : Window
    {
        public SceneWindow(ISceneSoftCreator sceneCreator)
        {
            InitializeComponent();

            mScene = new Scene(mSw);

            sceneCreator.Run(mScene);
        }

        private Scene mScene = null;

        private void btnGoAhead_Click(object sender, RoutedEventArgs e)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("btnGoAhead_Click");
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("btnStop_Click");
        }

        private void btnGoLeft_Click(object sender, RoutedEventArgs e)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("btnGoLeft_Click");
        }

        private void btnGoRigth_Click(object sender, RoutedEventArgs e)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("btnGoRigth_Click");
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("btnGoBack_Click");
        }
    }
}
