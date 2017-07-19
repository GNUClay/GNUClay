using GnuClay.Engine.InternalCommonData;

namespace GnuClay.Engine.StandardLibrary
{
    public class StandardLibraryEngine: BaseGnuClayEngineComponent
    {
        public StandardLibraryEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("StandardLibraryEngine");
        }

        public void CreateProviders()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("CreateProviders");
        }

        //private NumberProvider mNumberProvider = null;

        //public NumberProvider NumberProvider
        //{
        //    get
        //    {
        //        return mNumberProvider;
        //    }
        //}

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
