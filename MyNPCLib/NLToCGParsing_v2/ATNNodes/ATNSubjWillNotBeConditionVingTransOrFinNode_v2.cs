using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotBeConditionVingTransOrFinNodeAction(ATNSubjWillNotBeConditionVingTransOrFinNode_v2 item);

    public class ATNSubjWillNotBeConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotBeConditionVingTransOrFinNodeFactory_v2(ATNSubjWillNotBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotBeConditionVingTransOrFinNodeFactory_v2(ATNSubjWillNotBeConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotBeConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotBeConditionTransNode_v2 mParentNode;
        private ATNSubjWillNotBeConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotBeConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotBeConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotBeConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Not_Be_Condition_Ving_Obj_TransOrFin
    Subj_Will_Not_Be_Condition_Ving_Condition_Fin
*/

    public class ATNSubjWillNotBeConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotBeConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotBeConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotBeConditionVingTransOrFinNode_v2 sameNode, InitATNSubjWillNotBeConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_Be_Condition_Ving_TransOrFin;

        public ATNSubjWillNotBeConditionTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotBeConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillNotBeConditionVingTransOrFinNodeAction mInitAction;

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

