using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToBeSubjConditionVingTransOrFinNodeAction(ATNQWObjFToBeSubjConditionVingTransOrFinNode_v2 item);

    public class ATNQWObjFToBeSubjConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToBeSubjConditionVingTransOrFinNodeFactory_v2(ATNQWObjFToBeSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToBeSubjConditionVingTransOrFinNodeFactory_v2(ATNQWObjFToBeSubjConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToBeSubjConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToBeSubjConditionTransNode_v2 mParentNode;
        private ATNQWObjFToBeSubjConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToBeSubjConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToBeSubjConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToBeSubjConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_FToBe_Subj_Condition_Ving_Condition_Fin
*/

    public class ATNQWObjFToBeSubjConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToBeSubjConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToBeSubjConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjConditionVingTransOrFinNode_v2 sameNode, InitATNQWObjFToBeSubjConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToBe_Subj_Condition_Ving_TransOrFin;

        public ATNQWObjFToBeSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToBeSubjConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNQWObjFToBeSubjConditionVingTransOrFinNodeAction mInitAction;

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

