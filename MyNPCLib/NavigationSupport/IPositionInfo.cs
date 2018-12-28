using MyNPCLib.Logical;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MyNPCLib.NavigationSupport
{
    public interface IPositionInfo: IObjectToString
    {
        KindOfPoint KindOfPoint { get; }
        KindOfLocation KindOfLocation { get; }
        Vector3? Point { get; }
        IList<BaseAbstractLogicalObject> PlanesOfThePoint { get; }
    }
}
