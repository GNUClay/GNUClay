using MyNPCLib;
using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing_v2;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using OpenNLP.Tools.SentenceDetect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TmpSandBox
{
    public class TSTSentenceParser
    {
        private enum State
        {
            Init,
            CalculateTotalCount,
            Run
        }

        public TSTSentenceParser()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            var modelPath = OpenNLPPathsHelper.EnglishSDnbinPath(basePath);
#if DEBUG
            LogInstance.Log($"modelPath = {modelPath}");
#endif

            mSentenceDetector = new EnglishMaximumEntropySentenceDetector(modelPath);

            mWordsDict = new WordsDict();

#if DEBUG
            //var wordFrame = mWordsDict.GetWordFrame("green");
            //LogInstance.Log($"wordFrame = {wordFrame}");
#endif
        }

        public void Run()
        {
            mState = State.CalculateTotalCount;
            ProcessAllSentences();
            mState = State.Run;
            mTargetImpl = new TSTSentenceParserImpl(mWordsDict, AppDomain.CurrentDomain.BaseDirectory, mSentenceDetector);
            ProcessAllSentences();
        }

        public void DetectUnknownWords()
        {
            mState = State.CalculateTotalCount;
            ProcessAllSentences();
            mState = State.Run;

            var unknownWordsList = new List<string>();

            mTargetImpl = new TSTSentenceParserUnknownWordsDetectorImpl(mWordsDict, AppDomain.CurrentDomain.BaseDirectory, mSentenceDetector, unknownWordsList);
            ProcessAllSentences();

            unknownWordsList = unknownWordsList.Distinct().ToList();

            LogInstance.Log($"unknownWordsList.Count = {unknownWordsList.Count}");
            foreach(var unknownWord in unknownWordsList)
            {
                LogInstance.Log($"unknownWord = {unknownWord}");
            }
        }

        private void ProcessAllSentences()
        {
            LogInstance.Log("Begin");

            //Active: Present Simple
            var sentence = "I play.";
            NParsingSentence(sentence, false);

            sentence = "Do I play?";
            NParsingSentence(sentence, false);

            sentence = "I do not play.";
            NParsingSentence(sentence, false);

            sentence = "We do our work with pleasure.";
            NParsingSentence(sentence, false);

            sentence = "The meeting starts at 6 o'clock.";
            NParsingSentence(sentence, false);

            sentence = "Who does know the dog?";
            NParsingSentence(sentence, false);

            //sentence = "Who does not know the dog?";
            //NParsingSentence(sentence, false);

            //sentence = "Which of them do not I know?";
            //NParsingSentence(sentence, false);

            sentence = "Which of them do I know?";
            NParsingSentence(sentence, false);

            //Passive: Present Simple
            sentence = "Space is explored.";
            NParsingSentence(sentence, false);

            sentence = "Is space explored.";
            NParsingSentence(sentence, false);

            sentence = "What is explored.";
            NParsingSentence(sentence, false);

            sentence = "Space is not explored.";
            NParsingSentence(sentence, false);

            //Active: Past Simple
            sentence = "I played.";
            NParsingSentence(sentence, false);

            sentence = "Did I play?";
            NParsingSentence(sentence, false);

            sentence = "I did not play.";
            NParsingSentence(sentence, false);

            sentence = "Who did know the dog?";
            NParsingSentence(sentence, false);

            sentence = "Which of them did I know?";
            NParsingSentence(sentence, false);

            //sentence = "Which of them did not I know?";
            //NParsingSentence(sentence, false);

            //Passive: Past Simple
            sentence = "Space was explored.";
            NParsingSentence(sentence, false);

            sentence = "Space was not explored.";
            NParsingSentence(sentence, false);

            sentence = "Was space explored?";
            NParsingSentence(sentence, false);

            sentence = "What was explored?";
            NParsingSentence(sentence, false);

            //Active: Future Simple
            sentence = "I will play.";
            NParsingSentence(sentence, false);

            sentence = "Will I play?";
            NParsingSentence(sentence, false);

            sentence = "I will not play.";
            NParsingSentence(sentence, false);

            sentence = "Who will know the dog?";
            NParsingSentence(sentence, false);

            sentence = "Who will not know the dog?";
            NParsingSentence(sentence, false);

            sentence = "Which dog will I know?";
            NParsingSentence(sentence, false);

            //Passive: Future Simple
            sentence = "Space will be explored.";
            NParsingSentence(sentence, false);

            sentence = "Will space be explored?";
            NParsingSentence(sentence, false);

            sentence = "What will be explored?";
            NParsingSentence(sentence, false);

            sentence = "Space will not be explored.";
            NParsingSentence(sentence, false);

            //Active: Present Continuous
            sentence = "I am playing.";
            NParsingSentence(sentence, false);

            sentence = "Am I playing?";
            NParsingSentence(sentence, false);

            sentence = "I am not playing.";
            NParsingSentence(sentence, false);

            sentence = "Who is doing this.";
            NParsingSentence(sentence, false);

            sentence = "Who is not doing this.";
            NParsingSentence(sentence, false);

            sentence = "What am I doing?";
            NParsingSentence(sentence, false);

            //Passive: Present Continuous
            sentence = "Space is being explored.";
            NParsingSentence(sentence, false);

            sentence = "Space is not being explored.";
            NParsingSentence(sentence, false);

            sentence = "Is space being explored?";
            NParsingSentence(sentence, false);

            sentence = "What is being explored?";
            NParsingSentence(sentence, false);

            //Active: Past Continuous
            sentence = "I was playing.";
            NParsingSentence(sentence, false);

            sentence = "Was I playing?";
            NParsingSentence(sentence, false);

            sentence = "I was not playing.";
            NParsingSentence(sentence, false);

            //Passive: Past Continuous
            sentence = "Space was being explored.";
            NParsingSentence(sentence, false);

            sentence = "Space was not being explored.";
            NParsingSentence(sentence, false);

            sentence = "Was space being explored?";
            NParsingSentence(sentence, false);

            sentence = "What was being explored?";
            NParsingSentence(sentence, false);

            //Active: Future Continuous
            sentence = "I will be playing.";
            NParsingSentence(sentence, false);

            sentence = "Will I be playing?";
            NParsingSentence(sentence, false);

            sentence = "I will not be playing.";
            NParsingSentence(sentence, false);

            //Passive: Future Continuous -> forbidden.

            //Active: Present Perfect
            sentence = "I have played.";
            NParsingSentence(sentence, false);

            sentence = "Have I played?";
            NParsingSentence(sentence, false);

            sentence = "I have not played.";
            NParsingSentence(sentence, false);

            //Passive: Present Perfect
            sentence = "Space has been explored.";
            NParsingSentence(sentence, false);

            sentence = "What has been explored?";
            NParsingSentence(sentence, false);

            sentence = "Space has not been explored.";
            NParsingSentence(sentence, false);

            sentence = "Has space been explored?";
            NParsingSentence(sentence, false);

            //Active: Past Perfect
            sentence = "I had played.";
            NParsingSentence(sentence, false);

            sentence = "Had I played?";
            NParsingSentence(sentence, false);

            sentence = "I had not played.";
            NParsingSentence(sentence, false);

            //Passive: Past Perfect
            sentence = "Space had been explored.";
            NParsingSentence(sentence, false);

            sentence = "What had been explored?";
            NParsingSentence(sentence, false);

            sentence = "Space had not been explored.";
            NParsingSentence(sentence, false);

            sentence = "Had space been explored?";
            NParsingSentence(sentence, false);

            //Active: Future Perfect
            sentence = "I will have played.";
            NParsingSentence(sentence, false);

            sentence = "Will I have played?";
            NParsingSentence(sentence, false);

            sentence = "I will not have played.";
            NParsingSentence(sentence, false);

            //Passive: Future Perfect
            sentence = "Space will have been explored.";
            NParsingSentence(sentence, false);

            sentence = "Space will not have been explored.";
            NParsingSentence(sentence, false);

            sentence = "Will space have been explored?";
            NParsingSentence(sentence, false);

            sentence = "What will have been explored?";
            NParsingSentence(sentence, false);

            sentence = "In which time space will have been explored?";
            NParsingSentence(sentence, false);

            //Active: Present Perfect Continuous
            sentence = "I have been playing.";
            NParsingSentence(sentence, false);

            sentence = "Have I been playing?";
            NParsingSentence(sentence, false);

            sentence = "I have not been playing";
            NParsingSentence(sentence, false);

            //Passive: Present Perfect Continuous -> forbidden.

            //Active: Past Perfect Continuous
            sentence = "I had been playing.";
            NParsingSentence(sentence, false);

            sentence = "Had I been playing?";
            NParsingSentence(sentence, false);

            sentence = "I had not been playing.";
            NParsingSentence(sentence, false);

            //Passive: Past Perfect Continuous -> forbidden.

            //Active: Future Perfect Continuous
            sentence = "I will have been playing.";
            NParsingSentence(sentence, false);

            sentence = "Will I have been playing?";
            NParsingSentence(sentence, false);

            sentence = "I will not have been playing.";
            NParsingSentence(sentence, false);

            //Passive: Future Perfect Continuous -> forbidden.

            //Inversion.
            sentence = "There is some noise outside.";
            NParsingSentence(sentence, false);

            sentence = "Here is our new office.";
            NParsingSentence(sentence, false);

            sentence = "\"How are you?\" said Tom.";
            NParsingSentence(sentence, false);

            //Can: 
            sentence = "I can play.";
            NParsingSentence(sentence, false);

            sentence = "Can I play?";
            NParsingSentence(sentence, false);

            //Can:
            sentence = "I can’t play.";
            NParsingSentence(sentence, false);

            //Can:
            sentence = "I cannot play.";
            NParsingSentence(sentence, false);

            //Can: 
            sentence = "I could play.";
            NParsingSentence(sentence, false);

            sentence = "Could I play?";
            NParsingSentence(sentence, false);

            //Can:
            sentence = "I could not play.";
            NParsingSentence(sentence, false);

            //Can:
            sentence = "I couldn't play.";
            NParsingSentence(sentence, false);

            sentence = "Soon I will be able to read German books without a dictionary.";//be able to -> can
            NParsingSentence(sentence, false);

            sentence = "At the moment I cannot talk.";
            NParsingSentence(sentence, false);

            //May
            sentence = "I may play.";
            NParsingSentence(sentence, false);

            sentence = "May I play?";
            NParsingSentence(sentence, false);

            sentence = "I may not play.";
            NParsingSentence(sentence, false);

            sentence = "I mayn't play.";
            NParsingSentence(sentence, false);

            sentence = "I might play.";
            NParsingSentence(sentence, false);

            sentence = "I might not play.";
            NParsingSentence(sentence, false);

            sentence = "I mightn't play.";
            NParsingSentence(sentence, false);

            //Must
            sentence = "I must play.";
            NParsingSentence(sentence, false);

            sentence = "Must I play?";
            NParsingSentence(sentence, false);

            sentence = "I must not play.";
            NParsingSentence(sentence, false);

            sentence = "I mustn't play.";
            NParsingSentence(sentence, false);

            //Have to: Present
            sentence = "I have to play."; //have to -> must
            NParsingSentence(sentence, false);

            sentence = "I have to visit my dog every week.";
            NParsingSentence(sentence, false);

            sentence = "I don't have to play.";
            NParsingSentence(sentence, false);

            //Have to: Past
            sentence = "I had to play.";
            NParsingSentence(sentence, false);

            sentence = "I did not have to play.";
            NParsingSentence(sentence, false);

            //Have got to
            sentence = "Have you got to visit your dog tomorrow?";
            NParsingSentence(sentence, false);

            sentence = "You have got to visit your dog tomorrow?";
            NParsingSentence(sentence, false);

            //Be to
            sentence = "I am to play.";
            NParsingSentence(sentence, false);

            sentence = "I am not to play.";
            NParsingSentence(sentence, false);

            sentence = "I was to play.";
            NParsingSentence(sentence, false);

            sentence = "I was not to play.";
            NParsingSentence(sentence, false);

            //Ought to
            sentence = "I ought to play.";
            NParsingSentence(sentence, false);

            sentence = "I ought not to play.";
            NParsingSentence(sentence, false);

            sentence = "I oughtn't to play.";
            NParsingSentence(sentence, false);

            //Should
            sentence = "I should play."; //ought to -> should
            NParsingSentence(sentence, false);

            sentence = "Should I play?";
            NParsingSentence(sentence, false);

            sentence = "I should not play.";
            NParsingSentence(sentence, false);

            sentence = "I shouldn't play.";
            NParsingSentence(sentence, false);

            //Would
            sentence = "I would play.";
            NParsingSentence(sentence, false);

            sentence = "I would not play.";
            NParsingSentence(sentence, false);

            sentence = "I wouldn't play.";
            NParsingSentence(sentence, false);

            sentence = "Would I play?";
            NParsingSentence(sentence, false);

            //Vocative case
            sentence = "I know, Tom.";
            NParsingSentence(sentence, false);

            sentence = "Tom, do not forget your shower gel.";
            NParsingSentence(sentence, false);//true

            sentence = "And that, your Honor, concludes our case.";
            NParsingSentence(sentence, false);

            sentence = "Do me a favour, Tom, and ask Tim to stop speaking with the dog.";
            NParsingSentence(sentence, false);

            sentence = "Where have you been, you little adventurer?";
            NParsingSentence(sentence, false);

            sentence = "She says, \"What time will you be home?\"";
            NParsingSentence(sentence, false);

            sentence = "She said, \"What time will you be home?\" and I said, \"I don't know!\"";
            NParsingSentence(sentence, false);

            sentence = "\"There's a fly in my soup!\" screamed Tom.";
            NParsingSentence(sentence, false);

            sentence = "Is that Tom’s bag?";
            NParsingSentence(sentence, false);

            sentence = "Britain’s coastline is very beautiful.";
            NParsingSentence(sentence, false);

            sentence = "We went to Tom’s father’s funeral.";
            NParsingSentence(sentence, false);

            sentence = "Is that yesterday’s paper?";
            NParsingSentence(sentence, false);

            sentence = "I’ve only had one week’s holiday so far this year.";
            NParsingSentence(sentence, false);

            sentence = "My sister’s friend came with us.";
            NParsingSentence(sentence, false);

            sentence = "A friend of mine told me that all of the tickets have already sold out.";
            NParsingSentence(sentence, false);

            sentence = "He’s gone to pick up a cousin of his at the station.";
            NParsingSentence(sentence, false);

            sentence = "Go to green place";
            NParsingSentence(sentence, true);

            sentence = "Tom, Go to green place";
            NParsingSentence(sentence, false);

            sentence = "Tom";
            NParsingSentence(sentence, false);

            LogInstance.Log("End");
        }

        public bool ProcessAll { get; set; }
        private int mCount;
        private int mTotalCount;
        private EnglishMaximumEntropySentenceDetector mSentenceDetector;
        private WordsDict mWordsDict;
        private State mState = State.Init;
        private ITSTSentenceParserImpl mTargetImpl;
        public bool ConvertToConceptualGraph { get; set; }

        private void NParsingSentence(string text, bool isActual)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new NotImplementedException();
                //return;
            }

            if(!ProcessAll && !isActual)
            {
                return;
            }

            switch(mState)
            {
                case State.CalculateTotalCount:
                    mTotalCount++;
                    return;

                case State.Run:
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(mState), mState, null);
            }

            LogInstance.Log($"text = {text}");
            mCount++;
            LogInstance.Log($"mCount = {mCount}/{mTotalCount}");

            mTargetImpl.ConvertToConceptualGraph = ConvertToConceptualGraph;
            mTargetImpl.Parse(text);
        }
    }
}
