using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjVingNoObjTransOrFinNodeAction(ATNConditionFToBeSubjVingNoObjTransOrFinNode_v2 item);

    public class ATNConditionFToBeSubjVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjVingNoObjTransOrFinNodeFactory_v2(ATNConditionFToBeSubjVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjVingNoObjTransOrFinNodeFactory_v2(ATNConditionFToBeSubjVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjVingNoTransNode_v2 mParentNode;
        private ATNConditionFToBeSubjVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToBe_Subj_Ving_No_Obj_Condition_Fin
*/

    public class ATNConditionFToBeSubjVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjVingNoObjTransOrFinNode_v2 sameNode, InitATNConditionFToBeSubjVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Ving_No_Obj_TransOrFin;

        public ATNConditionFToBeSubjVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjVingNoObjTransOrFinNodeAction mInitAction;

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

