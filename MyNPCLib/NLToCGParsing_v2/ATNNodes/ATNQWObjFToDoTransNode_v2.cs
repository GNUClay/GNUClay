using MyNPCLib.NLToCGParsing;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToDoTransNodeAction(ATNQWObjFToDoTransNode_v2 item);

    public class ATNQWObjFToDoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToDoTransNodeFactory_v2(ATNQWObjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToDoTransNodeFactory_v2(ATNQWObjFToDoTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToDoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjTransNode_v2 mParentNode;
        private ATNQWObjFToDoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToDoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToDoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToDoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_FToDo_Subj_Trans
*/

    public class ATNQWObjFToDoTransNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToDoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToDoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToDoTransNode_v2 sameNode, InitATNQWObjFToDoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToDo_Trans;

        public ATNQWObjTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToDoTransNode_v2 mSameNode;
        private InitATNQWObjFToDoTransNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
#if DEBUG
            LogInstance.Log($"Token = {Token}");
            LogInstance.Log($"Context = {Context}");
#endif

            Sentence.Aspect = GrammaticalAspect.Simple;
            Sentence.Tense = Token.Tense;
            Sentence.Voice = GrammaticalVoice.Active;
            Sentence.Modal = KindOfModal.None;
            Sentence.Mood = GrammaticalMood.Undefined;
        }

        protected override void ProcessNextToken()
        {
            var extendedTokensList = Get—lusterOfExtendedTokens();

#if DEBUG
            LogInstance.Log($"extendedTokensList.Count = {extendedTokensList.Count}");
#endif

            if (extendedTokensList.Count == 0)
            {
                throw new NotImplementedException();
            }

            var hasObjOrSubj = false;

            foreach (var item in extendedTokensList)
            {
#if DEBUG
                LogInstance.Log($"item = {item}");
#endif

                var kindOfItem = item.KindOfItem;

                switch (kindOfItem)
                {
                    case KindOfItemOfSentence.Subj:
                        if (hasObjOrSubj)
                        {
                            break;
                        }
                        hasObjOrSubj = true;
                        AddTask(new ATNQWObjFToDoSubjTransNodeFactory_v2(this, item));
                        break;

                    case KindOfItemOfSentence.Obj:
                        if (hasObjOrSubj)
                        {
                            break;
                        }
                        hasObjOrSubj = true;
                        AddTask(new ATNQWObjFToDoSubjTransNodeFactory_v2(this, item));
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfItem), kindOfItem, null);
                }
            }
        }
    }
}

