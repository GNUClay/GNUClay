using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToHaveSubjBeenVingNoTransNodeAction(ATNConditionFToHaveSubjBeenVingNoTransNode_v2 item);

    public class ATNConditionFToHaveSubjBeenVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToHaveSubjBeenVingNoTransNodeFactory_v2(ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToHaveSubjBeenVingNoTransNodeFactory_v2(ATNConditionFToHaveSubjBeenVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToHaveSubjBeenVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2 mParentNode;
        private ATNConditionFToHaveSubjBeenVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToHaveSubjBeenVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToHaveSubjBeenVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToHaveSubjBeenVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToHave_Subj_Been_Ving_No_Obj_TransOrFin
*/

    public class ATNConditionFToHaveSubjBeenVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToHaveSubjBeenVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToHaveSubjBeenVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenVingNoTransNode_v2 sameNode, InitATNConditionFToHaveSubjBeenVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToHave_Subj_Been_Ving_No_Trans;

        public ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToHaveSubjBeenVingNoTransNode_v2 mSameNode;
        private InitATNConditionFToHaveSubjBeenVingNoTransNodeAction mInitAction;

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

