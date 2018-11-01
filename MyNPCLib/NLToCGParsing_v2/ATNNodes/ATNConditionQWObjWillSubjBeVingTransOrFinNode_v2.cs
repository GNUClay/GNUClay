using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjBeVingTransOrFinNodeAction(ATNConditionQWObjWillSubjBeVingTransOrFinNode_v2 item);

    public class ATNConditionQWObjWillSubjBeVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjBeVingTransOrFinNodeFactory_v2(ATNConditionQWObjWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjBeVingTransOrFinNodeFactory_v2(ATNConditionQWObjWillSubjBeVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjBeVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjBeTransNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjBeVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjBeVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjBeVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjBeVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_Will_Subj_Be_Ving_Condition_Fin
*/

    public class ATNConditionQWObjWillSubjBeVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjBeVingTransOrFinNode_v2 sameNode, InitATNConditionQWObjWillSubjBeVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_Be_Ving_TransOrFin;

        public ATNConditionQWObjWillSubjBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjBeVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjBeVingTransOrFinNodeAction mInitAction;

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

