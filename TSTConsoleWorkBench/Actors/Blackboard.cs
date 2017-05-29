using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public delegate void OnChangeBlackboardCell(ulong key);

    public class Blackboard
    {
        private Dictionary<ulong, object> mValuesDict = new Dictionary<ulong, object>();

        public void SetValue(ulong key, object value)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"SetValue key = {key} value = {value}");

            throw new NotImplementedException();
        }

        public T GetValue<T>(ulong key)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"SetValue key = {key} typeof(T).FullName = {typeof(T).FullName}");

            if(mValuesDict.ContainsKey(key))
            {
                try
                {
                    return (T)mValuesDict[key];
                }
                catch
                {
                }
            }

            return default(T);
        }

        private event OnChangeBlackboardCell mOnChangeBlackboardCellEvent;


    }
}
