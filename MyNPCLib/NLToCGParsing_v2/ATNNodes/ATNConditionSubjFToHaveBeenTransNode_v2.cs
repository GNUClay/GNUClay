using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveBeenTransNodeAction(ATNConditionSubjFToHaveBeenTransNode_v2 item);

    public class ATNConditionSubjFToHaveBeenTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveBeenTransNodeFactory_v2(ATNConditionSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveBeenTransNodeFactory_v2(ATNConditionSubjFToHaveBeenTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveBeenTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveTransNode_v2 mParentNode;
        private ATNConditionSubjFToHaveBeenTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveBeenTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveBeenTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveBeenTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToHave_Been_Ving_TransOrFin
    Condition_Subj_FToHave_Been_V3_TransOrFin
    Condition_Subj_FToHave_Been_Condition_Trans
*/

    public class ATNConditionSubjFToHaveBeenTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveBeenTransNode_v2 sameNode, InitATNConditionSubjFToHaveBeenTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Been_Trans;

        public ATNConditionSubjFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveBeenTransNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveBeenTransNodeAction mInitAction;

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

