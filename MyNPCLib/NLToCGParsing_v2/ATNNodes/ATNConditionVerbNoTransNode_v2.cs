using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionVerbNoTransNodeAction(ATNConditionVerbNoTransNode_v2 item);

    public class ATNConditionVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionVerbNoTransNodeFactory_v2(ATNConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionVerbNoTransNodeFactory_v2(ATNConditionVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Verb_No_Obj_TransOrFin
*/

    public class ATNConditionVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionVerbNoTransNode_v2 sameNode, InitATNConditionVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Verb_No_Trans;

        public ATNConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionVerbNoTransNode_v2 mSameNode;
        private InitATNConditionVerbNoTransNodeAction mInitAction;

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

