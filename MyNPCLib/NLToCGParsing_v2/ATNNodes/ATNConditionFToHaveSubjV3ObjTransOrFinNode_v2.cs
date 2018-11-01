using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToHaveSubjV3ObjTransOrFinNodeAction(ATNConditionFToHaveSubjV3ObjTransOrFinNode_v2 item);

    public class ATNConditionFToHaveSubjV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToHaveSubjV3ObjTransOrFinNodeFactory_v2(ATNConditionFToHaveSubjV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToHaveSubjV3ObjTransOrFinNodeFactory_v2(ATNConditionFToHaveSubjV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToHaveSubjV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToHaveSubjV3TransOrFinNode_v2 mParentNode;
        private ATNConditionFToHaveSubjV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToHaveSubjV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToHaveSubjV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToHaveSubjV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToHave_Subj_V3_Obj_Condition_Fin
*/

    public class ATNConditionFToHaveSubjV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToHaveSubjV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToHaveSubjV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjV3ObjTransOrFinNode_v2 sameNode, InitATNConditionFToHaveSubjV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToHave_Subj_V3_Obj_TransOrFin;

        public ATNConditionFToHaveSubjV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToHaveSubjV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionFToHaveSubjV3ObjTransOrFinNodeAction mInitAction;

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

