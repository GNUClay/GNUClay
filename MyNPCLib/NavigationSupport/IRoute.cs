using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NavigationSupport
{
    public interface IRoute: IObjectToString, IObjectToBriefString, IShortObjectToString
    {
        IList<IStepOfRoute> NextSteps { get; }
        IList<IPointInfo> NextPoints { get; }
    }
}
