using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToBeSubjTransNodeAction(ATNConditionQWObjFToBeSubjTransNode_v2 item);

    public class ATNConditionQWObjFToBeSubjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToBeSubjTransNodeFactory_v2(ATNConditionQWObjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToBeSubjTransNodeFactory_v2(ATNConditionQWObjFToBeSubjTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToBeSubjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToBeTransNode_v2 mParentNode;
        private ATNConditionQWObjFToBeSubjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToBeSubjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToBeSubjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToBeSubjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_FToBe_Subj_Ving_TransOrFin
    Condition_QWObj_FToBe_Subj_V3_TransOrFin
    Condition_QWObj_FToBe_Subj_Being_Trans
    Condition_QWObj_FToBe_Subj_Condition_Trans
*/

    public class ATNConditionQWObjFToBeSubjTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToBeSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToBeSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjTransNode_v2 sameNode, InitATNConditionQWObjFToBeSubjTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToBe_Subj_Trans;

        public ATNConditionQWObjFToBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToBeSubjTransNode_v2 mSameNode;
        private InitATNConditionQWObjFToBeSubjTransNodeAction mInitAction;

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

