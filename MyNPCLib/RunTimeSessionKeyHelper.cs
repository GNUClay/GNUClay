using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib
{
    public static class RunTimeSessionKeyHelper
    {
        private static ulong mKey;
        private static readonly object mKeyLockObj = new object();

        public static ulong GeyKey()
        {
            lock(mKeyLockObj)
            {
                if(mKey == ulong.MaxValue - 1)
                {
                    mKey = 0ul;
                }

                mKey++;
                return mKey;
            }
        }
    }
}
