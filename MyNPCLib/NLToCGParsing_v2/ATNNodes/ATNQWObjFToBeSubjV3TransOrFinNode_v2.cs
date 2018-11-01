using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToBeSubjV3TransOrFinNodeAction(ATNQWObjFToBeSubjV3TransOrFinNode_v2 item);

    public class ATNQWObjFToBeSubjV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToBeSubjV3TransOrFinNodeFactory_v2(ATNQWObjFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToBeSubjV3TransOrFinNodeFactory_v2(ATNQWObjFToBeSubjV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToBeSubjV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToBeSubjTransNode_v2 mParentNode;
        private ATNQWObjFToBeSubjV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToBeSubjV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToBeSubjV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToBeSubjV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_FToBe_Subj_V3_Condition_Fin
*/

    public class ATNQWObjFToBeSubjV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToBeSubjV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToBeSubjV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjV3TransOrFinNode_v2 sameNode, InitATNQWObjFToBeSubjV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToBe_Subj_V3_TransOrFin;

        public ATNQWObjFToBeSubjTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToBeSubjV3TransOrFinNode_v2 mSameNode;
        private InitATNQWObjFToBeSubjV3TransOrFinNodeAction mInitAction;

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

