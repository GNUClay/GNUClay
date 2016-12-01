using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
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
            while ((CurrToken = Context.GetToken()) != null)
            {
                OnRun();

                if (mIsExited)
                {
                    OnFinish();
                    break;
                }
            }

            OnFinish();
            OnExit();
        }

        protected Token CurrToken = null;

        protected virtual void OnRun()
        {
        }

        protected virtual void OnExit()
        {
        }

        protected virtual void OnFinish()
        {
        }

        private bool mIsExited = false;

        protected void Exit()
        {
            mIsExited = true;
        }
    }
}
