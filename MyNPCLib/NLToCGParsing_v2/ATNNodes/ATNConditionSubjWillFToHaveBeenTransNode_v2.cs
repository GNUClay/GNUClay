using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillFToHaveBeenTransNodeAction(ATNConditionSubjWillFToHaveBeenTransNode_v2 item);

    public class ATNConditionSubjWillFToHaveBeenTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillFToHaveBeenTransNodeFactory_v2(ATNConditionSubjWillFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillFToHaveBeenTransNodeFactory_v2(ATNConditionSubjWillFToHaveBeenTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillFToHaveBeenTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillFToHaveTransNode_v2 mParentNode;
        private ATNConditionSubjWillFToHaveBeenTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillFToHaveBeenTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillFToHaveBeenTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillFToHaveBeenTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_FToHave_Been_Ving_TransOrFin
    Condition_Subj_Will_FToHave_Been_V3_TransOrFin
    Condition_Subj_Will_FToHave_Been_Condition_Trans
*/

    public class ATNConditionSubjWillFToHaveBeenTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillFToHaveBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillFToHaveBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenTransNode_v2 sameNode, InitATNConditionSubjWillFToHaveBeenTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_FToHave_Been_Trans;

        public ATNConditionSubjWillFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillFToHaveBeenTransNode_v2 mSameNode;
        private InitATNConditionSubjWillFToHaveBeenTransNodeAction mInitAction;

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

