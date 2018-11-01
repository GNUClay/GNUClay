using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillBeConditionVingNoTransNodeAction(ATNQWSubjWillBeConditionVingNoTransNode_v2 item);

    public class ATNQWSubjWillBeConditionVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillBeConditionVingNoTransNodeFactory_v2(ATNQWSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillBeConditionVingNoTransNodeFactory_v2(ATNQWSubjWillBeConditionVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillBeConditionVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillBeConditionVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillBeConditionVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillBeConditionVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillBeConditionVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_Be_Condition_Ving_No_Obj_TransOrFin
*/

    public class ATNQWSubjWillBeConditionVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillBeConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillBeConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeConditionVingNoTransNode_v2 sameNode, InitATNQWSubjWillBeConditionVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Be_Condition_Ving_No_Trans;

        public ATNQWSubjWillBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillBeConditionVingNoTransNode_v2 mSameNode;
        private InitATNQWSubjWillBeConditionVingNoTransNodeAction mInitAction;

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

