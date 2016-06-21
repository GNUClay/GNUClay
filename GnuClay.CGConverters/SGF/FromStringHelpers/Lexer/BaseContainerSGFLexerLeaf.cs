using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Lexer
{
    public abstract class BaseContainerSGFLexerLeaf: BaseSGFLexerLeaf
    {
        protected BaseContainerSGFLexerLeaf(SGFLexerContext context, SGFTokenKind targetKind)
            : base(context)
        {
            mTargetKind = targetKind;
            mInitPos = Context.Pos;
        }

        private SGFTokenKind mTargetKind = SGFTokenKind.Undefined;

        private StringBuilder mBuffer = new StringBuilder();

        private int mInitPos = 0;

        public void AddChar(char ch)
        {
            mBuffer.Append(ch);
        }

        public override SGFToken CreateToken()
        {
            var tmpRez = base.CreateToken();

            tmpRez.Pos = mInitPos;

            return tmpRez;
        }

        protected override void OnExit()
        {
            var tmpToken = CreateToken();

            tmpToken.Content = mBuffer.ToString();

            tmpToken.Kind = mTargetKind;

            Context.AddToken(tmpToken);
        }
    }
}
