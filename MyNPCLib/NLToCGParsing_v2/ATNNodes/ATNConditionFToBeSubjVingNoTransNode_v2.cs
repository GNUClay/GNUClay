using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjVingNoTransNodeAction(ATNConditionFToBeSubjVingNoTransNode_v2 item);

    public class ATNConditionFToBeSubjVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjVingNoTransNodeFactory_v2(ATNConditionFToBeSubjVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjVingNoTransNodeFactory_v2(ATNConditionFToBeSubjVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjVingTransOrFinNode_v2 mParentNode;
        private ATNConditionFToBeSubjVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToBe_Subj_Ving_No_Obj_TransOrFin
*/

    public class ATNConditionFToBeSubjVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjVingNoTransNode_v2 sameNode, InitATNConditionFToBeSubjVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Ving_No_Trans;

        public ATNConditionFToBeSubjVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjVingNoTransNode_v2 mSameNode;
        private InitATNConditionFToBeSubjVingNoTransNodeAction mInitAction;

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

