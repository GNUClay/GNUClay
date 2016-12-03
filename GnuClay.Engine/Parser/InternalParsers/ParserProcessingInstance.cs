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
            mContext.Lexer = new Lexer(queryText);
            var result = new GnuClayQuery();
            Token token = null;

            while((token = mContext.GetToken()) != null)
            {
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

                    case TokenKind.CALL:
                        result.Kind = GnuClayQueryKind.CALL;
                        var tmpInternalFunctionBodyParser = new InternalFunctionBodyParser(mContext);
                        tmpInternalFunctionBodyParser.Run();
                        result.ASTCodeBlock = tmpInternalFunctionBodyParser.Result;
                        break;

                    default: throw new UnexpectedTokenException(token);
                }
            }

            return result;
        }
    }
}
