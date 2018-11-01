using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillBeConditionVingNoTransNodeAction(ATNConditionQWSubjWillBeConditionVingNoTransNode_v2 item);

    public class ATNConditionQWSubjWillBeConditionVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillBeConditionVingNoTransNodeFactory_v2(ATNConditionQWSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillBeConditionVingNoTransNodeFactory_v2(ATNConditionQWSubjWillBeConditionVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillBeConditionVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillBeConditionVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillBeConditionVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillBeConditionVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillBeConditionVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_Be_Condition_Ving_No_Obj_TransOrFin
*/

    public class ATNConditionQWSubjWillBeConditionVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillBeConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillBeConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeConditionVingNoTransNode_v2 sameNode, InitATNConditionQWSubjWillBeConditionVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Be_Condition_Ving_No_Trans;

        public ATNConditionQWSubjWillBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillBeConditionVingNoTransNode_v2 mSameNode;
        private InitATNConditionQWSubjWillBeConditionVingNoTransNodeAction mInitAction;

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

