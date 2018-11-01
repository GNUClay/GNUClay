using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToBeSubjBeingConditionTransNodeAction(ATNQWObjFToBeSubjBeingConditionTransNode_v2 item);

    public class ATNQWObjFToBeSubjBeingConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToBeSubjBeingConditionTransNodeFactory_v2(ATNQWObjFToBeSubjBeingTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToBeSubjBeingConditionTransNodeFactory_v2(ATNQWObjFToBeSubjBeingConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToBeSubjBeingConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToBeSubjBeingTransNode_v2 mParentNode;
        private ATNQWObjFToBeSubjBeingConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToBeSubjBeingConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToBeSubjBeingConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToBeSubjBeingConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_FToBe_Subj_Being_Condition_V3_TransOrFin
*/

    public class ATNQWObjFToBeSubjBeingConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToBeSubjBeingConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjBeingTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToBeSubjBeingConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjBeingConditionTransNode_v2 sameNode, InitATNQWObjFToBeSubjBeingConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToBe_Subj_Being_Condition_Trans;

        public ATNQWObjFToBeSubjBeingTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToBeSubjBeingConditionTransNode_v2 mSameNode;
        private InitATNQWObjFToBeSubjBeingConditionTransNodeAction mInitAction;

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

