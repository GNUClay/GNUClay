using MyNPCLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TmpSandBox.Navigation
{
    public class TstNavigationRegistry
    {
        private List<TstPlane> mPlanesList = new List<TstPlane>();
        private List<TstWayPoint> mPointsList = new List<TstWayPoint>();
        private List<TstLinkOfPoints> mLinksOfPointsList = new List<TstLinkOfPoints>();
        private List<KeyValuePair<TstWayPoint, TstWayPoint>> mPointsOfLinksOfPointsList = new List<KeyValuePair<TstWayPoint, TstWayPoint>>();

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
        }

        private int mCurrIndex;
        private Dictionary<TstPlane, int> mIndexOfPlanesDict = new Dictionary<TstPlane, int>();
        private Dictionary<int, TstPlane> mBackIndexOfPlanesDict = new Dictionary<int, TstPlane>();
        private bool?[,] mPlanesDict;

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

                    if(intersectedPointsList.Count == 0)
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
            foreach(var path in listOfPaths)
            {
                var sb = new StringBuilder();

                foreach(var item in path)
                {
                    sb.Append($"{item.Name},");
                }
                sb.Remove(sb.Length - 1, 1);

                var str = sb.ToString().Replace(",", " -> ");

                LogInstance.Log(str);
            }
            LogInstance.Log("End");
#endif
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

            if(localPath.Count > 1)
            {
                result.Add(localPath.ToList());
            }

            var index = mIndexOfPlanesDict[plane];

#if DEBUG
            LogInstance.Log($"index = {index}");
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

                    FillPaths(nextPlane, localPath, ref result);
                }
            }
        }
    }
}
