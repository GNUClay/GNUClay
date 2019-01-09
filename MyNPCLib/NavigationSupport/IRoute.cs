using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MyNPCLib.NavigationSupport
{
    public interface IRoute: IObjectToString, IObjectToBriefString, IShortObjectToString
    {
        StatusOfRoute Status { get; }
        Vector3 TargetPosition { get; }
        IList<IStepOfRoute> NextSteps { get; }
        IList<IPointInfo> NextPoints { get; }
    }
}
