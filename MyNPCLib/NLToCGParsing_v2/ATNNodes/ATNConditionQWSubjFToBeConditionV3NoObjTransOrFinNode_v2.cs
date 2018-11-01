using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNodeAction(ATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjFToBeConditionV3NoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeConditionV3NoTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToBe_Condition_V3_No_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionV3NoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Condition_V3_No_Obj_TransOrFin;

        public ATNConditionQWSubjFToBeConditionV3NoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeConditionV3NoObjTransOrFinNodeAction mInitAction;

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

