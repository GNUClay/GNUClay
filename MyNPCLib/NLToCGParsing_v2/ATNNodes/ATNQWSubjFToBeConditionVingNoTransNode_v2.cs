using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeConditionVingNoTransNodeAction(ATNQWSubjFToBeConditionVingNoTransNode_v2 item);

    public class ATNQWSubjFToBeConditionVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeConditionVingNoTransNodeFactory_v2(ATNQWSubjFToBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeConditionVingNoTransNodeFactory_v2(ATNQWSubjFToBeConditionVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeConditionVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToBeConditionVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeConditionVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeConditionVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeConditionVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToBe_Condition_Ving_No_Obj_TransOrFin
*/

    public class ATNQWSubjFToBeConditionVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeConditionVingNoTransNode_v2 sameNode, InitATNQWSubjFToBeConditionVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Condition_Ving_No_Trans;

        public ATNQWSubjFToBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeConditionVingNoTransNode_v2 mSameNode;
        private InitATNQWSubjFToBeConditionVingNoTransNodeAction mInitAction;

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

