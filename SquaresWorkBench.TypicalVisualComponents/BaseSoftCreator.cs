

using SquaresWorkBench.CommonEngine;
using System.Windows;

namespace SquaresWorkBench.TypicalVisualComponents
{
    public abstract class BaseSoftCreator : ISceneSoftCreator
    {
        public void Run(ISceneForSoftCreator scene)
        {
            Scene = scene;

            Scene.New();

            Scene.BeginAddEntities();

            CreateBorder();
            OnRun();

            Scene.EndAddEntities();
        }

        protected ISceneForSoftCreator Scene = null;

        private void CreateBorder()
        {
            var sceneWidth = Scene.Width;
            var sceneHalfWidth = sceneWidth / 2;

            var sceneHeight = Scene.Height;
            var sceneHalfHeight = sceneHeight / 2;

            var vBorderBlock = new VBorderBlock(sceneHeight);
            vBorderBlock.CurrMainContext = Scene.CurrContext;
            vBorderBlock.CurrPos = new Point(0, sceneHalfHeight);

            vBorderBlock = new VBorderBlock(sceneHeight);
            vBorderBlock.CurrMainContext = Scene.CurrContext;
            vBorderBlock.CurrPos = new Point(sceneWidth, sceneHalfHeight);

            var hHBorderBlock = new HBorderBlock(sceneWidth);
            hHBorderBlock.CurrMainContext = Scene.CurrContext;
            hHBorderBlock.CurrPos = new Point(sceneHalfWidth, 0);

            hHBorderBlock = new HBorderBlock(sceneWidth);
            hHBorderBlock.CurrMainContext = Scene.CurrContext;
            hHBorderBlock.CurrPos = new Point(sceneHalfWidth, sceneHeight);
        }

        protected virtual void OnRun()
        {
        }
    }
}
