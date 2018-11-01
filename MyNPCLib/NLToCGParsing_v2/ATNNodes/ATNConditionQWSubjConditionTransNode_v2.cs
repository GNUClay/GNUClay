using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjConditionTransNodeAction(ATNConditionQWSubjConditionTransNode_v2 item);

    public class ATNConditionQWSubjConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjConditionTransNodeFactory_v2(ATNConditionQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjConditionTransNodeFactory_v2(ATNConditionQWSubjConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjTransNode_v2 mParentNode;
        private ATNConditionQWSubjConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Condition_Verb_TransOrFin
*/

    public class ATNConditionQWSubjConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjConditionTransNode_v2 sameNode, InitATNConditionQWSubjConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Condition_Trans;

        public ATNConditionQWSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjConditionTransNode_v2 mSameNode;
        private InitATNConditionQWSubjConditionTransNodeAction mInitAction;

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

