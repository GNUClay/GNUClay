using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjConditionVerbTransOrFinNodeAction(ATNWillSubjConditionVerbTransOrFinNode_v2 item);

    public class ATNWillSubjConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjConditionVerbTransOrFinNodeFactory_v2(ATNWillSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjConditionVerbTransOrFinNodeFactory_v2(ATNWillSubjConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjConditionTransNode_v2 mParentNode;
        private ATNWillSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_Condition_Verb_Obj_TransOrFin
    Will_Subj_Condition_Verb_No_Trans
    Will_Subj_Condition_Verb_Condition_Fin
*/

    public class ATNWillSubjConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjConditionVerbTransOrFinNode_v2 sameNode, InitATNWillSubjConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Condition_Verb_TransOrFin;

        public ATNWillSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNWillSubjConditionVerbTransOrFinNodeAction mInitAction;

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

