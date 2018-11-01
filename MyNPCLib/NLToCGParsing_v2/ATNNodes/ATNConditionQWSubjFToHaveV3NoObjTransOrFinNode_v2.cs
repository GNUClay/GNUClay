using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToHaveV3NoObjTransOrFinNodeAction(ATNConditionQWSubjFToHaveV3NoObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjFToHaveV3NoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToHaveV3NoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjFToHaveV3NoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToHaveV3NoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjFToHaveV3NoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToHaveV3NoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToHaveV3NoTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToHaveV3NoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToHaveV3NoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToHaveV3NoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToHaveV3NoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToHave_V3_No_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjFToHaveV3NoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToHaveV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveV3NoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToHaveV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveV3NoObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjFToHaveV3NoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToHave_V3_No_Obj_TransOrFin;

        public ATNConditionQWSubjFToHaveV3NoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToHaveV3NoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToHaveV3NoObjTransOrFinNodeAction mInitAction;

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

