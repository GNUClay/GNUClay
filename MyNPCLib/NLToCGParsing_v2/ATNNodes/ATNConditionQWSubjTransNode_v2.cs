using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjTransNodeAction(ATNConditionQWSubjTransNode_v2 item);

    public class ATNConditionQWSubjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjTransNodeFactory_v2(ATNConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjTransNodeFactory_v2(ATNConditionQWSubjTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionTransNode_v2 mParentNode;
        private ATNConditionQWSubjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Verb_TransOrFin
    Condition_QWSubj_FToDo_Trans
    Condition_QWSubj_Will_Trans
    Condition_QWSubj_FToBe_Trans
    Condition_QWSubj_FToHave_Trans
    Condition_QWSubj_ModalVerb_Trans
    Condition_QWSubj_Condition_Trans
*/

    public class ATNConditionQWSubjTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjTransNode_v2 sameNode, InitATNConditionQWSubjTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Trans;

        public ATNConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjTransNode_v2 mSameNode;
        private InitATNConditionQWSubjTransNodeAction mInitAction;

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

