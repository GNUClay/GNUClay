using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeVingNoObjTransOrFinNodeAction(ATNConditionSubjFToBeVingNoObjTransOrFinNode_v2 item);

    public class ATNConditionSubjFToBeVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeVingNoObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeVingNoObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeVingNoTransNode_v2 mParentNode;
        private ATNConditionSubjFToBeVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Ving_No_Obj_Condition_Fin
*/

    public class ATNConditionSubjFToBeVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeVingNoObjTransOrFinNode_v2 sameNode, InitATNConditionSubjFToBeVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Ving_No_Obj_TransOrFin;

        public ATNConditionSubjFToBeVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeVingNoObjTransOrFinNodeAction mInitAction;

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

