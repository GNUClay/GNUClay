using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillBeConditionVingTransOrFinNodeAction(ATNSubjWillBeConditionVingTransOrFinNode_v2 item);

    public class ATNSubjWillBeConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillBeConditionVingTransOrFinNodeFactory_v2(ATNSubjWillBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillBeConditionVingTransOrFinNodeFactory_v2(ATNSubjWillBeConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillBeConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillBeConditionTransNode_v2 mParentNode;
        private ATNSubjWillBeConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillBeConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillBeConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillBeConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Be_Condition_Ving_Obj_TransOrFin
    Subj_Will_Be_Condition_Ving_No_Trans
    Subj_Will_Be_Condition_Ving_Condition_Fin
*/

    public class ATNSubjWillBeConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillBeConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillBeConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeConditionVingTransOrFinNode_v2 sameNode, InitATNSubjWillBeConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Be_Condition_Ving_TransOrFin;

        public ATNSubjWillBeConditionTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillBeConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillBeConditionVingTransOrFinNodeAction mInitAction;

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

