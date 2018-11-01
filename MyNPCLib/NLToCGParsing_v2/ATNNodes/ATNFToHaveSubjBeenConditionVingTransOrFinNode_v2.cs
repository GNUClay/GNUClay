using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToHaveSubjBeenConditionVingTransOrFinNodeAction(ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2 item);

    public class ATNFToHaveSubjBeenConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToHaveSubjBeenConditionVingTransOrFinNodeFactory_v2(ATNFToHaveSubjBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToHaveSubjBeenConditionVingTransOrFinNodeFactory_v2(ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToHaveSubjBeenConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToHaveSubjBeenConditionTransNode_v2 mParentNode;
        private ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToHaveSubjBeenConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToHave_Subj_Been_Condition_Ving_Obj_TransOrFin
    FToHave_Subj_Been_Condition_Ving_No_Trans
    FToHave_Subj_Been_Condition_Ving_Condition_Fin
*/

    public class ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2 sameNode, InitATNFToHaveSubjBeenConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToHave_Subj_Been_Condition_Ving_TransOrFin;

        public ATNFToHaveSubjBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNFToHaveSubjBeenConditionVingTransOrFinNodeAction mInitAction;

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

