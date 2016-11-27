using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public abstract class BaseParserHandler
    {
        protected BaseParserHandler(ParsingContext context)
        {
            Context = context;
        }

        protected ParsingContext Context = null;

        public abstract void Dispatch(Token token);

        public virtual void CanIExit()
        {
            throw new AbnormalTerminationException();
        }

        public virtual void OnFinishChildHandler()
        {
        }

        public virtual void Exit()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Exit");
            Context.PopHandler();
        }
    }
}
