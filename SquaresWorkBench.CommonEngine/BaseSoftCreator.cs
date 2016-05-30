using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public abstract class BaseSoftCreator : ISceneSoftCreator
    {
        public void Run(ISceneForSoftCreator scene)
        {
            scene.New();

            scene.BeginAddEntities();

            OnRun(scene);

            scene.EndAddEntities();
        }

        protected virtual void OnRun(ISceneForSoftCreator scene)
        {
        }
    }
}
