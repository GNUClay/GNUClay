using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine.TemporaryLogical
{
    public class ObjectsRegistry
    {
        private object mLockObj = new object();
        private Dictionary<string, List<string>> mObjectsDict = new Dictionary<string, List<string>>();

        public void RegObject(string instanceName, List<string> classes)
        {
            lock(mLockObj)
            {
                if (mObjectsDict.ContainsKey(instanceName))
                {
                    return;
                }

                NLog.LogManager.GetCurrentClassLogger().Info($"RegObject instanceName = {instanceName} classes = {classes.ListToString()}");

                mObjectsDict[instanceName] = classes;
            }
        }

        public bool Is(string instanceName, string classString)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"Is instanceName = {instanceName} classString = {classString}");

                if (mObjectsDict.ContainsKey(instanceName))
                {
                    var classesList = mObjectsDict[instanceName];

                    NLog.LogManager.GetCurrentClassLogger().Info(_ListHelper._ToString(classesList, $"Is {nameof(classesList)}"));

                    var targetClassesList = classString.StringToList();

                    NLog.LogManager.GetCurrentClassLogger().Info(_ListHelper._ToString(targetClassesList, $"Is {nameof(targetClassesList)}"));

                    return classesList.FullContains(targetClassesList);
                }

                return false;
            }
        }
    }
}
