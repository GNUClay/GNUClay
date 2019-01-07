using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NavigationSupport
{
    public interface IStepOfRoute: IObjectToString, IObjectToBriefString, IShortObjectToString
    {
        IRoute Route { get; }
        IList<IPointInfo> TargetPoints { get; }
    }
}
