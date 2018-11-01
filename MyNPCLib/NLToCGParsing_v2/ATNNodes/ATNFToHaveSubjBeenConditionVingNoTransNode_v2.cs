using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToHaveSubjBeenConditionVingNoTransNodeAction(ATNFToHaveSubjBeenConditionVingNoTransNode_v2 item);

    public class ATNFToHaveSubjBeenConditionVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToHaveSubjBeenConditionVingNoTransNodeFactory_v2(ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToHaveSubjBeenConditionVingNoTransNodeFactory_v2(ATNFToHaveSubjBeenConditionVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNFToHaveSubjBeenConditionVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2 mParentNode;
        private ATNFToHaveSubjBeenConditionVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToHaveSubjBeenConditionVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToHaveSubjBeenConditionVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToHaveSubjBeenConditionVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToHave_Subj_Been_Condition_Ving_No_Obj_TransOrFin
*/

    public class ATNFToHaveSubjBeenConditionVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNFToHaveSubjBeenConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToHaveSubjBeenConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenConditionVingNoTransNode_v2 sameNode, InitATNFToHaveSubjBeenConditionVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToHave_Subj_Been_Condition_Ving_No_Trans;

        public ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToHaveSubjBeenConditionVingNoTransNode_v2 mSameNode;
        private InitATNFToHaveSubjBeenConditionVingNoTransNodeAction mInitAction;

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

