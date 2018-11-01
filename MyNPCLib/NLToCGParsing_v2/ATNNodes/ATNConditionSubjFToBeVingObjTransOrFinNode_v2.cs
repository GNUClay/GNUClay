using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeVingObjTransOrFinNodeAction(ATNConditionSubjFToBeVingObjTransOrFinNode_v2 item);

    public class ATNConditionSubjFToBeVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeVingObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeVingObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Ving_Obj_Condition_Fin
*/

    public class ATNConditionSubjFToBeVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeVingObjTransOrFinNode_v2 sameNode, InitATNConditionSubjFToBeVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Ving_Obj_TransOrFin;

        public ATNConditionSubjFToBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeVingObjTransOrFinNodeAction mInitAction;

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

