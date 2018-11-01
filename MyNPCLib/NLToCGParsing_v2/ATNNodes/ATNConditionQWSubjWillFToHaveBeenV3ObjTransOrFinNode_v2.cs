using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNodeAction(ATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNodeFactory_v2(ATNConditionQWSubjWillFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNodeFactory_v2(ATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillFToHaveBeenV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_FToHave_Been_V3_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_FToHave_Been_V3_Obj_TransOrFin;

        public ATNConditionQWSubjWillFToHaveBeenV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillFToHaveBeenV3ObjTransOrFinNodeAction mInitAction;

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

