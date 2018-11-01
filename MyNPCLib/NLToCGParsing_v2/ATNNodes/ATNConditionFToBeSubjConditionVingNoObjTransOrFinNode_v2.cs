using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjConditionVingNoObjTransOrFinNodeAction(ATNConditionFToBeSubjConditionVingNoObjTransOrFinNode_v2 item);

    public class ATNConditionFToBeSubjConditionVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjConditionVingNoObjTransOrFinNodeFactory_v2(ATNConditionFToBeSubjConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjConditionVingNoObjTransOrFinNodeFactory_v2(ATNConditionFToBeSubjConditionVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjConditionVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjConditionVingNoTransNode_v2 mParentNode;
        private ATNConditionFToBeSubjConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjConditionVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjConditionVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjConditionVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToBe_Subj_Condition_Ving_No_Obj_Condition_Fin
*/

    public class ATNConditionFToBeSubjConditionVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjConditionVingNoObjTransOrFinNode_v2 sameNode, InitATNConditionFToBeSubjConditionVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Condition_Ving_No_Obj_TransOrFin;

        public ATNConditionFToBeSubjConditionVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjConditionVingNoObjTransOrFinNodeAction mInitAction;

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

