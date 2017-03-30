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

            InitObjectsList();
            InitCommadsList();
        }

        private Scene mScene = null;
        private ActiveEntityController mActiveEntityController = null;

        private void InitObjectsList()
        {
            if (mActiveEntityController != null)
            {
                var objList = mActiveEntityController.ExistingObjectsList;

                var objIndex = -1;

                foreach (var objItem in objList)
                {
                    var cbItem = new ComboBoxItem();
                    cbItem.Content = objItem.Value;

                    cbExistingsObjects.Items.Add(cbItem);

                    objIndex++;

                    mObjectsDict[objIndex] = objItem.Key;
                }
            }
        }

        private Dictionary<int, string> mObjectsDict = new Dictionary<int, string>();
        private Dictionary<int, string> mCommandsDict = new Dictionary<int, string>();

        private void InitCommadsList()
        {
            AddCommand("open");
            AddCommand("close");
            AddCommand("take");
            AddCommand("release");
            AddCommand("fire");
        }

        private int mCommandIndex = -1;

        private void AddCommand(string name)
        {
            mCommandIndex++;

            var cbItem = new ComboBoxItem();
            cbItem.Content = name;

            cbActions.Items.Add(cbItem);

            mCommandsDict[mCommandIndex] = name;
        }

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
            var objSelIndex = cbExistingsObjects.SelectedIndex;
            var cmdSelIndex = cbActions.SelectedIndex;

            NLog.LogManager.GetCurrentClassLogger().Info($"btnRun_Click objSelIndex = {objSelIndex} cmdSelIndex = {cmdSelIndex}");

            if(objSelIndex == -1 || cmdSelIndex == -1)
            {
                return;
            }

            var objName = mObjectsDict[objSelIndex];
            var cmdName = mCommandsDict[cmdSelIndex];

            mActiveEntityController?.ExecuteCommand(objName, cmdName);
        }

        private void cbSpeed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var targetSpeed = cbSpeed.SelectedIndex + 1;

            if(targetSpeed == 0)
            {
                return;
            }

            mActiveEntityController?.SetSpeed(targetSpeed);
        }
    }
}
