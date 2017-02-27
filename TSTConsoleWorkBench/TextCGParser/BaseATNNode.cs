using GnuClay.Engine.Parser.InternalParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public abstract class BaseATNNode
    {
        protected BaseATNNode(TextPhraseContext context, ATNParser parent)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");

            mParent = parent;
            mContext = context;
        }

        protected TextPhraseContext mContext = null;
        protected ATNParser mParent = null;

        protected static List<ExtendTokenGoal> ExtendTokenToGoals(ExtendToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ExtendTokenToGoals token = {token}");

            if (token.TokenKind != TokenKind.Word)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("ExtendTokenToGoals token.TokenKind != TokenKind.Word");

                throw new NotImplementedException();
                //return new List<ExtendTokenGoal>();
            }

            var partsOfSpeechList = token.PartOfSpeech;

            var result = new List<ExtendTokenGoal>();

            foreach (var partsOfSpeech in partsOfSpeechList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"ExtendTokenToGoals partsOfSpeech = {partsOfSpeech}");

                switch (partsOfSpeech)
                {
                    case GrammaticalPartOfSpeech.Article:
                        result.Add(ExtendTokenGoal.NP);
                        break;

                    case GrammaticalPartOfSpeech.Noun:
                        result.Add(ExtendTokenGoal.NP);
                        break;

                    case GrammaticalPartOfSpeech.Verb:
                        if (token.Is(VerbType.IngForm))
                        {
                            result.Add(ExtendTokenGoal.Ving);
                            break;
                        }

                        if (token.IsDoVerb)
                        {
                            result.Add(ExtendTokenGoal.FToDo);

                            if (token.Key == token.RootKey)
                            {
                                result.Add(ExtendTokenGoal.Do);
                            }
                        }

                        if (token.IsHaveVerb)
                        {
                            result.Add(ExtendTokenGoal.FToHave);
                        }

                        if (token.IsBeVerb)
                        {
                            result.Add(ExtendTokenGoal.FToBe);
                        }

                        if (token.IsWillVerb)
                        {
                            result.Add(ExtendTokenGoal.Will);
                        }

                        if (token.IsCanVerb)
                        {
                            result.Add(ExtendTokenGoal.Can);
                        }

                        if (token.IsCouldVerb)
                        {
                            result.Add(ExtendTokenGoal.Could);
                        }

                        if (token.IsMustVerb)
                        {
                            result.Add(ExtendTokenGoal.Must);
                        }

                        if (token.IsMayVerb)
                        {
                            result.Add(ExtendTokenGoal.May);
                        }

                        if (token.IsMightVerb)
                        {
                            result.Add(ExtendTokenGoal.Might);
                        }

                        result.Add(ExtendTokenGoal.V);

                        if (token.Is(VerbType.Form_3))
                        {
                            result.Add(ExtendTokenGoal.V3f);
                        }
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(partsOfSpeech), partsOfSpeech.ToString());
                }
            }

            return result;
        }
    }
}
