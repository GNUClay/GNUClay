using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeConditionVingNoObjTransOrFinNodeAction(ATNQWSubjFToBeConditionVingNoObjTransOrFinNode_v2 item);

    public class ATNQWSubjFToBeConditionVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeConditionVingNoObjTransOrFinNodeFactory_v2(ATNQWSubjFToBeConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeConditionVingNoObjTransOrFinNodeFactory_v2(ATNQWSubjFToBeConditionVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeConditionVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeConditionVingNoTransNode_v2 mParentNode;
        private ATNQWSubjFToBeConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeConditionVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeConditionVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeConditionVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToBe_Condition_Ving_No_Obj_Condition_Fin
*/

    public class ATNQWSubjFToBeConditionVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeConditionVingNoObjTransOrFinNode_v2 sameNode, InitATNQWSubjFToBeConditionVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Condition_Ving_No_Obj_TransOrFin;

        public ATNQWSubjFToBeConditionVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjFToBeConditionVingNoObjTransOrFinNodeAction mInitAction;

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

