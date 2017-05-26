using GnuClay.CommonClientTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class CSharpTypesRegistry
    {
        public CSharpTypesRegistry(IGnuClayEntityConnection entityConnection)
        {
            mEntityConnection = entityConnection;
        }

        private IGnuClayEntityConnection mEntityConnection = null;

        public void AddType<T>(string typeName)
        {
            AddType(typeof(T), typeName);
        }

        public void AddType(Type type, string typeName)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddType type = `{type.FullName}` typeName = `{typeName}`");

            mNameDict[type] = typeName;

            var typeKey = mEntityConnection.GetKey(typeName);

            mKeyDict[type] = typeKey;
        }

        private Dictionary<Type, string> mNameDict = new Dictionary<Type, string>();
        private Dictionary<Type, ulong> mKeyDict = new Dictionary<Type, ulong>();

        public string GetTypeName(object value)
        {
            return NGetTypeName(value.GetType());
        }

        public string GetTypeName<T>()
        {
            return NGetTypeName(typeof(T));
        }

        private string NGetTypeName(Type type)
        {
            if (mNameDict.ContainsKey(type))
            {
                return mNameDict[type];
            }

            return string.Empty;
        }

        public ulong GetTypeKey(object value)
        {
            return NGetTypeKey(value.GetType());
        }

        public ulong GetTypeKey<T>()
        {
            return NGetTypeKey(typeof(T));
        }

        private ulong NGetTypeKey(Type type)
        {
            if (mKeyDict.ContainsKey(type))
            {
                return mKeyDict[type];
            }

            return 0;
        }
    }
}
