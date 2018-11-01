using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNodeAction(ATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjWillFToHaveBeenVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillFToHaveBeenVingNoTransNode_v2 mParentNode;
        private ATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_FToHave_Been_Ving_No_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveBeenVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_FToHave_Been_Ving_No_Obj_TransOrFin;

        public ATNConditionQWSubjWillFToHaveBeenVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillFToHaveBeenVingNoObjTransOrFinNodeAction mInitAction;

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

