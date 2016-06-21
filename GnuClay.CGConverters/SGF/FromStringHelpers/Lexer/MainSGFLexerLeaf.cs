using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Lexer
{
    public class MainSGFLexerLeaf: BaseSGFLexerLeaf
    {
        private enum State
        {
            Base,
            PreRightArrow,
            PreLeftArrow,
            PreNewLine
        }

        public MainSGFLexerLeaf(SGFLexerContext context)
            : base(context)
        {
        }

        private State mState = State.Base;

        protected override void ProcessChar(char ch)
        {
            switch(mState)
            {
                case State.Base:
                    ProcessChar_InBase(ch);
                    return;

                case State.PreRightArrow:
                    ProcessChar_InPreArrowRight(ch);
                    return;

                case State.PreLeftArrow:
                    ProcessChar_InPreArrowLeft(ch);
                    return;

                case State.PreNewLine:
                    ProcessChar_InPrePreNewLine(ch);
                    return;
            }
        }

        private void ProcessChar_InBase(char ch)
        {
            switch (ch)
            {
                case '[':
                    Context.AddToken(CreateToken(SGFTokenKind.OpenSquareBracket, "["));

                    return;

                case ']':
                    Context.AddToken(CreateToken(SGFTokenKind.CloseSquareBracket, "]"));

                    return;

                case '{':
                    Context.AddToken(CreateToken(SGFTokenKind.OpenFiguredBracket, "{"));

                    return;

                case '}':
                    Context.AddToken(CreateToken(SGFTokenKind.CloseFiguredBracket, "}"));

                    return;

                case '(':
                    Context.AddToken(CreateToken(SGFTokenKind.OpenRoundBracket, "("));

                    return;

                case ')':
                    Context.AddToken(CreateToken(SGFTokenKind.CloseRoundBracket, ")"));

                    return;

                case '"':
                    var tmpSubLeaf = new TwoQuotesSGFLexerLeaf(Context);

                    tmpSubLeaf.Run();

                    return;

                case ':':
                    Context.AddToken(CreateToken(SGFTokenKind.Colon, ":"));
                    return;

                case ';':
                    Context.AddToken(CreateToken(SGFTokenKind.Semicolon, ";"));
                    return;

                case '-':
                    mState = State.PreRightArrow;
                    return;

                case '<':
                    mState = State.PreLeftArrow;
                    return;

                case '←':
                    Context.AddToken(CreateToken(SGFTokenKind.LeftArrow, "<-"));
                    return;

                case '→':
                    Context.AddToken(CreateToken(SGFTokenKind.RightArrow, "->"));
                    return;

            }

            if (char.IsLetterOrDigit(ch) || ch == '_')
            {
                Context.Recovery(ch);

                var tmpSubLeaf = new IdentifierSGFLexerLeaf(Context);

                tmpSubLeaf.Run();

                return;
            }

            var tmpCharCode = (int)ch;

            switch(tmpCharCode)
            {
                case 13:
                    mState = State.PreNewLine;
                    return;

                case 32:
                    return;
            }

            throw CreateUndefinedTokenException(ch);
        }

        private void ProcessChar_InPreArrowRight(char ch)
        {
            switch(ch)
            {
                case '>':
                    Context.AddToken(CreateToken(SGFTokenKind.RightArrow, "->"));

                    mState = State.Base;

                    return;
            }

            throw CreateUndefinedTokenException(ch);
        }

        private void ProcessChar_InPreArrowLeft(char ch)
        {
            switch (ch)
            {
                case '-':
                    Context.AddToken(CreateToken(SGFTokenKind.LeftArrow, "<-"));

                    mState = State.Base;

                    return;
            }

            throw CreateUndefinedTokenException(ch);
        }

        private void ProcessChar_InPrePreNewLine(char ch)
        {
            var tmpCharCode = (int)ch;

            switch(tmpCharCode)
            {
                case 10:
                    mState = State.Base;
                    Context.NewLine();
                    return;
            }

            throw CreateUndefinedTokenException(ch);
        }
    }
}
