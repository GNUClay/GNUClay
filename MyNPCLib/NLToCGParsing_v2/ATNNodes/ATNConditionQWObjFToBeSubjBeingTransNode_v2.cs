using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToBeSubjBeingTransNodeAction(ATNConditionQWObjFToBeSubjBeingTransNode_v2 item);

    public class ATNConditionQWObjFToBeSubjBeingTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToBeSubjBeingTransNodeFactory_v2(ATNConditionQWObjFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToBeSubjBeingTransNodeFactory_v2(ATNConditionQWObjFToBeSubjBeingTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToBeSubjBeingTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToBeSubjTransNode_v2 mParentNode;
        private ATNConditionQWObjFToBeSubjBeingTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToBeSubjBeingTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToBeSubjBeingTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToBeSubjBeingTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_FToBe_Subj_Being_V3_TransOrFin
    Condition_QWObj_FToBe_Subj_Being_Condition_Trans
*/

    public class ATNConditionQWObjFToBeSubjBeingTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToBeSubjBeingTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToBeSubjBeingTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjBeingTransNode_v2 sameNode, InitATNConditionQWObjFToBeSubjBeingTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToBe_Subj_Being_Trans;

        public ATNConditionQWObjFToBeSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToBeSubjBeingTransNode_v2 mSameNode;
        private InitATNConditionQWObjFToBeSubjBeingTransNodeAction mInitAction;

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

