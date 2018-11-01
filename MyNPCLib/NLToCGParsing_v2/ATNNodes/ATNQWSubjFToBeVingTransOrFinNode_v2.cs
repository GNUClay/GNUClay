using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeVingTransOrFinNodeAction(ATNQWSubjFToBeVingTransOrFinNode_v2 item);

    public class ATNQWSubjFToBeVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeVingTransOrFinNodeFactory_v2(ATNQWSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeVingTransOrFinNodeFactory_v2(ATNQWSubjFToBeVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeTransNode_v2 mParentNode;
        private ATNQWSubjFToBeVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToBe_Ving_Obj_TransOrFin
    QWSubj_FToBe_Ving_No_Trans
    QWSubj_FToBe_Ving_Condition_Fin
*/

    public class ATNQWSubjFToBeVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeVingTransOrFinNode_v2 sameNode, InitATNQWSubjFToBeVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Ving_TransOrFin;

        public ATNQWSubjFToBeTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeVingTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjFToBeVingTransOrFinNodeAction mInitAction;

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

