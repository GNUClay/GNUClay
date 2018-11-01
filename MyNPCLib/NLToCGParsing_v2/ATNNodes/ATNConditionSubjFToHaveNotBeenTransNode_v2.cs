using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveNotBeenTransNodeAction(ATNConditionSubjFToHaveNotBeenTransNode_v2 item);

    public class ATNConditionSubjFToHaveNotBeenTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveNotBeenTransNodeFactory_v2(ATNConditionSubjFToHaveNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveNotBeenTransNodeFactory_v2(ATNConditionSubjFToHaveNotBeenTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveNotBeenTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveNotTransNode_v2 mParentNode;
        private ATNConditionSubjFToHaveNotBeenTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveNotBeenTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveNotBeenTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveNotBeenTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToHave_Not_Been_Ving_TransOrFin
    Condition_Subj_FToHave_Not_Been_V3_TransOrFin
    Condition_Subj_FToHave_Not_Been_Condition_Trans
*/

    public class ATNConditionSubjFToHaveNotBeenTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveNotBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveNotBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveNotBeenTransNode_v2 sameNode, InitATNConditionSubjFToHaveNotBeenTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Not_Been_Trans;

        public ATNConditionSubjFToHaveNotTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveNotBeenTransNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveNotBeenTransNodeAction mInitAction;

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

