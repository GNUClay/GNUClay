using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillConditionVerbNoTransNodeAction(ATNConditionQWSubjWillConditionVerbNoTransNode_v2 item);

    public class ATNConditionQWSubjWillConditionVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillConditionVerbNoTransNodeFactory_v2(ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillConditionVerbNoTransNodeFactory_v2(ATNConditionQWSubjWillConditionVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillConditionVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillConditionVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillConditionVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillConditionVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillConditionVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_Condition_Verb_No_Obj_TransOrFin
*/

    public class ATNConditionQWSubjWillConditionVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillConditionVerbNoTransNode_v2 sameNode, InitATNConditionQWSubjWillConditionVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Condition_Verb_No_Trans;

        public ATNConditionQWSubjWillConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillConditionVerbNoTransNode_v2 mSameNode;
        private InitATNConditionQWSubjWillConditionVerbNoTransNodeAction mInitAction;

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

