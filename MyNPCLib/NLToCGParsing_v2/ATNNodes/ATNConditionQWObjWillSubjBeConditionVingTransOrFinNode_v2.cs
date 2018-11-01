using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjBeConditionVingTransOrFinNodeAction(ATNConditionQWObjWillSubjBeConditionVingTransOrFinNode_v2 item);

    public class ATNConditionQWObjWillSubjBeConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjBeConditionVingTransOrFinNodeFactory_v2(ATNConditionQWObjWillSubjBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjBeConditionVingTransOrFinNodeFactory_v2(ATNConditionQWObjWillSubjBeConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjBeConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjBeConditionTransNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjBeConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjBeConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjBeConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjBeConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_Will_Subj_Be_Condition_Ving_Condition_Fin
*/

    public class ATNConditionQWObjWillSubjBeConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjBeConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjBeConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjBeConditionVingTransOrFinNode_v2 sameNode, InitATNConditionQWObjWillSubjBeConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_Be_Condition_Ving_TransOrFin;

        public ATNConditionQWObjWillSubjBeConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjBeConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjBeConditionVingTransOrFinNodeAction mInitAction;

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

