using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine;
using GnuClay.Engine.Inheritance;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.OOP
{
    public class GnuClayLocalServerInheritanceQueryRunner
    {
        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            try
            {
                var tmpEngine = new GnuClayEngine();

                /*var queryString = "INSERT {>: {is(Dog, Animal)}}";

                var qr_1 = tmpEngine.Query(queryString);

                NLog.LogManager.GetCurrentClassLogger().Info($"qr_1 = {SelectResultDebugHelper.ConvertToString(qr_1, tmpEngine.DataDictionary)}");*/

                var tmpTKey = tmpEngine.DataDictionary.GetKey("T");
                var tmpAnimalKey = tmpEngine.DataDictionary.GetKey("Animal");
                var tmpPetKey = tmpEngine.DataDictionary.GetKey("Pet");
                var tmpDogKey = tmpEngine.DataDictionary.GetKey("Dog");

                var tmpInstanceName = _ObjectHelper.CreateName();
                var tmpInstanceKey = tmpEngine.DataDictionary.GetKey(tmpInstanceName);

                NLog.LogManager.GetCurrentClassLogger().Info($"Run tmpTKey = {tmpTKey}");
                NLog.LogManager.GetCurrentClassLogger().Info($"Run tmpAnimalKey = {tmpAnimalKey}");
                NLog.LogManager.GetCurrentClassLogger().Info($"Run tmpPetKey = {tmpPetKey}");
                NLog.LogManager.GetCurrentClassLogger().Info($"Run tmpDogKey = {tmpDogKey}");
                NLog.LogManager.GetCurrentClassLogger().Info($"Run tmpInstanceName = {tmpInstanceName}");
                NLog.LogManager.GetCurrentClassLogger().Info($"Run tmpInstanceKey = {tmpInstanceKey}");

                tmpEngine.Context.InheritanceEngine.SetInheritance(tmpAnimalKey, tmpTKey, 1, InheritanceAspect.WithOutClause);
                tmpEngine.Context.InheritanceEngine.SetInheritance(tmpDogKey, tmpAnimalKey, 1, InheritanceAspect.WithOutClause);
                //tmpEngine.Context.InheritanceEngine.SetInheritance(tmpDogKey, tmpAnimalKey, 0.5, InheritanceAspect.WithOutClause);
                tmpEngine.Context.InheritanceEngine.SetInheritance(tmpPetKey, tmpTKey, 1, InheritanceAspect.WithOutClause);
                tmpEngine.Context.InheritanceEngine.SetInheritance(tmpDogKey, tmpPetKey, 0.5, InheritanceAspect.WithOutClause);
                tmpEngine.Context.InheritanceEngine.SetInheritance(tmpInstanceKey, tmpDogKey, 1, InheritanceAspect.WithOutClause);
                //tmpEngine.Context.InheritanceEngine.SetInheritance(tmpAnimalKey, tmpInstanceKey, 1, InheritanceAspect.WithOutClause);

                var tmpListOfInheritance = tmpEngine.Context.InheritanceEngine.LoadListOfInheritance(tmpInstanceKey);

                foreach(var tmpInheritanceItem in tmpListOfInheritance)
                {
                    NLog.LogManager.GetCurrentClassLogger().Info($"tmpInheritanceItem = {tmpInheritanceItem}");
                }

                tmpListOfInheritance = tmpEngine.Context.InheritanceEngine.LoadListOfInheritance(tmpInstanceKey);

                foreach (var tmpInheritanceItem in tmpListOfInheritance)
                {
                    NLog.LogManager.GetCurrentClassLogger().Info($"tmpInheritanceItem = {tmpInheritanceItem}");
                }

                tmpEngine.Context.InheritanceEngine.SetInheritance(tmpInstanceKey, tmpDogKey, 0, InheritanceAspect.WithOutClause);

                NLog.LogManager.GetCurrentClassLogger().Info("Run Finish");
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e);
            }
        }
    }
}
