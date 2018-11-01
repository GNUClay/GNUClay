using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillBeVingNoTransNodeAction(ATNConditionQWSubjWillBeVingNoTransNode_v2 item);

    public class ATNConditionQWSubjWillBeVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillBeVingNoTransNodeFactory_v2(ATNConditionQWSubjWillBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillBeVingNoTransNodeFactory_v2(ATNConditionQWSubjWillBeVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillBeVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillBeVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillBeVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillBeVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillBeVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillBeVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_Be_Ving_No_Obj_TransOrFin
*/

    public class ATNConditionQWSubjWillBeVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillBeVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillBeVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeVingNoTransNode_v2 sameNode, InitATNConditionQWSubjWillBeVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Be_Ving_No_Trans;

        public ATNConditionQWSubjWillBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillBeVingNoTransNode_v2 mSameNode;
        private InitATNConditionQWSubjWillBeVingNoTransNodeAction mInitAction;

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

