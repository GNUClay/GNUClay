using GnuClay.Engine.Parser.InternalParsers;
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

                if(mIsExited)
                {
                    break;
                }
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

        private bool mIsExited = false;

        protected void Exit()
        {
            mIsExited = true;
        }
    }
}
