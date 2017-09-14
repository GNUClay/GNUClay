using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalParserContext
    {
        public Lexer Lexer = null;
        public GnuClayEngineComponentContext MainContext = null;

        private Queue<Token> mRecoveriesTokens = new Queue<Token>();

        public List<RuleInstance> ListOfInlineFacts;

        public Token GetToken()
        {
            if(mRecoveriesTokens.Count == 0)
            {
                return Lexer.GetToken();
            }

            return mRecoveriesTokens.Dequeue();
        }

        public void Recovery(Token token)
        {
            mRecoveriesTokens.Enqueue(token);
        }

        public bool IsEmpty()
        {
            var tmpToken = GetToken();

            if(tmpToken == null)
            {
                return true;
            }

            Recovery(tmpToken);

            return false;
        }

        /// <summary>
        /// Number of remaining characters.
        /// </summary>
        public int Count
        {
            get
            {
                return mRecoveriesTokens.Count + Lexer.Count;
            }
        }

        public InternalParserContext Fork()
        {
            var result = new InternalParserContext();
            result.MainContext = MainContext;
            result.Lexer = Lexer.Fork();
            result.mRecoveriesTokens = new Queue<Token>(mRecoveriesTokens);
            if(ListOfInlineFacts != null)
            {
                result.ListOfInlineFacts = new List<RuleInstance>(ListOfInlineFacts); 
            }
            return result;
        }

        public void Assing(InternalParserContext context)
        {
            Lexer.Assing(context.Lexer);
            mRecoveriesTokens = new Queue<Token>(context.mRecoveriesTokens);
            if (context.ListOfInlineFacts != null)
            {
                ListOfInlineFacts = context.ListOfInlineFacts;
            }
        }
    }
}
