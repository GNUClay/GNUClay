using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeVingTransOrFinNodeAction(ATNConditionQWSubjFToBeVingTransOrFinNode_v2 item);

    public class ATNConditionQWSubjFToBeVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeVingTransOrFinNodeFactory_v2(ATNConditionQWSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeVingTransOrFinNodeFactory_v2(ATNConditionQWSubjFToBeVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToBe_Ving_Obj_TransOrFin
    Condition_QWSubj_FToBe_Ving_No_Trans
    Condition_QWSubj_FToBe_Ving_Condition_Fin
*/

    public class ATNConditionQWSubjFToBeVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeVingTransOrFinNode_v2 sameNode, InitATNConditionQWSubjFToBeVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Ving_TransOrFin;

        public ATNConditionQWSubjFToBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeVingTransOrFinNodeAction mInitAction;

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

