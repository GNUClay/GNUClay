using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    [Serializable]
    public enum GoDirectionFlag
    {
        Stop,
        Go,
        RotateLeft,
        GoAndRotateLeft,
        RotateRight,
        GoAndRotateRight
    }
}
