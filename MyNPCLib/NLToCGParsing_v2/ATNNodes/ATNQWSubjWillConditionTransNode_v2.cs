using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillConditionTransNodeAction(ATNQWSubjWillConditionTransNode_v2 item);

    public class ATNQWSubjWillConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillConditionTransNodeFactory_v2(ATNQWSubjWillTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillConditionTransNodeFactory_v2(ATNQWSubjWillConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillTransNode_v2 mParentNode;
        private ATNQWSubjWillConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_Condition_Verb_TransOrFin
*/

    public class ATNQWSubjWillConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillConditionTransNode_v2 sameNode, InitATNQWSubjWillConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Condition_Trans;

        public ATNQWSubjWillTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillConditionTransNode_v2 mSameNode;
        private InitATNQWSubjWillConditionTransNodeAction mInitAction;

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

