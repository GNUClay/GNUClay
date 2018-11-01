using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeVingNoObjTransOrFinNodeAction(ATNConditionSubjWillBeVingNoObjTransOrFinNode_v2 item);

    public class ATNConditionSubjWillBeVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeVingNoObjTransOrFinNodeFactory_v2(ATNConditionSubjWillBeVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeVingNoObjTransOrFinNodeFactory_v2(ATNConditionSubjWillBeVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeVingNoTransNode_v2 mParentNode;
        private ATNConditionSubjWillBeVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Be_Ving_No_Obj_Condition_Fin
*/

    public class ATNConditionSubjWillBeVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeVingNoObjTransOrFinNode_v2 sameNode, InitATNConditionSubjWillBeVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_Ving_No_Obj_TransOrFin;

        public ATNConditionSubjWillBeVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillBeVingNoObjTransOrFinNodeAction mInitAction;

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

