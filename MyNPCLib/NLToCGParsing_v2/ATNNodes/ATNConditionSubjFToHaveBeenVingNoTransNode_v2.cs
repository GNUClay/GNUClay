using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveBeenVingNoTransNodeAction(ATNConditionSubjFToHaveBeenVingNoTransNode_v2 item);

    public class ATNConditionSubjFToHaveBeenVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveBeenVingNoTransNodeFactory_v2(ATNConditionSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveBeenVingNoTransNodeFactory_v2(ATNConditionSubjFToHaveBeenVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveBeenVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveBeenVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToHaveBeenVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveBeenVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveBeenVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveBeenVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToHave_Been_Ving_No_Obj_TransOrFin
*/

    public class ATNConditionSubjFToHaveBeenVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveBeenVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveBeenVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveBeenVingNoTransNode_v2 sameNode, InitATNConditionSubjFToHaveBeenVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Been_Ving_No_Trans;

        public ATNConditionSubjFToHaveBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveBeenVingNoTransNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveBeenVingNoTransNodeAction mInitAction;

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

