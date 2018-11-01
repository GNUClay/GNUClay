using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToBeSubjBeingV3TransOrFinNodeAction(ATNQWObjFToBeSubjBeingV3TransOrFinNode_v2 item);

    public class ATNQWObjFToBeSubjBeingV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToBeSubjBeingV3TransOrFinNodeFactory_v2(ATNQWObjFToBeSubjBeingTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToBeSubjBeingV3TransOrFinNodeFactory_v2(ATNQWObjFToBeSubjBeingV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToBeSubjBeingV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToBeSubjBeingTransNode_v2 mParentNode;
        private ATNQWObjFToBeSubjBeingV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToBeSubjBeingV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToBeSubjBeingV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToBeSubjBeingV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_FToBe_Subj_Being_V3_Condition_Fin
*/

    public class ATNQWObjFToBeSubjBeingV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToBeSubjBeingV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjBeingTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToBeSubjBeingV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjBeingV3TransOrFinNode_v2 sameNode, InitATNQWObjFToBeSubjBeingV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToBe_Subj_Being_V3_TransOrFin;

        public ATNQWObjFToBeSubjBeingTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToBeSubjBeingV3TransOrFinNode_v2 mSameNode;
        private InitATNQWObjFToBeSubjBeingV3TransOrFinNodeAction mInitAction;

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

