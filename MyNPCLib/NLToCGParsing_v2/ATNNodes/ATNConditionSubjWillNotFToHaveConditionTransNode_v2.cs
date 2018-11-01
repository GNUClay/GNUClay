using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotFToHaveConditionTransNodeAction(ATNConditionSubjWillNotFToHaveConditionTransNode_v2 item);

    public class ATNConditionSubjWillNotFToHaveConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotFToHaveConditionTransNodeFactory_v2(ATNConditionSubjWillNotFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotFToHaveConditionTransNodeFactory_v2(ATNConditionSubjWillNotFToHaveConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotFToHaveConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotFToHaveTransNode_v2 mParentNode;
        private ATNConditionSubjWillNotFToHaveConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotFToHaveConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotFToHaveConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotFToHaveConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Not_FToHave_Condition_V3_TransOrFin
*/

    public class ATNConditionSubjWillNotFToHaveConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveConditionTransNode_v2 sameNode, InitATNConditionSubjWillNotFToHaveConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_FToHave_Condition_Trans;

        public ATNConditionSubjWillNotFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotFToHaveConditionTransNode_v2 mSameNode;
        private InitATNConditionSubjWillNotFToHaveConditionTransNodeAction mInitAction;

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

