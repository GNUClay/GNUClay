using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer
{
    public class NodeNameLexerMainLeaf: NodeNameLexerBaseLeaf
    {
        public NodeNameLexerMainLeaf(NodeNameLexerContext context)
            : base(context)
        {
        }

        protected override void ProcessChar(char ch)
        {
            switch(ch)
            {
                case '(':
                    Context.AddToken(CreateToken(NodeNameTokenKind.OpenRoundBracket, "("));
                    return;

                case ')':
                    Context.AddToken(CreateToken(NodeNameTokenKind.CloseRoundBracket, ")"));
                    return;

                case ' ':
                    Context.AddToken(CreateToken(NodeNameTokenKind.Space, " "));
                    return;

                case '#':
                    Context.AddToken(CreateToken(NodeNameTokenKind.Octothorpe, "#"));
                    return;

                case '?':
                    Context.AddToken(CreateToken(NodeNameTokenKind.Question, "?"));
                    return;

                case ':':
                    Context.AddToken(CreateToken(NodeNameTokenKind.Colon, ":"));
                    return;

                case '*':
                    Context.AddToken(CreateToken(NodeNameTokenKind.UniversalQuantifier, "*"));
                    return;

                case '∀':
                    Context.AddToken(CreateToken(NodeNameTokenKind.UniversalQuantifier, "∀"));
                    return;

                case '∃':
                    Context.AddToken(CreateToken(NodeNameTokenKind.ExistentialQuantifier, "∃"));
                    return;

                case '`':
                    var tmpSubLeaf = new NodeNameLexerGraveStringLeaf(Context);

                    tmpSubLeaf.Run();

                    return;
            }
            
            if (char.IsLetterOrDigit(ch) || ch == '_')
            {
                Context.Recovery(ch);

                var tmpSubLeaf = new NodeNameLexerStringLeaf(Context);

                tmpSubLeaf.Run();

                return;
            }

            throw CreateUndefinedTokenException(ch);
        }
    }
}
