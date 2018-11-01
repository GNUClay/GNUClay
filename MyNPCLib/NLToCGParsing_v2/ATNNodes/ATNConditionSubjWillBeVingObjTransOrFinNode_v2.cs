using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeVingObjTransOrFinNodeAction(ATNConditionSubjWillBeVingObjTransOrFinNode_v2 item);

    public class ATNConditionSubjWillBeVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeVingObjTransOrFinNodeFactory_v2(ATNConditionSubjWillBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeVingObjTransOrFinNodeFactory_v2(ATNConditionSubjWillBeVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillBeVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Be_Ving_Obj_Condition_Fin
*/

    public class ATNConditionSubjWillBeVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeVingObjTransOrFinNode_v2 sameNode, InitATNConditionSubjWillBeVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_Ving_Obj_TransOrFin;

        public ATNConditionSubjWillBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillBeVingObjTransOrFinNodeAction mInitAction;

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

