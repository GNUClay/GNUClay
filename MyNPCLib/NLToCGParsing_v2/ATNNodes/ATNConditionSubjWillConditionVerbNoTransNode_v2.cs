using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillConditionVerbNoTransNodeAction(ATNConditionSubjWillConditionVerbNoTransNode_v2 item);

    public class ATNConditionSubjWillConditionVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillConditionVerbNoTransNodeFactory_v2(ATNConditionSubjWillConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillConditionVerbNoTransNodeFactory_v2(ATNConditionSubjWillConditionVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillConditionVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillConditionVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillConditionVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillConditionVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillConditionVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Condition_Verb_No_Obj_TransOrFin
*/

    public class ATNConditionSubjWillConditionVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillConditionVerbNoTransNode_v2 sameNode, InitATNConditionSubjWillConditionVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Condition_Verb_No_Trans;

        public ATNConditionSubjWillConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillConditionVerbNoTransNode_v2 mSameNode;
        private InitATNConditionSubjWillConditionVerbNoTransNodeAction mInitAction;

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

