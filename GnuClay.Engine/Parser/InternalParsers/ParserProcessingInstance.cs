using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.Parser.CommonData;
using System;
using System.Collections.Generic;

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

        public List<GnuClayQuery> Parse(string queryText)
        {
            mContext.Lexer = new Lexer(queryText);
            var result = new List<GnuClayQuery>();
            Token token = null;

            while((token = mContext.GetToken()) != null)
            {
                switch (token.TokenKind)
                {
                    case TokenKind.Word:
                        switch (token.KeyWordTokenKind)
                        {
                            case TokenKind.WRITE:
                            case TokenKind.REWRITE:
                                {
                                    var resultItem = new GnuClayQuery();
                                    resultItem.Kind = GnuClayQueryKind.INSERT;
                                    mContext.Recovery(token);
                                    var tmpInternalInsertQueryParser = new InternalInsertQueryParser(mContext);
                                    tmpInternalInsertQueryParser.Run();
                                    resultItem.InsertQuery = tmpInternalInsertQueryParser.Result;
                                    result.Add(resultItem);
                                }
                                break;

                            case TokenKind.READ:
                                {
                                    var resultItem = new GnuClayQuery();
                                    resultItem.Kind = GnuClayQueryKind.SELECT;
                                    mContext.Recovery(token);
                                    var tmpInternalSelectQueryParser = new InternalSelectQueryParser(mContext);
                                    tmpInternalSelectQueryParser.Run();
                                    resultItem.SelectQuery = tmpInternalSelectQueryParser.Result;
                                    result.Add(resultItem);
                                }
                                break;

                            case TokenKind.DELETE:
                                {
                                    var resultItem = new GnuClayQuery();
                                    resultItem.Kind = GnuClayQueryKind.DELETE;
                                    mContext.Recovery(token);
                                    var tmpInternalDeleteQueryParser = new InternalDeleteQueryParser(mContext);
                                    tmpInternalDeleteQueryParser.Run();
                                    resultItem.SelectQuery = tmpInternalDeleteQueryParser.Result;
                                    result.Add(resultItem);
                                }
                                break;

                            case TokenKind.CALL:
                                {
                                    var resultItem = new GnuClayQuery();
                                    resultItem.Kind = GnuClayQueryKind.CALL;
                                    var tmpInternalFunctionBodyParser = new InternalFunctionBodyParser(mContext);
                                    tmpInternalFunctionBodyParser.Run();
                                    resultItem.ASTCodeBlock = tmpInternalFunctionBodyParser.Result;
                                    result.Add(resultItem);
                                }
                                break;

                            case TokenKind.DEFINE:
                                {
                                    var tmpInternalDefineDirectiveParser = new InternalDefineDirectiveParser(mContext);
                                    tmpInternalDefineDirectiveParser.Run();
                                    var resultItem = tmpInternalDefineDirectiveParser.Result;
                                    result.Add(resultItem);
                                }
                                break;

                            default: throw new UnexpectedTokenException(token);
                        }
                        break;

                    default: throw new UnexpectedTokenException(token);
                }
            }

            return result;
        }
    }
}
