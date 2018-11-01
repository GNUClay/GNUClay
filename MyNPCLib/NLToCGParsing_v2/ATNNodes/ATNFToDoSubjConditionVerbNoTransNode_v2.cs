using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoSubjConditionVerbNoTransNodeAction(ATNFToDoSubjConditionVerbNoTransNode_v2 item);

    public class ATNFToDoSubjConditionVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoSubjConditionVerbNoTransNodeFactory_v2(ATNFToDoSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoSubjConditionVerbNoTransNodeFactory_v2(ATNFToDoSubjConditionVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoSubjConditionVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNFToDoSubjConditionVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoSubjConditionVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoSubjConditionVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoSubjConditionVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToDo_Subj_Condition_Verb_No_Obj_TransOrFin
*/

    public class ATNFToDoSubjConditionVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNFToDoSubjConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoSubjConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjConditionVerbNoTransNode_v2 sameNode, InitATNFToDoSubjConditionVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Subj_Condition_Verb_No_Trans;

        public ATNFToDoSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToDoSubjConditionVerbNoTransNode_v2 mSameNode;
        private InitATNFToDoSubjConditionVerbNoTransNodeAction mInitAction;

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

