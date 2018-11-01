using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeBeingV3NoTransNodeAction(ATNQWSubjFToBeBeingV3NoTransNode_v2 item);

    public class ATNQWSubjFToBeBeingV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeBeingV3NoTransNodeFactory_v2(ATNQWSubjFToBeBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeBeingV3NoTransNodeFactory_v2(ATNQWSubjFToBeBeingV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeBeingV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeBeingV3TransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToBeBeingV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeBeingV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeBeingV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeBeingV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToBe_Being_V3_No_Obj_TransOrFin
*/

    public class ATNQWSubjFToBeBeingV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeBeingV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeBeingV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeBeingV3NoTransNode_v2 sameNode, InitATNQWSubjFToBeBeingV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Being_V3_No_Trans;

        public ATNQWSubjFToBeBeingV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeBeingV3NoTransNode_v2 mSameNode;
        private InitATNQWSubjFToBeBeingV3NoTransNodeAction mInitAction;

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

