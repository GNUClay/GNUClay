using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NavigationSupport
{
    public interface IRoute: IObjectToString, IObjectToBriefString, IShortObjectToString
    {
        IPositionInfo Target { get; }
        IPositionInfo LocalTarget { get; }
        IList<IRoute> PossibleNextSteps { get; }
    }
}
