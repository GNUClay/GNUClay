using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeConditionVingNoObjTransOrFinNodeAction(ATNSubjFToBeConditionVingNoObjTransOrFinNode_v2 item);

    public class ATNSubjFToBeConditionVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeConditionVingNoObjTransOrFinNodeFactory_v2(ATNSubjFToBeConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeConditionVingNoObjTransOrFinNodeFactory_v2(ATNSubjFToBeConditionVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeConditionVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeConditionVingNoTransNode_v2 mParentNode;
        private ATNSubjFToBeConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeConditionVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeConditionVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeConditionVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToBe_Condition_Ving_No_Obj_Condition_Fin
*/

    public class ATNSubjFToBeConditionVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeConditionVingNoObjTransOrFinNode_v2 sameNode, InitATNSubjFToBeConditionVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Condition_Ving_No_Obj_TransOrFin;

        public ATNSubjFToBeConditionVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjFToBeConditionVingNoObjTransOrFinNodeAction mInitAction;

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

