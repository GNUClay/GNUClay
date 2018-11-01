using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeConditionVingObjTransOrFinNodeAction(ATNConditionQWSubjFToBeConditionVingObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjFToBeConditionVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeConditionVingObjTransOrFinNodeFactory_v2(ATNConditionQWSubjFToBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeConditionVingObjTransOrFinNodeFactory_v2(ATNConditionQWSubjFToBeConditionVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeConditionVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeConditionVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeConditionVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeConditionVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeConditionVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToBe_Condition_Ving_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjFToBeConditionVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionVingObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjFToBeConditionVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Condition_Ving_Obj_TransOrFin;

        public ATNConditionQWSubjFToBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeConditionVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeConditionVingObjTransOrFinNodeAction mInitAction;

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

