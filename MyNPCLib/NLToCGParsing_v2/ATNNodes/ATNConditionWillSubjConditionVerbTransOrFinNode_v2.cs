using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjConditionVerbTransOrFinNodeAction(ATNConditionWillSubjConditionVerbTransOrFinNode_v2 item);

    public class ATNConditionWillSubjConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjConditionVerbTransOrFinNodeFactory_v2(ATNConditionWillSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjConditionVerbTransOrFinNodeFactory_v2(ATNConditionWillSubjConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjConditionTransNode_v2 mParentNode;
        private ATNConditionWillSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_Condition_Verb_Obj_TransOrFin
    Condition_Will_Subj_Condition_Verb_No_Trans
    Condition_Will_Subj_Condition_Verb_Condition_Fin
*/

    public class ATNConditionWillSubjConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjConditionVerbTransOrFinNode_v2 sameNode, InitATNConditionWillSubjConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Condition_Verb_TransOrFin;

        public ATNConditionWillSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionWillSubjConditionVerbTransOrFinNodeAction mInitAction;

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

