using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeConditionVingTransOrFinNodeAction(ATNConditionSubjWillBeConditionVingTransOrFinNode_v2 item);

    public class ATNConditionSubjWillBeConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeConditionVingTransOrFinNodeFactory_v2(ATNConditionSubjWillBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeConditionVingTransOrFinNodeFactory_v2(ATNConditionSubjWillBeConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeConditionTransNode_v2 mParentNode;
        private ATNConditionSubjWillBeConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Be_Condition_Ving_Obj_TransOrFin
    Condition_Subj_Will_Be_Condition_Ving_No_Trans
    Condition_Subj_Will_Be_Condition_Ving_Condition_Fin
*/

    public class ATNConditionSubjWillBeConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeConditionVingTransOrFinNode_v2 sameNode, InitATNConditionSubjWillBeConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_Condition_Ving_TransOrFin;

        public ATNConditionSubjWillBeConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillBeConditionVingTransOrFinNodeAction mInitAction;

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

