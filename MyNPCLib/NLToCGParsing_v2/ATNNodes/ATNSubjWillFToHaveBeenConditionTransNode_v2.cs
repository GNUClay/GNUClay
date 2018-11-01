using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillFToHaveBeenConditionTransNodeAction(ATNSubjWillFToHaveBeenConditionTransNode_v2 item);

    public class ATNSubjWillFToHaveBeenConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillFToHaveBeenConditionTransNodeFactory_v2(ATNSubjWillFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillFToHaveBeenConditionTransNodeFactory_v2(ATNSubjWillFToHaveBeenConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillFToHaveBeenConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillFToHaveBeenTransNode_v2 mParentNode;
        private ATNSubjWillFToHaveBeenConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillFToHaveBeenConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillFToHaveBeenConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillFToHaveBeenConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_FToHave_Been_Condition_Ving_TransOrFin
    Subj_Will_FToHave_Been_Condition_V3_TransOrFin
*/

    public class ATNSubjWillFToHaveBeenConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenConditionTransNode_v2 sameNode, InitATNSubjWillFToHaveBeenConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_FToHave_Been_Condition_Trans;

        public ATNSubjWillFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillFToHaveBeenConditionTransNode_v2 mSameNode;
        private InitATNSubjWillFToHaveBeenConditionTransNodeAction mInitAction;

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

