using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjTransNodeAction(ATNConditionWillSubjTransNode_v2 item);

    public class ATNConditionWillSubjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjTransNodeFactory_v2(ATNConditionWillTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjTransNodeFactory_v2(ATNConditionWillSubjTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillTransNode_v2 mParentNode;
        private ATNConditionWillSubjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_Verb_TransOrFin
    Condition_Will_Subj_Be_Trans
    Condition_Will_Subj_FToHave_Trans
    Condition_Will_Subj_Condition_Trans
*/

    public class ATNConditionWillSubjTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjTransNode_v2 sameNode, InitATNConditionWillSubjTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Trans;

        public ATNConditionWillTransNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjTransNode_v2 mSameNode;
        private InitATNConditionWillSubjTransNodeAction mInitAction;

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

