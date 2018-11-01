using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeVingNoObjTransOrFinNodeAction(ATNQWSubjFToBeVingNoObjTransOrFinNode_v2 item);

    public class ATNQWSubjFToBeVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeVingNoObjTransOrFinNodeFactory_v2(ATNQWSubjFToBeVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeVingNoObjTransOrFinNodeFactory_v2(ATNQWSubjFToBeVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeVingNoTransNode_v2 mParentNode;
        private ATNQWSubjFToBeVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToBe_Ving_No_Obj_Condition_Fin
*/

    public class ATNQWSubjFToBeVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeVingNoObjTransOrFinNode_v2 sameNode, InitATNQWSubjFToBeVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Ving_No_Obj_TransOrFin;

        public ATNQWSubjFToBeVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjFToBeVingNoObjTransOrFinNodeAction mInitAction;

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

