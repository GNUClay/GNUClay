using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveBeenConditionTransNodeAction(ATNSubjFToHaveBeenConditionTransNode_v2 item);

    public class ATNSubjFToHaveBeenConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveBeenConditionTransNodeFactory_v2(ATNSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveBeenConditionTransNodeFactory_v2(ATNSubjFToHaveBeenConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveBeenConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveBeenTransNode_v2 mParentNode;
        private ATNSubjFToHaveBeenConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveBeenConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveBeenConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveBeenConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToHave_Been_Condition_Ving_TransOrFin
    Subj_FToHave_Been_Condition_V3_TransOrFin
*/

    public class ATNSubjFToHaveBeenConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenConditionTransNode_v2 sameNode, InitATNSubjFToHaveBeenConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Been_Condition_Trans;

        public ATNSubjFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveBeenConditionTransNode_v2 mSameNode;
        private InitATNSubjFToHaveBeenConditionTransNodeAction mInitAction;

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

