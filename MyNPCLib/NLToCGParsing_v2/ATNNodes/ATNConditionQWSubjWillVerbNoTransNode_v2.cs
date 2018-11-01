using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillVerbNoTransNodeAction(ATNConditionQWSubjWillVerbNoTransNode_v2 item);

    public class ATNConditionQWSubjWillVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillVerbNoTransNodeFactory_v2(ATNConditionQWSubjWillVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillVerbNoTransNodeFactory_v2(ATNConditionQWSubjWillVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_Verb_No_Obj_TransOrFin
*/

    public class ATNConditionQWSubjWillVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillVerbNoTransNode_v2 sameNode, InitATNConditionQWSubjWillVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Verb_No_Trans;

        public ATNConditionQWSubjWillVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillVerbNoTransNode_v2 mSameNode;
        private InitATNConditionQWSubjWillVerbNoTransNodeAction mInitAction;

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

