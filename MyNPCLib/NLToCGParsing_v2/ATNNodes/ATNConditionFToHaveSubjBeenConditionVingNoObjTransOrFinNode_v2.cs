using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNodeAction(ATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2 item);

    public class ATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNodeFactory_v2(ATNConditionFToHaveSubjBeenConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNodeFactory_v2(ATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToHaveSubjBeenConditionVingNoTransNode_v2 mParentNode;
        private ATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToHave_Subj_Been_Condition_Ving_No_Obj_Condition_Fin
*/

    public class ATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2 sameNode, InitATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToHave_Subj_Been_Condition_Ving_No_Obj_TransOrFin;

        public ATNConditionFToHaveSubjBeenConditionVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionFToHaveSubjBeenConditionVingNoObjTransOrFinNodeAction mInitAction;

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

