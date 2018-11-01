using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToBeSubjBeingConditionTransNodeAction(ATNConditionQWObjFToBeSubjBeingConditionTransNode_v2 item);

    public class ATNConditionQWObjFToBeSubjBeingConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToBeSubjBeingConditionTransNodeFactory_v2(ATNConditionQWObjFToBeSubjBeingTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToBeSubjBeingConditionTransNodeFactory_v2(ATNConditionQWObjFToBeSubjBeingConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToBeSubjBeingConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToBeSubjBeingTransNode_v2 mParentNode;
        private ATNConditionQWObjFToBeSubjBeingConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToBeSubjBeingConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToBeSubjBeingConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToBeSubjBeingConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_FToBe_Subj_Being_Condition_V3_TransOrFin
*/

    public class ATNConditionQWObjFToBeSubjBeingConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToBeSubjBeingConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjBeingTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToBeSubjBeingConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjBeingConditionTransNode_v2 sameNode, InitATNConditionQWObjFToBeSubjBeingConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToBe_Subj_Being_Condition_Trans;

        public ATNConditionQWObjFToBeSubjBeingTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToBeSubjBeingConditionTransNode_v2 mSameNode;
        private InitATNConditionQWObjFToBeSubjBeingConditionTransNodeAction mInitAction;

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

