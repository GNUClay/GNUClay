using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveNotBeenConditionTransNodeAction(ATNSubjFToHaveNotBeenConditionTransNode_v2 item);

    public class ATNSubjFToHaveNotBeenConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveNotBeenConditionTransNodeFactory_v2(ATNSubjFToHaveNotBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveNotBeenConditionTransNodeFactory_v2(ATNSubjFToHaveNotBeenConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveNotBeenConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveNotBeenTransNode_v2 mParentNode;
        private ATNSubjFToHaveNotBeenConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveNotBeenConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveNotBeenConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveNotBeenConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToHave_Not_Been_Condition_Ving_TransOrFin
    Subj_FToHave_Not_Been_Condition_V3_TransOrFin
*/

    public class ATNSubjFToHaveNotBeenConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveNotBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveNotBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotBeenConditionTransNode_v2 sameNode, InitATNSubjFToHaveNotBeenConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Not_Been_Condition_Trans;

        public ATNSubjFToHaveNotBeenTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveNotBeenConditionTransNode_v2 mSameNode;
        private InitATNSubjFToHaveNotBeenConditionTransNodeAction mInitAction;

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

