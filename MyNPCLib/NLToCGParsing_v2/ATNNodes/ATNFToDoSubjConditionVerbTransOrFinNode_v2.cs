using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoSubjConditionVerbTransOrFinNodeAction(ATNFToDoSubjConditionVerbTransOrFinNode_v2 item);

    public class ATNFToDoSubjConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoSubjConditionVerbTransOrFinNodeFactory_v2(ATNFToDoSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoSubjConditionVerbTransOrFinNodeFactory_v2(ATNFToDoSubjConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoSubjConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoSubjConditionTransNode_v2 mParentNode;
        private ATNFToDoSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoSubjConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoSubjConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoSubjConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToDo_Subj_Condition_Verb_Obj_TransOrFin
    FToDo_Subj_Condition_Verb_No_Trans
    FToDo_Subj_Condition_Verb_Condition_Fin
*/

    public class ATNFToDoSubjConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToDoSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjConditionVerbTransOrFinNode_v2 sameNode, InitATNFToDoSubjConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Subj_Condition_Verb_TransOrFin;

        public ATNFToDoSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNFToDoSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNFToDoSubjConditionVerbTransOrFinNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
            throw new NotImplementedException();
        }

        protected override void ProcessNextToken()
        {
            throw new NotImplementedException();
        }
    }
}

