using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SquaresWorkBench.CommonEngine
{
    public static class ScenePersistHelper
    {
        public class EntityToInfoConverter
        {
            private Dictionary<BaseEntity, EntityInfo> mEntitiesDict = null;

            private List<EntityInfo> mResult = null;

            private void Init()
            {
                mEntitiesDict = new Dictionary<BaseEntity, EntityInfo>();

                mResult = new List<EntityInfo>();
            }

            public List<EntityInfo> Run(MainContext context)
            {
                Init();

                foreach (var entity in context.CurrMovator.EntitiesList)
                {
                    ProcessBaseEntity(entity);
                }

                return mResult;
            }

            private void ProcessBaseEntity(BaseEntity entity)
            {
                if (mEntitiesDict.ContainsKey(entity))
                {
                    return;
                }

                var tmpInfo = entity.CreateInfo();

                mEntitiesDict.Add(entity, tmpInfo);

                mResult.Add(tmpInfo);

                if (entity.CurrPlatform != null)
                {
                    ProcessBaseEntity(entity.CurrPlatform);

                    tmpInfo.CurrPlatform = mEntitiesDict[entity.CurrPlatform];
                }
            }
        }

        public class InfoToEntityConverter
        {
            private Dictionary<EntityInfo, BaseEntity> mDict = null;

            private MainContext mMainContext = null;

            private void Init(MainContext context)
            {
                mDict = new Dictionary<EntityInfo, BaseEntity>();
                mMainContext = context;
            }

            public void Run(List<EntityInfo> source, MainContext context)
            {
                Init(context);

                var tmpHasNoPlatformList = source.Where(p => p.CurrPlatform == null).ToList();

                foreach (var info in tmpHasNoPlatformList)
                {
                    ProcessWithNoPlatformEntity(info);
                }

                var tmpHasPlatformList = source.Where(p => p.CurrPlatform != null).ToList();

                foreach (var info in tmpHasPlatformList)
                {
                    ProcessWithPlatformEntity(info);
                }
            }

            private BaseEntity CreateEntity(EntityInfo info)
            {
                var tmpEntity = (BaseEntity)(Activator.CreateInstance(null, info.TypeName).Unwrap());

                mDict.Add(info, tmpEntity);

                tmpEntity.RestoreSecondaryProps(info);

                tmpEntity.CurrMainContext = mMainContext;

                return tmpEntity;
            }

            private void ProcessWithNoPlatformEntity(EntityInfo info)
            {
                if (mDict.ContainsKey(info))
                {
                    return;
                }

                var tmpEntity = CreateEntity(info);

                tmpEntity.CurrPos = info.CurrPos;

                tmpEntity.CurrAngle = info.CurrAngle;
            }

            private void ProcessWithPlatformEntity(EntityInfo info)
            {
                if (mDict.ContainsKey(info))
                {
                    return;
                }

                var tmpEntity = CreateEntity(info);

                tmpEntity.CurrPlatform = mDict[info.CurrPlatform];

                tmpEntity.RelativePos = info.RelativePos;
            }
        }

        public static SceneInfo ConvertSceneToInfo(MainContext context)
        {
            var tmpInfo = new SceneInfo();

            tmpInfo.CurrentViewer = context.CurrViewer.CreateInfo();

            var tmpEntityToInfoConverter = new EntityToInfoConverter();

            tmpInfo.EntitiesList = tmpEntityToInfoConverter.Run(context);

            return tmpInfo;
        }

        private static XmlSerializer CreateXmlSerializer()
        {
            var extraTypes = new Type[3];
            extraTypes[0] = typeof(ViewerInfo);
            extraTypes[1] = typeof(EntityInfo);
            extraTypes[2] = typeof(SecondaryPropertyInfo);

            return new XmlSerializer(typeof(SceneInfo), extraTypes);
        }

        public static void SerializeToXML(SceneInfo source, Stream stream)
        {
            var tmpSerializer = CreateXmlSerializer();

            tmpSerializer.Serialize(stream, source);
        }

        public static SceneInfo DeserializeFromXML(Stream stream)
        {
            var tmpSerializer = CreateXmlSerializer();

            return (SceneInfo)tmpSerializer.Deserialize(stream);
        }

        public static void RestoreScene(SceneInfo source, MainContext context)
        {
            context.CurrViewer.Assign(source.CurrentViewer);

            var tmpConvertor = new InfoToEntityConverter();

            tmpConvertor.Run(source.EntitiesList, context);
        }

        public static void SerializeToBinary(SceneInfo source, Stream stream)
        {
            var tmpSerializer = new BinaryFormatter();

            tmpSerializer.Serialize(stream, source);
        }

        public static SceneInfo DeserializeFromBinary(Stream stream)
        {
            var tmpSerializer = new BinaryFormatter();

            return (SceneInfo)tmpSerializer.Deserialize(stream);
        }
    }
}
