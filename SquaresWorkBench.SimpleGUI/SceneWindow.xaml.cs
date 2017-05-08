using SquaresWorkBench.CommonEngine;
using SquaresWorkBench.TypicalCases;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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

            mCommandController = new CommandController(mScene);

            mActiveEntityController = (ActiveEntityController)mScene.CurrentActiveEntityController;

            mCommandController.ActiveEntityController = mActiveEntityController;

            mCommandController.SpeedComboBox = cbSpeed;
            mCommandController.ObjectsComboBox = cbExistingsObjects;
            mCommandController.CommandsForObjectsComboBox = cbActions;
            mCommandController.RunCommandForObjectButton = btnRun;
            mCommandController.StopButton = btnStop;
            mCommandController.DumpCoordsButton = btnGetCoords;
            mCommandController.WalkToGoalButton = btnWalkToGoal;
        }

        private Scene mScene = null;
        private CommandController mCommandController = null;
        private ActiveEntityController mActiveEntityController = null;
    }
}