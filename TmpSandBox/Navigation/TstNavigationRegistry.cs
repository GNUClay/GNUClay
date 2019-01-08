using MyNPCLib;
using MyNPCLib.NavigationSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace TmpSandBox.Navigation
{
    public class TstNavigationRegistry
    {
        private List<TstPlane> mPlanesList = new List<TstPlane>();
        private List<TstWayPoint> mPointsList = new List<TstWayPoint>();
        private List<TstLinkOfPoints> mLinksOfPointsList = new List<TstLinkOfPoints>();
        private List<KeyValuePair<TstWayPoint, TstWayPoint>> mPointsOfLinksOfPointsList = new List<KeyValuePair<TstWayPoint, TstWayPoint>>();
        private Dictionary<TstWayPoint, List<TstLinkOfPoints>> mLinksOfPointsByPointDict = new Dictionary<TstWayPoint, List<TstLinkOfPoints>>();

        public void RegPlane(TstPlane plane)
        {
#if DEBUG
            LogInstance.Log($"plane = {plane}");
#endif
            mPlanesList.Add(plane);

            mIndexOfPlanesDict[plane] = mCurrIndex;
            mBackIndexOfPlanesDict[mCurrIndex] = plane;
            mCurrIndex++;
        }

        public void RegWayPoint(TstWayPoint wayPoint)
        {
#if DEBUG
            LogInstance.Log($"wayPoint = {wayPoint}");
#endif

            mPointsList.Add(wayPoint);

            foreach(var plane in wayPoint.PlanesList)
            {
                if(plane.PointsList.Contains(wayPoint))
                {
                    continue;
                }

                plane.PointsList.Add(wayPoint);
            }
        }

        public void RegLinkOfPoints(TstLinkOfPoints linkOfPoints)
        {
#if DEBUG
            LogInstance.Log($"linkOfPoints = {linkOfPoints}");
#endif

            mLinksOfPointsList.Add(linkOfPoints);

            mPointsOfLinksOfPointsList.Add(new KeyValuePair<TstWayPoint, TstWayPoint>(linkOfPoints.Point1, linkOfPoints.Point2));
            mPointsOfLinksOfPointsList.Add(new KeyValuePair<TstWayPoint, TstWayPoint>(linkOfPoints.Point2, linkOfPoints.Point1));

            RegLinkOfPointsByPoint(linkOfPoints.Point1, linkOfPoints);
            RegLinkOfPointsByPoint(linkOfPoints.Point2, linkOfPoints);
        }

        private void RegLinkOfPointsByPoint(TstWayPoint point, TstLinkOfPoints linkOfPoints)
        {
#if DEBUG
            LogInstance.Log($"point = {point}");
            LogInstance.Log($"linkOfPoints = {linkOfPoints}");
#endif

            if(mLinksOfPointsByPointDict.ContainsKey(point))
            {
                var targetList = mLinksOfPointsByPointDict[point];
                targetList.Add(linkOfPoints);
                return;
            }

            mLinksOfPointsByPointDict[point] = new List<TstLinkOfPoints>() { linkOfPoints };
        }

        private List<TstLinkOfPoints> GetLinkOfPointsByPoint(TstWayPoint point)
        {
            if (mLinksOfPointsByPointDict.ContainsKey(point))
            {
                return mLinksOfPointsByPointDict[point];
            }

            return new List<TstLinkOfPoints>();
        }

        private int mCurrIndex;
        private Dictionary<TstPlane, int> mIndexOfPlanesDict = new Dictionary<TstPlane, int>();
        private Dictionary<int, TstPlane> mBackIndexOfPlanesDict = new Dictionary<int, TstPlane>();
        private bool?[,] mPlanesDict;
        private Dictionary<TstPlane, Dictionary<TstPlane, IList<IList<TstPlane>>>> mPathsDict = new Dictionary<TstPlane, Dictionary<TstPlane, IList<IList<TstPlane>>>>();

        private Dictionary<TstPlane, Dictionary<TstPlane, IList<TstPlanesConnectionInfo>>> mPlanesConnectionDict = new Dictionary<TstPlane, Dictionary<TstPlane, IList<TstPlanesConnectionInfo>>>();

        private void RegConnectionPoint(TstPlane from, TstPlane to, IList<TstPlanesConnectionInfo> connectionsInfoList)
        {
            Dictionary<TstPlane, IList<TstPlanesConnectionInfo>> targetDict = null;

            if (mPlanesConnectionDict.ContainsKey(from))
            {
                targetDict = mPlanesConnectionDict[from];
            }
            else
            {
                targetDict = new Dictionary<TstPlane, IList<TstPlanesConnectionInfo>>();
                mPlanesConnectionDict[from] = targetDict;
            }

            targetDict[to] = connectionsInfoList;
        }

        private IList<TstPlanesConnectionInfo> GetConnectionPoints(TstPlane from, TstPlane to)
        {
            if (mPlanesConnectionDict.ContainsKey(from))
            {
                var targetDict = mPlanesConnectionDict[from];

                if(targetDict.ContainsKey(to))
                {
                    return targetDict[to];
                }
            }

            return new List<TstPlanesConnectionInfo>();
        }

        private IList<IList<TstPlane>> GetPathsListByPlanes(TstPlane startPlane, TstPlane targePlane)
        {
            if(mPathsDict.ContainsKey(startPlane))
            {
                var targetDict = mPathsDict[startPlane];

                if(targetDict.ContainsKey(targePlane))
                {
                    return targetDict[targePlane];
                }
            }

            return new List<IList<TstPlane>>();
        }

        public void CalculatePaths()
        {
#if DEBUG
            LogInstance.Log($"mPlanesList.Count = {mPlanesList.Count}");
            LogInstance.Log($"mPointsList.Count = {mPointsList.Count}");
            LogInstance.Log($"mLinksOfPointsList.Count = {mLinksOfPointsList.Count}");
#endif

            mPlanesDict = new bool?[mPlanesList.Count, mPlanesList.Count];
            var pointsOfLinksOfPointsDict = mPointsOfLinksOfPointsList.GroupBy(p => p.Key).ToDictionary(p => p.Key, p => p.Select(x => x.Value).ToList());

            var listOfPaths = new List<List<TstPlane>>();

            foreach (var outerPlane in mPlanesList)
            {
                foreach(var innerPlane in mPlanesList)
                {
                    var outerIndex = mIndexOfPlanesDict[outerPlane];
                    var innerIndex = mIndexOfPlanesDict[innerPlane];

#if DEBUG
                    LogInstance.Log($"outerIndex = {outerIndex} innerIndex = {innerIndex}");
#endif

                    if(outerIndex == innerIndex)
                    {
                        mPlanesDict[outerIndex, innerIndex] = null;
                        continue;
                    }

                    if(mPlanesDict[outerIndex, innerIndex] != null)
                    {
                        continue;
                    }

#if DEBUG
                    LogInstance.Log($"NEXT outerIndex = {outerIndex} innerIndex = {innerIndex}");
                    LogInstance.Log($"outerPlane = {outerPlane}");
                    LogInstance.Log($"innerPlane = {innerPlane}");
#endif

                    var connectionsList1 = new List<TstPlanesConnectionInfo>();
                    var connectionsList2 = new List<TstPlanesConnectionInfo>();

                    var outerPointsList = outerPlane.PointsList.ToList();

                    foreach(var outerPoint in outerPlane.PointsList)
                    {
#if DEBUG
                        LogInstance.Log($"outerPoint = {outerPoint}");
#endif

                        if (pointsOfLinksOfPointsDict.ContainsKey(outerPoint))
                        {
                            outerPointsList.AddRange(pointsOfLinksOfPointsDict[outerPoint]);
                        }
                    }

                    var innerPointsList = innerPlane.PointsList.ToList();

                    var directCommonPointsList = outerPlane.PointsList.Intersect(innerPlane.PointsList).ToList();

#if DEBUG
                    LogInstance.Log($"directCommonPointsList.Count = {directCommonPointsList.Count}");
#endif

                    foreach(var directCommonPoint in directCommonPointsList)
                    {
                        var directPointConnectionItem = new TstPlanesConnectionInfo();
                        directPointConnectionItem.IsDirect = true;
                        directPointConnectionItem.WayPoint = directCommonPoint;

                        connectionsList1.Add(directPointConnectionItem);
                        connectionsList2.Add(directPointConnectionItem);
                    }

                    foreach (var innerPoint in innerPlane.PointsList)
                    {
#if DEBUG
                        LogInstance.Log($"innerPoint = {innerPoint}");
#endif

                        if (pointsOfLinksOfPointsDict.ContainsKey(innerPoint))
                        {
                            innerPointsList.AddRange(pointsOfLinksOfPointsDict[innerPoint]);
                        }
                    }

                    var intersectedPointsList = outerPointsList.Intersect(innerPointsList).ToList();
#if DEBUG
                    LogInstance.Log($"intersectedPointsList.Count = {intersectedPointsList.Count}");
                    foreach(var intersectedPoint in intersectedPointsList)
                    {
                        LogInstance.Log($"intersectedPoint = {intersectedPoint}");
                    }
#endif

                    var indirectCommonPointsList = intersectedPointsList.Except(directCommonPointsList).ToList();

#if DEBUG
                    LogInstance.Log($"indirectCommonPointsList.Count = {indirectCommonPointsList.Count}");
                    foreach (var indirectCommonPoint in indirectCommonPointsList)
                    {
                        LogInstance.Log($"indirectCommonPoint = {indirectCommonPoint}");
                    }
#endif

                    foreach(var indirectCommonPoint in indirectCommonPointsList)
                    {
                        var directPointConnectionItem = new TstPlanesConnectionInfo();
                        directPointConnectionItem.IsDirect = false;
                        directPointConnectionItem.WayPoint = indirectCommonPoint;

                        var linksList = mLinksOfPointsByPointDict[indirectCommonPoint];
                        directPointConnectionItem.LinksList = linksList;

                        if (outerPlane.PointsList.Contains(indirectCommonPoint))
                        {
                            connectionsList1.Add(directPointConnectionItem);
                        }

                        if(innerPlane.PointsList.Contains(indirectCommonPoint))
                        {
                            connectionsList2.Add(directPointConnectionItem);
                        }               
                    }

#if DEBUG
                    LogInstance.Log($"connectionsList1.Count = {connectionsList1.Count}");
                    foreach (var connectionItem in connectionsList1)
                    {
                        LogInstance.Log($"connectionItem = {connectionItem}");
                    }

                    LogInstance.Log($"connectionsList2.Count = {connectionsList2.Count}");
                    foreach (var connectionItem in connectionsList2)
                    {
                        LogInstance.Log($"connectionItem = {connectionItem}");
                    }
#endif

                    RegConnectionPoint(outerPlane, innerPlane, connectionsList1);
                    RegConnectionPoint(innerPlane, outerPlane, connectionsList2);

                    if (intersectedPointsList.Count == 0)
                    {
                        mPlanesDict[outerIndex, innerIndex] = false;
                        mPlanesDict[innerIndex, outerIndex] = false;
                    }
                    else
                    {
                        mPlanesDict[outerIndex, innerIndex] = true;
                        mPlanesDict[innerIndex, outerIndex] = true;
                    }
                }
            }

#if DEBUG
            for(var outerIndex = 0; outerIndex < mPlanesList.Count; outerIndex++)
            {
                for (var innerIndex = 0; innerIndex < mPlanesList.Count; innerIndex++)
                {
                    LogInstance.Log($"mPlanesDict[{outerIndex}, {innerIndex}] = {mPlanesDict[outerIndex, innerIndex]}");
                }
            }
#endif

            for(var i = 0; i < mPlanesList.Count; i++)
            {
                var plane = mBackIndexOfPlanesDict[i];

#if DEBUG
                LogInstance.Log($"i = {i} plane = {plane}");
#endif

                FillPaths(plane, new List<TstPlane>(), ref listOfPaths);
            }

#if DEBUG
            LogInstance.Log($"listOfPaths.Count = {listOfPaths.Count}");
#endif

            var pathListForGrouping = new List<PathGroupItem>();

            foreach (var path in listOfPaths)
            {
                var firstItem = path.First();
                var lastItem = path.Last();

                var itemForGrouping = new PathGroupItem();
                itemForGrouping.FirstItem = firstItem;
                itemForGrouping.LastItem = lastItem;
                itemForGrouping.StepItems = path;

                pathListForGrouping.Add(itemForGrouping);

#if DEBUG
                var str = TstPathsHelper.DisplayPath(path);
                LogInstance.Log(str);
#endif
            }

            mPathsDict = pathListForGrouping.GroupBy(p => p.FirstItem).ToDictionary(p => p.Key, p => p.GroupBy(x => x.LastItem).ToDictionary(x => x.Key, x => (IList<IList<TstPlane>>)x.Select(y => y.StepItems).ToList()));

#if DEBUG
            LogInstance.Log("End");
#endif
        }

        private class PathGroupItem
        {
            public TstPlane FirstItem { get; set; }
            public TstPlane LastItem { get; set; }
            public IList<TstPlane> StepItems { get; set; }
        }

        private void FillPaths(TstPlane plane, List<TstPlane> localPath, ref List<List<TstPlane>> result)
        {
#if DEBUG
            LogInstance.Log($"plane = {plane}");
#endif

            if(localPath.Contains(plane))
            {
                return;
            }

            localPath.Add(plane);

#if DEBUG
            LogInstance.Log(TstPathsHelper.DisplayPath(localPath));
#endif

            if (localPath.Count > 1)
            {
                result.Add(localPath.ToList());
            }

            var index = mIndexOfPlanesDict[plane];

#if DEBUG
            LogInstance.Log($"index = {index} plane = {plane}");
#endif

            for (var i = 0; i < mPlanesList.Count; i++)
            {
                var nextLink = mPlanesDict[index, i];

#if DEBUG
                LogInstance.Log($"nextLink = {nextLink}");
#endif

                if(nextLink == true)
                {
                    var nextPlane = mBackIndexOfPlanesDict[i];

#if DEBUG
                    LogInstance.Log($"nextPlane = {nextPlane}");
#endif

                    FillPaths(nextPlane, localPath.ToList(), ref result);
                }
            }
        }

        public IList<TstPlane> GetPlanesByPoint(Vector3 position)
        {
#if DEBUG
            LogInstance.Log($"position = {position}");
#endif

            var result = new List<TstPlane>();

            foreach(var plane in mPlanesList)
            {
                if (plane.Contains(position))
                {
                    result.Add(plane);
                }
            }

            return result;
        }

        public IRoute GetRouteForPosition(IPointInfo pointInfo)
        {
#if DEBUG
            LogInstance.Log($"pointInfo = {pointInfo}");
#endif

            if(pointInfo.IsFirstPartOfLink)
            {
                return NGetRouteForPositionOfFirstPartOfLink(pointInfo);
            }

            return GetRouteForPosition(pointInfo.Position.Value, pointInfo.Route.TargetPosition);
        }

        private IRoute NGetRouteForPositionOfFirstPartOfLink(IPointInfo pointInfo)
        {
#if DEBUG
            LogInstance.Log($"pointInfo = {pointInfo}");
#endif

            var tstPointInfo = (TstPointInfo)pointInfo;

            var initialRoute = pointInfo.Route;

#if DEBUG
            LogInstance.Log($"initialRoute = {initialRoute}");
#endif

            var stepOfRoute = (TstStepOfRoute)pointInfo.StepOfRoute;

#if DEBUG
            LogInstance.Log($"stepOfRoute = {stepOfRoute}");
#endif

            var currentPlane = stepOfRoute.CurrentPlane;

            var nextPathsList = new List<IList<TstPlane>>();

            foreach (var path in stepOfRoute.PathsList)
            {
#if DEBUG
                LogInstance.Log(TstPathsHelper.DisplayPath(path));
#endif

                var firstItem = path.First();

#if DEBUG
                LogInstance.Log($"firstItem = {firstItem}");
#endif

                if(firstItem != currentPlane)
                {
                    continue;
                }

                path.Remove(firstItem);

#if DEBUG
                LogInstance.Log(TstPathsHelper.DisplayPath(path));
#endif

                nextPathsList.Add(path);
            }

            var nextPathsDict = nextPathsList.GroupBy(p => p.First()).ToDictionary(p => p.Key, p => p.ToList());

#if DEBUG
            LogInstance.Log($"nextPathsDict.Count = {nextPathsDict.Count}");
#endif

            var result = new TstRoute();
            result.TargetPosition = initialRoute.TargetPosition;

            var linksList = GetLinkOfPointsByPoint(tstPointInfo.WayPoint);

            var nextPointsList = linksList.Where(p => p.Point1 == tstPointInfo.WayPoint).Select(p => p.Point2).ToList();
            nextPointsList.AddRange(linksList.Where(p => p.Point2 == tstPointInfo.WayPoint).Select(p => p.Point1));

#if DEBUG
            LogInstance.Log($"nextPointsList.Count = {nextPointsList.Count}");
            foreach(var link in nextPointsList)
            {
                LogInstance.Log($"link = {link}");
            }
#endif

            var stepOfRouteDicts = new Dictionary<TstPlane, TstStepOfRoute>();

            foreach (var nextPathsKVPItem in nextPathsDict)
            {
                var firstItem = nextPathsKVPItem.Key;
#if DEBUG
                LogInstance.Log($"firstItem = {firstItem}");
#endif

                var targetPointsList = nextPointsList.Where(p => p.PlanesList.Contains(firstItem)).ToList();

#if DEBUG
                LogInstance.Log($"targetPointsList.Count = {targetPointsList.Count}");
#endif

                if(targetPointsList.Count == 0)
                {
                    continue;
                }

                var pathsList = nextPathsKVPItem.Value;

                foreach (var targetPoint in targetPointsList)
                {
#if DEBUG
                    LogInstance.Log($"targetPoint = {targetPoint}");
#endif
                    TstStepOfRoute targetStepOfRoute = null;

                    if (stepOfRouteDicts.ContainsKey(firstItem))
                    {
                        targetStepOfRoute = stepOfRouteDicts[firstItem];
                    }
                    else
                    {
                        targetStepOfRoute = new TstStepOfRoute();
                        stepOfRouteDicts[firstItem] = targetStepOfRoute;
                        targetStepOfRoute.CurrentPlane = firstItem;
                        result.NextSteps.Add(targetStepOfRoute);
                    }

                    foreach(var path in pathsList)
                    {
                        stepOfRoute.PathsList.Add(path);
                    }
                    
                    var targetPointInfo = new TstPointInfo();
                    targetPointInfo.Route = result;
                    targetPointInfo.StepOfRoute = targetStepOfRoute;
                    targetPointInfo.Position = targetPoint.Position;
                    targetPointInfo.WayPoint = targetPoint;
                    targetPointInfo.Plane = firstItem;

                    result.NextPoints.Add(targetPointInfo);
                    targetStepOfRoute.TargetPoints.Add(targetPointInfo);
                }
            }

            return result;
        }

        public IRoute GetRouteForPosition(Vector3 startPosition, Vector3 targetPosition)
        {
#if DEBUG
            LogInstance.Log($"startPosition = {startPosition}");
            LogInstance.Log($"targetPosition = {targetPosition}");
#endif

            var initialPathsList = GetPathsListForPosition(startPosition, targetPosition);

#if DEBUG
            LogInstance.Log($"initialPathsList.Count = {initialPathsList.Count}");
#endif

            var result = new TstRoute();
            result.TargetPosition = targetPosition;

            if (initialPathsList.Count == 0)
            {
                return result;
            }

            result.InitPathsList = initialPathsList.SelectMany(p => p.PathsList).ToList();

            var stepOfRouteDicts = new Dictionary<TstPlane, TstStepOfRoute>();

            foreach (var initialPathsItem in initialPathsList)
            {
                var pathsList = initialPathsItem.PathsList;

#if DEBUG
                LogInstance.Log($"pathsList.Count = {pathsList.Count}");
#endif

                foreach (var path in pathsList)
                {
#if DEBUG
                    LogInstance.Log(TstPathsHelper.DisplayPath(path));
#endif

                    var firstItem = path.First();

#if DEBUG
                    LogInstance.Log($"firstItem.Name = {firstItem.Name}");
#endif

                    var originPath = path.ToList();

                    path.Remove(firstItem);

#if DEBUG
                    LogInstance.Log($"path.Count = {path.Count}");
#endif

                    var nextItem = path.First();

#if DEBUG
                    LogInstance.Log(TstPathsHelper.DisplayPath(originPath));
                    LogInstance.Log($"firstItem.Name = {firstItem.Name}");
                    LogInstance.Log($"nextItem.Name = {nextItem.Name}");
                    LogInstance.Log(TstPathsHelper.DisplayPath(path));
#endif

                    var connectionList = GetConnectionPoints(firstItem, nextItem);

                    if(connectionList.Count == 0)
                    {
                        throw new NotSupportedException();
                    }

#if DEBUG
                    LogInstance.Log($"connectionList.Count = {connectionList.Count}");
#endif

                    foreach (var connection in connectionList)
                    {
#if DEBUG
                        LogInstance.Log($"connection = {connection}");
#endif

                        TstStepOfRoute stepOfRoute = null;

                        if(connection.IsDirect)
                        {
                            if (stepOfRouteDicts.ContainsKey(nextItem))
                            {
                                stepOfRoute = stepOfRouteDicts[nextItem];
                            }
                            else
                            {
                                stepOfRoute = new TstStepOfRoute();
                                stepOfRouteDicts[nextItem] = stepOfRoute;
                                stepOfRoute.CurrentPlane = nextItem;
                                result.NextSteps.Add(stepOfRoute);
                            }

                            stepOfRoute.PathsList.Add(path);

                            var pointInfo = new TstPointInfo();
                            pointInfo.Route = result;
                            pointInfo.StepOfRoute = stepOfRoute;
                            pointInfo.Position = connection.WayPoint.Position;
                            pointInfo.WayPoint = connection.WayPoint;
                            pointInfo.Plane = nextItem;

                            result.NextPoints.Add(pointInfo);
                            stepOfRoute.TargetPoints.Add(pointInfo);
                        }
                        else
                        {
                            if (stepOfRouteDicts.ContainsKey(firstItem))
                            {
                                stepOfRoute = stepOfRouteDicts[firstItem];
                            }
                            else
                            {
                                stepOfRoute = new TstStepOfRoute();
                                stepOfRouteDicts[firstItem] = stepOfRoute;
                                stepOfRoute.CurrentPlane = firstItem;
                                result.NextSteps.Add(stepOfRoute);
                            }

                            stepOfRoute.PathsList.Add(originPath);

                            var pointInfo = new TstPointInfo();
                            pointInfo.Route = result;
                            pointInfo.StepOfRoute = stepOfRoute;
                            pointInfo.Position = connection.WayPoint.Position;
                            pointInfo.WayPoint = connection.WayPoint;
                            pointInfo.Plane = firstItem;
                            pointInfo.IsFirstPartOfLink = true;

                            result.NextPoints.Add(pointInfo);
                            stepOfRoute.TargetPoints.Add(pointInfo);
                        }

#if DEBUG
                        LogInstance.Log($"stepOfRoute = {stepOfRoute}");
#endif
                    }
                }
            }

            return result;
        }

        private class PathInfo
        {
            public TstPlane FirstItem { get; set; }
            public TstPlane LastItem { get; set; }
            public IList<IList<TstPlane>> PathsList { get; set; }
        }

        private List<PathInfo> GetPathsListForPosition(Vector3 startPosition, Vector3 targetPosition)
        {
#if DEBUG
            LogInstance.Log($"startPosition = {startPosition}");
            LogInstance.Log($"targetPosition = {targetPosition}");
#endif

            var planesListForStartPosition = GetPlanesByPoint(startPosition);

#if DEBUG
            LogInstance.Log($"planesListForStartPosition.Count = {planesListForStartPosition.Count}");
            foreach(var item in planesListForStartPosition)
            {
                LogInstance.Log($"item.Name = {item.Name}");
            }
#endif

            if (planesListForStartPosition.Count == 0)
            {
                return new List<PathInfo>();
            }

            var planesListForTargetPosition = GetPlanesByPoint(targetPosition);

#if DEBUG
            LogInstance.Log($"planesListForTargetPosition.Count = {planesListForTargetPosition.Count}");
            foreach (var item in planesListForTargetPosition)
            {
                LogInstance.Log($"item.Name = {item.Name}");
            }
#endif

            if(planesListForTargetPosition.Count == 0)
            {
                return new List<PathInfo>();
            }

            var result = new List<PathInfo>();

            foreach (var startPlane in planesListForStartPosition)
            {
                foreach(var targetPlane in planesListForTargetPosition)
                {
                    var pathsList = GetPathsListByPlanes(startPlane, targetPlane);

                    if(pathsList.Count == 0)
                    {
                        continue;
                    }

#if DEBUG
                    LogInstance.Log($"pathsList.Count = {pathsList.Count}");
                    foreach(var path in pathsList)
                    {
                        LogInstance.Log(TstPathsHelper.DisplayPath(path));
                    }
#endif

                    var item = new PathInfo();
                    item.FirstItem = startPlane;
                    item.LastItem = targetPlane;
                    item.PathsList = pathsList;
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
