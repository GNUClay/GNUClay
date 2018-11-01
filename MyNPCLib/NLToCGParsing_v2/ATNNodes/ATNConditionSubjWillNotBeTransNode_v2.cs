using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotBeTransNodeAction(ATNConditionSubjWillNotBeTransNode_v2 item);

    public class ATNConditionSubjWillNotBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotBeTransNodeFactory_v2(ATNConditionSubjWillNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotBeTransNodeFactory_v2(ATNConditionSubjWillNotBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotTransNode_v2 mParentNode;
        private ATNConditionSubjWillNotBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Not_Be_Ving_TransOrFin
    Condition_Subj_Will_Not_Be_V3_TransOrFin
    Condition_Subj_Will_Not_Be_Condition_Trans
*/

    public class ATNConditionSubjWillNotBeTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeTransNode_v2 sameNode, InitATNConditionSubjWillNotBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_Be_Trans;

        public ATNConditionSubjWillNotTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotBeTransNode_v2 mSameNode;
        private InitATNConditionSubjWillNotBeTransNodeAction mInitAction;

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

