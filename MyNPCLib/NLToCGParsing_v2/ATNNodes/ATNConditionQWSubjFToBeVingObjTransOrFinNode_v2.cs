using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeVingObjTransOrFinNodeAction(ATNConditionQWSubjFToBeVingObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjFToBeVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeVingObjTransOrFinNodeFactory_v2(ATNConditionQWSubjFToBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeVingObjTransOrFinNodeFactory_v2(ATNConditionQWSubjFToBeVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToBe_Ving_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjFToBeVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeVingObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjFToBeVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Ving_Obj_TransOrFin;

        public ATNConditionQWSubjFToBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeVingObjTransOrFinNodeAction mInitAction;

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

