using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillVerbTransOrFinNodeAction(ATNConditionSubjWillVerbTransOrFinNode_v2 item);

    public class ATNConditionSubjWillVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillVerbTransOrFinNodeFactory_v2(ATNConditionSubjWillTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillVerbTransOrFinNodeFactory_v2(ATNConditionSubjWillVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillTransNode_v2 mParentNode;
        private ATNConditionSubjWillVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Verb_Obj_TransOrFin
    Condition_Subj_Will_Verb_No_Trans
    Condition_Subj_Will_Verb_Condition_Fin
*/

    public class ATNConditionSubjWillVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillVerbTransOrFinNode_v2 sameNode, InitATNConditionSubjWillVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Verb_TransOrFin;

        public ATNConditionSubjWillTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillVerbTransOrFinNodeAction mInitAction;

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

