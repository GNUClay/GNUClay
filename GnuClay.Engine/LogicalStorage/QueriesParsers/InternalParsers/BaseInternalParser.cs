using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.QueriesParsers.InternalParsers
{
    public abstract class BaseInternalParser
    {
        protected BaseInternalParser(InternalParserContext context)
        {
            Context = context;
        }

        protected InternalParserContext Context = null;

        public void Run()
        {
            while((CurrToken = Context.Read()) != null)
            {
                OnRun();
            }

            OnExit();
        }

        protected Token CurrToken = null;

        protected virtual void OnRun()
        {
        }

        protected virtual void OnExit()
        {
        }
    }
}
