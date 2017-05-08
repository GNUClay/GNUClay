using SquaresWorkBench.CommonEngine;
using SquaresWorkBench.TypicalCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SquaresWorkBench.SimpleGUI
{
    public class CommandController
    {
        public CommandController(Scene scene)
        {
            mScene = scene;
        }

        private ActiveEntityController mActiveEntityController = null;
        private Scene mScene = null;

        public ActiveEntityController ActiveEntityController
        {
            get
            {
                return mActiveEntityController;
            }

            set
            {
                mActiveEntityController = value;
            }
        }

        private ComboBox mSpeedComboBox = null;
        private Dictionary<int, double> mSpeedValues = new Dictionary<int, double>();
        private double mCurrentSpeed = 0;

        public ComboBox SpeedComboBox
        {
            get
            {
                return mSpeedComboBox;
            }

            set
            {
                if(mSpeedComboBox == value)
                {
                    return;
                }

                mSpeedComboBox = value;

                if(mSpeedComboBox == null)
                {
                    return;
                }

                InitSpeedComboBox();
            }
        }

        private void InitSpeedComboBox()
        {
            mSpeedComboBox.Items.Clear();

            for (var i = 1; i <= 10; i++)
            {
                var cbItem = new ComboBoxItem();
                cbItem.Content = i;

                var index = mSpeedComboBox.Items.Add(cbItem);
                mSpeedValues[index] = i;
            }
        }

        private double GetSpeed()
        {
            var index = mSpeedComboBox.SelectedIndex;

            if(!mSpeedValues.ContainsKey(index))
            {
                return 0;
            }

            return mSpeedValues[index];
        }

        private ComboBox mObjectsComboBox = null;
        private Dictionary<int, string> mObjectsDict = new Dictionary<int, string>();

        public ComboBox ObjectsComboBox
        {
            get
            {
                return mObjectsComboBox;
            }

            set
            {
                if(mObjectsComboBox == value)
                {
                    return;
                }

                mObjectsComboBox = value;

                if(mObjectsComboBox == null)
                {
                    return;
                }

                InitObjectsComboBox();
            }
        }

        private void InitObjectsComboBox()
        {
            var objList = mScene.ExistingObjectsList;

            mObjectsComboBox.Items.Clear();

            foreach (var objItem in objList)
            {
                var cbItem = new ComboBoxItem();
                cbItem.Content = objItem.Value;

                var index = mObjectsComboBox.Items.Add(cbItem);

                mObjectsDict[index] = objItem.Key;
            }
        }

        private string GetObject()
        {
            var index = mObjectsComboBox.SelectedIndex;

            if(!mObjectsDict.ContainsKey(index))
            {
                return string.Empty;
            }

            return mObjectsDict[index];
        }

        private ComboBox mCommandsForObjectsComboBox = null;
        private Dictionary<int, string> mCommandsForObjectsDict = new Dictionary<int, string>();

        public ComboBox CommandsForObjectsComboBox
        {
            get
            {
                return mCommandsForObjectsComboBox;
            }

            set
            {
                if(mCommandsForObjectsComboBox == value)
                {
                    return;
                }

                mCommandsForObjectsComboBox = value;

                if(mCommandsForObjectsComboBox == null)
                {
                    return;
                }

                InitCommadsForObjectsList();
            }
        }

        private void InitCommadsForObjectsList()
        {
            AddCommand("open");
            AddCommand("close");
            AddCommand("take");
            AddCommand("release");
            AddCommand("fire");
        }

        private void AddCommand(string name)
        {
            var cbItem = new ComboBoxItem();
            cbItem.Content = name;

            var index = mCommandsForObjectsComboBox.Items.Add(cbItem);

            mCommandsForObjectsDict[index] = name;
        }

        private string GetCommandForObjects()
        {
            var index = mCommandsForObjectsComboBox.SelectedIndex;

            if(!mCommandsForObjectsDict.ContainsKey(index))
            {
                return string.Empty;
            }

            return mCommandsForObjectsDict[index];
        }

        private Button mRunCommandForObjectButton = null;

        public Button RunCommandForObjectButton
        {
            get
            {
                return mRunCommandForObjectButton;
            }

            set
            {
                if(mRunCommandForObjectButton == value)
                {
                    return;
                }

                mRunCommandForObjectButton = value;

                if(mRunCommandForObjectButton == null)
                {
                    return;
                }

                mRunCommandForObjectButton.Click += RunCommandForObjectButton_Click;
            }
        }

        private void RunCommandForObjectButton_Click(object sender, RoutedEventArgs e)
        {
            var objName = GetObject();
            var cmdName = GetCommandForObjects();

            if(string.IsNullOrWhiteSpace(objName) && string.IsNullOrWhiteSpace(cmdName))
            {
                return;
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"RunCommandForObjectButton_Click objName = {objName} cmdName = {cmdName}");

            mActiveEntityController?.ExecuteUserCommand(new Command(cmdName, objName));
        }

        private Button mStopButton = null;

        public Button StopButton
        {
            get
            {
                return mStopButton;
            }

            set
            {
                if(mStopButton == value)
                {
                    return;
                }

                mStopButton = value;

                if(mStopButton == null)
                {
                    return;
                }

                mStopButton.Click += StopButton_Click;
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("StopButton_Click Not inmlemented Yet!!!!!");
        }

        private Button mDumpCoordsButton = null;

        public Button DumpCoordsButton
        {
            get
            {
                return mDumpCoordsButton;
            }

            set
            {
                if(mDumpCoordsButton == value)
                {
                    return;
                }

                mDumpCoordsButton = value;

                if (mDumpCoordsButton == null)
                {
                    return;
                }

                mDumpCoordsButton.Click += DumpCoordsButton_Click;
            }
        }

        private void DumpCoordsButton_Click(object sender, RoutedEventArgs e)
        {
            mActiveEntityController.DumpCoords();
        }

        private Button mWalkToGoalButton = null;

        public Button WalkToGoalButton
        {
            get
            {
                return mWalkToGoalButton;
            }

            set
            {
                if(mWalkToGoalButton == value)
                {
                    return;
                }

                mWalkToGoalButton = value;

                if (mWalkToGoalButton == null)
                {
                    return;
                }

                mWalkToGoalButton.Click += WalkToGoalButton_Click;
            }
        }

        private void WalkToGoalButton_Click(object sender, RoutedEventArgs e)
        {
            var objName = GetObject();

            if(string.IsNullOrWhiteSpace(objName))
            {
                return;
            }

            var speed = GetSpeed();

            if(speed == 0)
            {
                return;
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"WalkToGoalButton_Click objName = {objName} speed = {speed}");

            var command = new Command();
            command.Name = "walk";

            command.Params.Add("speed", speed);
            command.Params.Add("goal", objName);

            mActiveEntityController?.ExecuteUserCommand(command);
        }
    }
}

/*private void mSpeedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    mCurrentSpeed = mSpeedValues[mSpeedComboBox.SelectedIndex];

    NLog.LogManager.GetCurrentClassLogger().Info($"mSpeedComboBox mCurrentSpeed = {mCurrentSpeed}");
}*/
