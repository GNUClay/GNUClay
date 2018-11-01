using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeConditionVingNoTransNodeAction(ATNConditionQWSubjFToBeConditionVingNoTransNode_v2 item);

    public class ATNConditionQWSubjFToBeConditionVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeConditionVingNoTransNodeFactory_v2(ATNConditionQWSubjFToBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeConditionVingNoTransNodeFactory_v2(ATNConditionQWSubjFToBeConditionVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeConditionVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeConditionVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeConditionVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeConditionVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeConditionVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToBe_Condition_Ving_No_Obj_TransOrFin
*/

    public class ATNConditionQWSubjFToBeConditionVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionVingNoTransNode_v2 sameNode, InitATNConditionQWSubjFToBeConditionVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Condition_Ving_No_Trans;

        public ATNConditionQWSubjFToBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeConditionVingNoTransNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeConditionVingNoTransNodeAction mInitAction;

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

