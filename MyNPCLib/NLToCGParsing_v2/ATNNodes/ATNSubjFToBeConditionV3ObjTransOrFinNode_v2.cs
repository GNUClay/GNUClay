using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeConditionV3ObjTransOrFinNodeAction(ATNSubjFToBeConditionV3ObjTransOrFinNode_v2 item);

    public class ATNSubjFToBeConditionV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeConditionV3ObjTransOrFinNodeFactory_v2(ATNSubjFToBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeConditionV3ObjTransOrFinNodeFactory_v2(ATNSubjFToBeConditionV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeConditionV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeConditionV3TransOrFinNode_v2 mParentNode;
        private ATNSubjFToBeConditionV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeConditionV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeConditionV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeConditionV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToBe_Condition_V3_Obj_Condition_Fin
*/

    public class ATNSubjFToBeConditionV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeConditionV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeConditionV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeConditionV3ObjTransOrFinNode_v2 sameNode, InitATNSubjFToBeConditionV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Condition_V3_Obj_TransOrFin;

        public ATNSubjFToBeConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeConditionV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjFToBeConditionV3ObjTransOrFinNodeAction mInitAction;

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

