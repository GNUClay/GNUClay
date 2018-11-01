using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillBeConditionVingNoTransNodeAction(ATNSubjWillBeConditionVingNoTransNode_v2 item);

    public class ATNSubjWillBeConditionVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillBeConditionVingNoTransNodeFactory_v2(ATNSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillBeConditionVingNoTransNodeFactory_v2(ATNSubjWillBeConditionVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillBeConditionVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNSubjWillBeConditionVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillBeConditionVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillBeConditionVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillBeConditionVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Be_Condition_Ving_No_Obj_TransOrFin
*/

    public class ATNSubjWillBeConditionVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillBeConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillBeConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeConditionVingNoTransNode_v2 sameNode, InitATNSubjWillBeConditionVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Be_Condition_Ving_No_Trans;

        public ATNSubjWillBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillBeConditionVingNoTransNode_v2 mSameNode;
        private InitATNSubjWillBeConditionVingNoTransNodeAction mInitAction;

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

