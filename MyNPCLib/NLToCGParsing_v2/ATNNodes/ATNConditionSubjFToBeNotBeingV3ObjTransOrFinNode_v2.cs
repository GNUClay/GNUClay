using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeNotBeingV3ObjTransOrFinNodeAction(ATNConditionSubjFToBeNotBeingV3ObjTransOrFinNode_v2 item);

    public class ATNConditionSubjFToBeNotBeingV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeNotBeingV3ObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeNotBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeNotBeingV3ObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeNotBeingV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeNotBeingV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeNotBeingV3TransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeNotBeingV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeNotBeingV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeNotBeingV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeNotBeingV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Not_Being_V3_Obj_Condition_Fin
*/

    public class ATNConditionSubjFToBeNotBeingV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeNotBeingV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeNotBeingV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotBeingV3ObjTransOrFinNode_v2 sameNode, InitATNConditionSubjFToBeNotBeingV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Not_Being_V3_Obj_TransOrFin;

        public ATNConditionSubjFToBeNotBeingV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeNotBeingV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeNotBeingV3ObjTransOrFinNodeAction mInitAction;

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

