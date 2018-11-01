using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillBeConditionTransNodeAction(ATNConditionQWSubjWillBeConditionTransNode_v2 item);

    public class ATNConditionQWSubjWillBeConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillBeConditionTransNodeFactory_v2(ATNConditionQWSubjWillBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillBeConditionTransNodeFactory_v2(ATNConditionQWSubjWillBeConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillBeConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillBeTransNode_v2 mParentNode;
        private ATNConditionQWSubjWillBeConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillBeConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillBeConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillBeConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_Be_Condition_Ving_TransOrFin
    Condition_QWSubj_Will_Be_Condition_V3_TransOrFin
*/

    public class ATNConditionQWSubjWillBeConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillBeConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillBeConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeConditionTransNode_v2 sameNode, InitATNConditionQWSubjWillBeConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Be_Condition_Trans;

        public ATNConditionQWSubjWillBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillBeConditionTransNode_v2 mSameNode;
        private InitATNConditionQWSubjWillBeConditionTransNodeAction mInitAction;

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

