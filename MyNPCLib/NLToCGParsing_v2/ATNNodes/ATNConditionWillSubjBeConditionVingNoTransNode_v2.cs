using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjBeConditionVingNoTransNodeAction(ATNConditionWillSubjBeConditionVingNoTransNode_v2 item);

    public class ATNConditionWillSubjBeConditionVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjBeConditionVingNoTransNodeFactory_v2(ATNConditionWillSubjBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjBeConditionVingNoTransNodeFactory_v2(ATNConditionWillSubjBeConditionVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjBeConditionVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjBeConditionVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjBeConditionVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjBeConditionVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjBeConditionVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_Be_Condition_Ving_No_Obj_TransOrFin
*/

    public class ATNConditionWillSubjBeConditionVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjBeConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjBeConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeConditionVingNoTransNode_v2 sameNode, InitATNConditionWillSubjBeConditionVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Be_Condition_Ving_No_Trans;

        public ATNConditionWillSubjBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjBeConditionVingNoTransNode_v2 mSameNode;
        private InitATNConditionWillSubjBeConditionVingNoTransNodeAction mInitAction;

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

