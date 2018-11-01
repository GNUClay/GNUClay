using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNodeAction(ATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNode_v2 item);

    public class ATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeBeingConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeBeingConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Being_Condition_V3_Obj_Condition_Fin
*/

    public class ATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeBeingConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNode_v2 sameNode, InitATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Being_Condition_V3_Obj_TransOrFin;

        public ATNConditionSubjFToBeBeingConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeBeingConditionV3ObjTransOrFinNodeAction mInitAction;

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

