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

            mActiveEntityController = mScene.CurrentActiveEntityController;

            var objList = mActiveEntityController.ExistingObjectsList;

            foreach(var objItem in objList)
            {
                var cbItem = new ComboBoxItem();
                cbItem.Content = objItem.Value;

                cbExistingsObjects.Items.Add(cbItem);
            }
        }

        private Scene mScene = null;
        private ActiveEntityController mActiveEntityController = null;

        private void btnGoAhead_Click(object sender, RoutedEventArgs e)
        {
            mActiveEntityController?.GoAhead();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mActiveEntityController?.Stop();
        }

        private void btnGoLeft_Click(object sender, RoutedEventArgs e)
        {
            mActiveEntityController?.GoLeft();
        }

        private void btnGoRigth_Click(object sender, RoutedEventArgs e)
        {
            mActiveEntityController?.GoRight();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            mActiveEntityController?.GoBack();
        }

        private void btnRotateLeft_Click(object sender, RoutedEventArgs e)
        {
            mActiveEntityController?.RotateLeft();
        }

        private void btnRotateRight_Click(object sender, RoutedEventArgs e)
        {
            mActiveEntityController?.RotateRight();
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("btnRun_Click");
        }
    }
}
