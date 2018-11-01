using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillConditionVerbTransOrFinNodeAction(ATNSubjWillConditionVerbTransOrFinNode_v2 item);

    public class ATNSubjWillConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillConditionVerbTransOrFinNodeFactory_v2(ATNSubjWillConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillConditionVerbTransOrFinNodeFactory_v2(ATNSubjWillConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillConditionTransNode_v2 mParentNode;
        private ATNSubjWillConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Condition_Verb_Obj_TransOrFin
    Subj_Will_Condition_Verb_No_Trans
    Subj_Will_Condition_Verb_Condition_Fin
*/

    public class ATNSubjWillConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillConditionVerbTransOrFinNode_v2 sameNode, InitATNSubjWillConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Condition_Verb_TransOrFin;

        public ATNSubjWillConditionTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillConditionVerbTransOrFinNodeAction mInitAction;

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

