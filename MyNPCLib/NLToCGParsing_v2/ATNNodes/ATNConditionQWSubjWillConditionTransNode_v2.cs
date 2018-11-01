using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillConditionTransNodeAction(ATNConditionQWSubjWillConditionTransNode_v2 item);

    public class ATNConditionQWSubjWillConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillConditionTransNodeFactory_v2(ATNConditionQWSubjWillTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillConditionTransNodeFactory_v2(ATNConditionQWSubjWillConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillTransNode_v2 mParentNode;
        private ATNConditionQWSubjWillConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_Condition_Verb_TransOrFin
*/

    public class ATNConditionQWSubjWillConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillConditionTransNode_v2 sameNode, InitATNConditionQWSubjWillConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Condition_Trans;

        public ATNConditionQWSubjWillTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillConditionTransNode_v2 mSameNode;
        private InitATNConditionQWSubjWillConditionTransNodeAction mInitAction;

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

