using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjConditionVerbTransOrFinNodeAction(ATNConditionSubjConditionVerbTransOrFinNode_v2 item);

    public class ATNConditionSubjConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjConditionVerbTransOrFinNodeFactory_v2(ATNConditionSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjConditionVerbTransOrFinNodeFactory_v2(ATNConditionSubjConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjConditionTransNode_v2 mParentNode;
        private ATNConditionSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Condition_Verb_Obj_TransOrFin
    Condition_Subj_Condition_Verb_No_Trans
    Condition_Subj_Condition_Verb_Condition_Fin
*/

    public class ATNConditionSubjConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjConditionVerbTransOrFinNode_v2 sameNode, InitATNConditionSubjConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Condition_Verb_TransOrFin;

        public ATNConditionSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjConditionVerbTransOrFinNodeAction mInitAction;

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

