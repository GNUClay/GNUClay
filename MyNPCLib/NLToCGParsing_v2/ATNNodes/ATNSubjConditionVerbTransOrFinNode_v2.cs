using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjConditionVerbTransOrFinNodeAction(ATNSubjConditionVerbTransOrFinNode_v2 item);

    public class ATNSubjConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjConditionVerbTransOrFinNodeFactory_v2(ATNSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjConditionVerbTransOrFinNodeFactory_v2(ATNSubjConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjConditionTransNode_v2 mParentNode;
        private ATNSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Condition_Verb_Obj_TransOrFin
    Subj_Condition_Verb_No_Trans
    Subj_Condition_Verb_Condition_Fin
*/

    public class ATNSubjConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjConditionVerbTransOrFinNode_v2 sameNode, InitATNSubjConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Condition_Verb_TransOrFin;

        public ATNSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNSubjConditionVerbTransOrFinNodeAction mInitAction;

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

