using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeConditionV3NoObjTransOrFinNodeAction(ATNQWSubjFToBeConditionV3NoObjTransOrFinNode_v2 item);

    public class ATNQWSubjFToBeConditionV3NoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeConditionV3NoObjTransOrFinNodeFactory_v2(ATNQWSubjFToBeConditionV3NoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeConditionV3NoObjTransOrFinNodeFactory_v2(ATNQWSubjFToBeConditionV3NoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeConditionV3NoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeConditionV3NoTransNode_v2 mParentNode;
        private ATNQWSubjFToBeConditionV3NoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeConditionV3NoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeConditionV3NoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeConditionV3NoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToBe_Condition_V3_No_Obj_Condition_Fin
*/

    public class ATNQWSubjFToBeConditionV3NoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeConditionV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeConditionV3NoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeConditionV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeConditionV3NoObjTransOrFinNode_v2 sameNode, InitATNQWSubjFToBeConditionV3NoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Condition_V3_No_Obj_TransOrFin;

        public ATNQWSubjFToBeConditionV3NoTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeConditionV3NoObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjFToBeConditionV3NoObjTransOrFinNodeAction mInitAction;

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

