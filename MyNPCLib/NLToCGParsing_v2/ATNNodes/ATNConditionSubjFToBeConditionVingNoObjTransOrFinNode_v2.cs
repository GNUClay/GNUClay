using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeConditionVingNoObjTransOrFinNodeAction(ATNConditionSubjFToBeConditionVingNoObjTransOrFinNode_v2 item);

    public class ATNConditionSubjFToBeConditionVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeConditionVingNoObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeConditionVingNoObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeConditionVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeConditionVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeConditionVingNoTransNode_v2 mParentNode;
        private ATNConditionSubjFToBeConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeConditionVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeConditionVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeConditionVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Condition_Ving_No_Obj_Condition_Fin
*/

    public class ATNConditionSubjFToBeConditionVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeConditionVingNoObjTransOrFinNode_v2 sameNode, InitATNConditionSubjFToBeConditionVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Condition_Ving_No_Obj_TransOrFin;

        public ATNConditionSubjFToBeConditionVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeConditionVingNoObjTransOrFinNodeAction mInitAction;

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

