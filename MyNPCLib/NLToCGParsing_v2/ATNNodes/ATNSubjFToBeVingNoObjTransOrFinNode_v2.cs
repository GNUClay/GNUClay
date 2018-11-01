using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeVingNoObjTransOrFinNodeAction(ATNSubjFToBeVingNoObjTransOrFinNode_v2 item);

    public class ATNSubjFToBeVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeVingNoObjTransOrFinNodeFactory_v2(ATNSubjFToBeVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeVingNoObjTransOrFinNodeFactory_v2(ATNSubjFToBeVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeVingNoTransNode_v2 mParentNode;
        private ATNSubjFToBeVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToBe_Ving_No_Obj_Condition_Fin
*/

    public class ATNSubjFToBeVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeVingNoObjTransOrFinNode_v2 sameNode, InitATNSubjFToBeVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Ving_No_Obj_TransOrFin;

        public ATNSubjFToBeVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjFToBeVingNoObjTransOrFinNodeAction mInitAction;

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

