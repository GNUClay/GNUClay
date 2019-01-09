using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MyNPCLib.NavigationSupport
{
    public interface IPointInfo: IObjectToString, IObjectToBriefString, IShortObjectToString
    {
        IRoute Route { get; }
        IStepOfRoute StepOfRoute { get; }
        bool IsFinal { get; }
        Vector3? Position { get; }
        bool IsFirstPartOfLink { get; }
    }
}
