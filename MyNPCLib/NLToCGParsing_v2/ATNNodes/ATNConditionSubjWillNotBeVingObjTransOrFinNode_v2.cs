using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotBeVingObjTransOrFinNodeAction(ATNConditionSubjWillNotBeVingObjTransOrFinNode_v2 item);

    public class ATNConditionSubjWillNotBeVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotBeVingObjTransOrFinNodeFactory_v2(ATNConditionSubjWillNotBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotBeVingObjTransOrFinNodeFactory_v2(ATNConditionSubjWillNotBeVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotBeVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotBeVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillNotBeVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotBeVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotBeVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotBeVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Not_Be_Ving_Obj_Condition_Fin
*/

    public class ATNConditionSubjWillNotBeVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeVingObjTransOrFinNode_v2 sameNode, InitATNConditionSubjWillNotBeVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_Be_Ving_Obj_TransOrFin;

        public ATNConditionSubjWillNotBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotBeVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotBeVingObjTransOrFinNodeAction mInitAction;

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

