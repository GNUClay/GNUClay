using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotBeConditionVingTransOrFinNodeAction(ATNConditionSubjWillNotBeConditionVingTransOrFinNode_v2 item);

    public class ATNConditionSubjWillNotBeConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotBeConditionVingTransOrFinNodeFactory_v2(ATNConditionSubjWillNotBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotBeConditionVingTransOrFinNodeFactory_v2(ATNConditionSubjWillNotBeConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotBeConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotBeConditionTransNode_v2 mParentNode;
        private ATNConditionSubjWillNotBeConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotBeConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotBeConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotBeConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Not_Be_Condition_Ving_Obj_TransOrFin
    Condition_Subj_Will_Not_Be_Condition_Ving_Condition_Fin
*/

    public class ATNConditionSubjWillNotBeConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotBeConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotBeConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeConditionVingTransOrFinNode_v2 sameNode, InitATNConditionSubjWillNotBeConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_Be_Condition_Ving_TransOrFin;

        public ATNConditionSubjWillNotBeConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotBeConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotBeConditionVingTransOrFinNodeAction mInitAction;

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

