﻿using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.Parser.CommonData;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class ParserProcessingInstance
    {
        public ParserProcessingInstance(GnuClayEngineComponentContext context)
        {
            mContext = new InternalParserContext();
            mContext.MainContext = context;         
        }

        private InternalParserContext mContext = null;

        public GnuClayQuery Parse(string queryText)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Parse queryText = `{queryText}`");

            mContext.Lexer = new Lexer(queryText);

            var result = new GnuClayQuery();

            Token token = null;

            while((token = mContext.GetToken()) != null)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"token = `{token}`");
                switch (token.TokenKind)
                {
                    case TokenKind.INSERT:
                        result.Kind = GnuClayQueryKind.INSERT;
                        mContext.Recovery(token);
                        var tmpInternalInsertQueryParser = new InternalInsertQueryParser(mContext);
                        tmpInternalInsertQueryParser.Run();
                        result.InsertQuery = tmpInternalInsertQueryParser.Result;
                        break;

                    case TokenKind.SELECT:
                        result.Kind = GnuClayQueryKind.SELECT;
                        mContext.Recovery(token);
                        var tmpInternalSelectQueryParser = new InternalSelectQueryParser(mContext);
                        tmpInternalSelectQueryParser.Run();
                        result.SelectQuery = tmpInternalSelectQueryParser.Result;
                        break;

                    default: throw new UndefinedTokenException(token.TokenKind);
                }
            }

            NLog.LogManager.GetCurrentClassLogger().Info("Finish");

            return result;
        }
    }
}
