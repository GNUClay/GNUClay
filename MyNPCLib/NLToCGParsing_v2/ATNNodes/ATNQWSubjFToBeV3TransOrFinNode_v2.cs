using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeV3TransOrFinNodeAction(ATNQWSubjFToBeV3TransOrFinNode_v2 item);

    public class ATNQWSubjFToBeV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeV3TransOrFinNodeFactory_v2(ATNQWSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeV3TransOrFinNodeFactory_v2(ATNQWSubjFToBeV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeTransNode_v2 mParentNode;
        private ATNQWSubjFToBeV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToBe_V3_Obj_TransOrFin
    QWSubj_FToBe_V3_No_Trans
    QWSubj_FToBe_V3_Condition_Fin
*/

    public class ATNQWSubjFToBeV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeV3TransOrFinNode_v2 sameNode, InitATNQWSubjFToBeV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_V3_TransOrFin;

        public ATNQWSubjFToBeTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeV3TransOrFinNode_v2 mSameNode;
        private InitATNQWSubjFToBeV3TransOrFinNodeAction mInitAction;

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

