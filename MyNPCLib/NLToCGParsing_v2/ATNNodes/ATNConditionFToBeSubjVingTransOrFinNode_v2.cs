using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjVingTransOrFinNodeAction(ATNConditionFToBeSubjVingTransOrFinNode_v2 item);

    public class ATNConditionFToBeSubjVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjVingTransOrFinNodeFactory_v2(ATNConditionFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjVingTransOrFinNodeFactory_v2(ATNConditionFToBeSubjVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjTransNode_v2 mParentNode;
        private ATNConditionFToBeSubjVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToBe_Subj_Ving_Obj_TransOrFin
    Condition_FToBe_Subj_Ving_No_Trans
    Condition_FToBe_Subj_Ving_Condition_Fin
*/

    public class ATNConditionFToBeSubjVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjVingTransOrFinNode_v2 sameNode, InitATNConditionFToBeSubjVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Ving_TransOrFin;

        public ATNConditionFToBeSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjVingTransOrFinNodeAction mInitAction;

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

