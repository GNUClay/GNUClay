using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System.Collections.Generic;

namespace GnuClay.Engine.StandardLibrary
{
    public class StandardLibraryEngine: BaseGnuClayEngineComponent
    {
        public StandardLibraryEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("StandardLibraryEngine");
        }

        public override void FirstInit()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("FirstInit CreateProviders");

            mNumberProvider = new NumberProvider(Context);
            mProvidersList.Add(mNumberProvider);
            
            FirstInitProviders();
        }

        private void FirstInitProviders()
        {
            foreach (var component in mProvidersList)
            {
                component.FirstInit();
            }
        }

        private List<BaseGnuClayEngineComponent> mProvidersList = new List<BaseGnuClayEngineComponent>();

        private NumberProvider mNumberProvider = null;

        public NumberProvider NumberProvider
        {
            get
            {
                return mNumberProvider;
            }
        }

        //private ArrayProvider mArrayProvider = null;

        //public ArrayProvider ArrayProvider
        //{
        //    get
        //    {
        //        return mArrayProvider;
        //    }
        //}

        //private IteratorProvider mIteratorProvider = null;

        //public IteratorProvider IteratorProvider
        //{
        //    get
        //    {
        //        return mIteratorProvider;
        //    }
        //}

        //private PropertyResultProvider mPropertyResultProvider = null;

        //public PropertyResultProvider PropertyResultProvider
        //{
        //    get
        //    {
        //        return mPropertyResultProvider;
        //    }
        //}

        //private PropertyResultIteratorProvider mPropertyResultIteratorProvider = null;

        //public PropertyResultIteratorProvider PropertyResultIteratorProvider
        //{
        //    get
        //    {
        //        return mPropertyResultIteratorProvider;
        //    }
        //}

        //private void RegProvider(BaseTypeProvider provider)
        //{
        //    mProvidersList.Add(provider);
        //}

        //private List<BaseTypeProvider> mProvidersList = new List<BaseTypeProvider>();

        public void InitFromZero()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("InitFromZero");
            //mProvidersList.ForEach(p => p.InitFromZero());
        }
    }
}
