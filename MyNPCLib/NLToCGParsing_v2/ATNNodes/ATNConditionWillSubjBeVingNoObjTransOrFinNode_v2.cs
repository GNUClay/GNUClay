using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjBeVingNoObjTransOrFinNodeAction(ATNConditionWillSubjBeVingNoObjTransOrFinNode_v2 item);

    public class ATNConditionWillSubjBeVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjBeVingNoObjTransOrFinNodeFactory_v2(ATNConditionWillSubjBeVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjBeVingNoObjTransOrFinNodeFactory_v2(ATNConditionWillSubjBeVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjBeVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjBeVingNoTransNode_v2 mParentNode;
        private ATNConditionWillSubjBeVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjBeVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjBeVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjBeVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_Be_Ving_No_Obj_Condition_Fin
*/

    public class ATNConditionWillSubjBeVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjBeVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjBeVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeVingNoObjTransOrFinNode_v2 sameNode, InitATNConditionWillSubjBeVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Be_Ving_No_Obj_TransOrFin;

        public ATNConditionWillSubjBeVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjBeVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionWillSubjBeVingNoObjTransOrFinNodeAction mInitAction;

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

