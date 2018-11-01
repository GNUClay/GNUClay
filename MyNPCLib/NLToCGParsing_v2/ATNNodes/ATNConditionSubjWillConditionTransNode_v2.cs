using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillConditionTransNodeAction(ATNConditionSubjWillConditionTransNode_v2 item);

    public class ATNConditionSubjWillConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillConditionTransNodeFactory_v2(ATNConditionSubjWillTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillConditionTransNodeFactory_v2(ATNConditionSubjWillConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillTransNode_v2 mParentNode;
        private ATNConditionSubjWillConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Condition_Verb_TransOrFin
*/

    public class ATNConditionSubjWillConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillConditionTransNode_v2 sameNode, InitATNConditionSubjWillConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Condition_Trans;

        public ATNConditionSubjWillTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillConditionTransNode_v2 mSameNode;
        private InitATNConditionSubjWillConditionTransNodeAction mInitAction;

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

