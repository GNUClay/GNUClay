using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjBeVingObjTransOrFinNodeAction(ATNConditionWillSubjBeVingObjTransOrFinNode_v2 item);

    public class ATNConditionWillSubjBeVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjBeVingObjTransOrFinNodeFactory_v2(ATNConditionWillSubjBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjBeVingObjTransOrFinNodeFactory_v2(ATNConditionWillSubjBeVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjBeVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjBeVingTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjBeVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjBeVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjBeVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjBeVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_Be_Ving_Obj_Condition_Fin
*/

    public class ATNConditionWillSubjBeVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeVingObjTransOrFinNode_v2 sameNode, InitATNConditionWillSubjBeVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Be_Ving_Obj_TransOrFin;

        public ATNConditionWillSubjBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjBeVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionWillSubjBeVingObjTransOrFinNodeAction mInitAction;

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

