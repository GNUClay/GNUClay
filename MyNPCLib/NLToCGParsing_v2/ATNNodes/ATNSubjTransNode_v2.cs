using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjTransNodeAction(ATNSubjTransNode_v2 item);

    public class ATNSubjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjTransNodeFactory_v2(ATNInitNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjTransNodeFactory_v2(ATNSubjTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNInitNode_v2 mParentNode;
        private ATNSubjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Verb_TransOrFin
    Subj_FToDo_Trans
    Subj_Will_Trans
    Subj_FToBe_Trans
    Subj_FToHave_Trans
    Subj_ModalVerb_Trans
    Subj_Condition_Trans
*/

    public class ATNSubjTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNInitNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
            SlaveNAPNode = new ATNSlaveNAPNode(context, new SubjectTargetOfATNSlaveNAPNode());
            RegATNSlaveNAPNode(SlaveNAPNode);
        }

        public ATNSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjTransNode_v2 sameNode, InitATNSubjTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            SlaveNAPNode = mSameNode.SlaveNAPNode.Fork(context);
            RegATNSlaveNAPNode(SlaveNAPNode);
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Trans;

        public ATNInitNode_v2 ParentNode { get; private set; }
        private ATNSubjTransNode_v2 mSameNode;
        private InitATNSubjTransNodeAction mInitAction;

        public ATNSlaveNAPNode SlaveNAPNode { get; set; }

        protected override void ImplementGoalToken()
        {
#if DEBUG
            LogInstance.Log($"Token = {Token}");
            LogInstance.Log($"Context = {Context}");
#endif

            SetAsSuccess(SlaveNAPNode.Run(Token));
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
                    case KindOfItemOfSentence.Verb:
                        AddTask(new ATNSubjVerbTransOrFinNodeFactory_v2(this, item));
                        break;

                    case KindOfItemOfSentence.FToDo:
                        AddTask(new ATNSubjFToDoTransNodeFactory_v2(this, item));
                        break;

                    case KindOfItemOfSentence.Subj:
                        if(hasObjOrSubj)
                        {
                            break;
                        }
                        hasObjOrSubj = true;
                        AddTask(new ATNSubjTransNodeFactory_v2(this, item, null));
                        break;

                    case KindOfItemOfSentence.Obj:
                        if (hasObjOrSubj)
                        {
                            break;
                        }
                        hasObjOrSubj = true;
                        AddTask(new ATNSubjTransNodeFactory_v2(this, item, null));
                        break;

                    case KindOfItemOfSentence.FToBe:
                        AddTask(new ATNSubjFToBeTransNodeFactory_v2(this, item));
                        break;

                    case KindOfItemOfSentence.V3:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfItem), kindOfItem, null);
                }
            }
        }
    }
}

