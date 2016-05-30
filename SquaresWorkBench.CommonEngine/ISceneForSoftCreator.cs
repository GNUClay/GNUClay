using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public interface ISceneForSoftCreator
    {
        void New();

        void BeginAddEntities();

        void EndAddEntities();

        MainContext CurrContext { get; }
    }
}
