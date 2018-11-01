using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillConditionVerbNoTransNodeAction(ATNSubjWillConditionVerbNoTransNode_v2 item);

    public class ATNSubjWillConditionVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillConditionVerbNoTransNodeFactory_v2(ATNSubjWillConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillConditionVerbNoTransNodeFactory_v2(ATNSubjWillConditionVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillConditionVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjWillConditionVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillConditionVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillConditionVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillConditionVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Condition_Verb_No_Obj_TransOrFin
*/

    public class ATNSubjWillConditionVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillConditionVerbNoTransNode_v2 sameNode, InitATNSubjWillConditionVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Condition_Verb_No_Trans;

        public ATNSubjWillConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillConditionVerbNoTransNode_v2 mSameNode;
        private InitATNSubjWillConditionVerbNoTransNodeAction mInitAction;

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

