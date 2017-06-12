using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.Actors
{
    public delegate void OnChangeBlackboardCell(ulong key);
    public delegate void OnChangeBlackboardCellWithValue(ulong key, object value);

    public class Blackboard
    {
        private object mLockObj = new object();
        private Dictionary<ulong, object> mValuesDict = new Dictionary<ulong, object>();

        public object this[ulong key]
        {
            get
            {
                return GetValue<object>(key);
            }

            set
            {
                SetValue(key, value);
            }
        }

        public void SetValue(ulong key, object value)
        {
            lock (mLockObj)
            {
                if (mValuesDict.ContainsKey(key))
                {
                    var currentValue = mValuesDict[key];

                    if (currentValue.Equals(value))
                    {
                        return;
                    }
                }
                else
                {
                    OnAddBlackboardCell.Invoke(key);
                    OnAddBlackboardCellWithValue.Invoke(key, value);
                }

                mValuesDict[key] = value;

                OnChangeBlackboardCell.Invoke(key);
                OnChangeBlackboardCellWithValue.Invoke(key, value);
            }
        }

        public T GetValue<T>(ulong key)
        {
            lock (mLockObj)
            {
                if (mValuesDict.ContainsKey(key))
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
        }

        public void RemoveKey(ulong key)
        {
            lock (mLockObj)
            {
                if (mValuesDict.ContainsKey(key))
                {
                    var value = mValuesDict[key];

                    mValuesDict.Remove(key);

                    OnRemoveBlackboardCell.Invoke(key);
                    OnRemoveBlackboardCellWithValue.Invoke(key, value);
                }
            }
        }

        public event OnChangeBlackboardCell OnAddBlackboardCell;
        public event OnChangeBlackboardCellWithValue OnAddBlackboardCellWithValue;
        public event OnChangeBlackboardCell OnChangeBlackboardCell;
        public event OnChangeBlackboardCellWithValue OnChangeBlackboardCellWithValue;
        public event OnChangeBlackboardCell OnRemoveBlackboardCell;
        public event OnChangeBlackboardCellWithValue OnRemoveBlackboardCellWithValue;
    }
}
