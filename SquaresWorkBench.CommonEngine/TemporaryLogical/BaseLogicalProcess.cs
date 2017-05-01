using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine.TemporaryLogical
{
    public abstract class BaseLogicalProcess
    {
        protected BaseLogicalProcess()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor()");
        }

        public BaseLogicalEntity LogicalEntity { get; set; }

        private List<ActionCommandFilter> mFiltersList = null;

        public List<ActionCommandFilter> GetFilters()
        {
            mFiltersList = new List<ActionCommandFilter>();

            OnRegFilter();

            return mFiltersList;
        }

        protected virtual void OnRegFilter()
        {
        }

        protected void AddFilter(ActionCommandFilter filter)
        {
            mFiltersList.Add(filter);
        }
    }
}
