using MyNPCLib.NavigationSupport;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MyNPCLib
{
    public interface INavigationRegistry
    {
        IRoute GetRouteForPosition(IPointInfo pointInfo);
        IRoute GetRouteForPosition(Vector3 startPosition, Vector3 targetPosition);
    }
}
