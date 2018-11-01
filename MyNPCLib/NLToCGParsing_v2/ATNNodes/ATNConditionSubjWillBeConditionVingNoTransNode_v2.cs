using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeConditionVingNoTransNodeAction(ATNConditionSubjWillBeConditionVingNoTransNode_v2 item);

    public class ATNConditionSubjWillBeConditionVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeConditionVingNoTransNodeFactory_v2(ATNConditionSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeConditionVingNoTransNodeFactory_v2(ATNConditionSubjWillBeConditionVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeConditionVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillBeConditionVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeConditionVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeConditionVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeConditionVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Be_Condition_Ving_No_Obj_TransOrFin
*/

    public class ATNConditionSubjWillBeConditionVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeConditionVingNoTransNode_v2 sameNode, InitATNConditionSubjWillBeConditionVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_Condition_Ving_No_Trans;

        public ATNConditionSubjWillBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeConditionVingNoTransNode_v2 mSameNode;
        private InitATNConditionSubjWillBeConditionVingNoTransNodeAction mInitAction;

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

