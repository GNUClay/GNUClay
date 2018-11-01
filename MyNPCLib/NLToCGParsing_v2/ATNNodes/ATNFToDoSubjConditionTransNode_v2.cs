using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoSubjConditionTransNodeAction(ATNFToDoSubjConditionTransNode_v2 item);

    public class ATNFToDoSubjConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoSubjConditionTransNodeFactory_v2(ATNFToDoSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoSubjConditionTransNodeFactory_v2(ATNFToDoSubjConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoSubjConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoSubjTransNode_v2 mParentNode;
        private ATNFToDoSubjConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoSubjConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoSubjConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoSubjConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToDo_Subj_Condition_Verb_TransOrFin
*/

    public class ATNFToDoSubjConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNFToDoSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjConditionTransNode_v2 sameNode, InitATNFToDoSubjConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Subj_Condition_Trans;

        public ATNFToDoSubjTransNode_v2 ParentNode { get; private set; }
        private ATNFToDoSubjConditionTransNode_v2 mSameNode;
        private InitATNFToDoSubjConditionTransNodeAction mInitAction;

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

