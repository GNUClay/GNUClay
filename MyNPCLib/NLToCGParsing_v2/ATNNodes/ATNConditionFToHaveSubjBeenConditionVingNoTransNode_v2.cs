using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToHaveSubjBeenConditionVingNoTransNodeAction(ATNConditionFToHaveSubjBeenConditionVingNoTransNode_v2 item);

    public class ATNConditionFToHaveSubjBeenConditionVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToHaveSubjBeenConditionVingNoTransNodeFactory_v2(ATNConditionFToHaveSubjBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToHaveSubjBeenConditionVingNoTransNodeFactory_v2(ATNConditionFToHaveSubjBeenConditionVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToHaveSubjBeenConditionVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToHaveSubjBeenConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionFToHaveSubjBeenConditionVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToHaveSubjBeenConditionVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToHaveSubjBeenConditionVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToHaveSubjBeenConditionVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToHave_Subj_Been_Condition_Ving_No_Obj_TransOrFin
*/

    public class ATNConditionFToHaveSubjBeenConditionVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToHaveSubjBeenConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToHaveSubjBeenConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenConditionVingNoTransNode_v2 sameNode, InitATNConditionFToHaveSubjBeenConditionVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToHave_Subj_Been_Condition_Ving_No_Trans;

        public ATNConditionFToHaveSubjBeenConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToHaveSubjBeenConditionVingNoTransNode_v2 mSameNode;
        private InitATNConditionFToHaveSubjBeenConditionVingNoTransNodeAction mInitAction;

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

