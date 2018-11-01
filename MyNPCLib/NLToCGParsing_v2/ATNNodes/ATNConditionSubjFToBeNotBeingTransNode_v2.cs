using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeNotBeingTransNodeAction(ATNConditionSubjFToBeNotBeingTransNode_v2 item);

    public class ATNConditionSubjFToBeNotBeingTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeNotBeingTransNodeFactory_v2(ATNConditionSubjFToBeNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeNotBeingTransNodeFactory_v2(ATNConditionSubjFToBeNotBeingTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeNotBeingTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeNotTransNode_v2 mParentNode;
        private ATNConditionSubjFToBeNotBeingTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeNotBeingTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeNotBeingTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeNotBeingTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Not_Being_V3_TransOrFin
    Condition_Subj_FToBe_Not_Being_Condition_Trans
*/

    public class ATNConditionSubjFToBeNotBeingTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeNotBeingTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeNotBeingTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotBeingTransNode_v2 sameNode, InitATNConditionSubjFToBeNotBeingTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Not_Being_Trans;

        public ATNConditionSubjFToBeNotTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeNotBeingTransNode_v2 mSameNode;
        private InitATNConditionSubjFToBeNotBeingTransNodeAction mInitAction;

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

