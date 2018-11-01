using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionConditionVerbNoTransNodeAction(ATNConditionConditionVerbNoTransNode_v2 item);

    public class ATNConditionConditionVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionConditionVerbNoTransNodeFactory_v2(ATNConditionConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionConditionVerbNoTransNodeFactory_v2(ATNConditionConditionVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionConditionVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionConditionVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionConditionVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionConditionVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionConditionVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Condition_Verb_No_Obj_TransOrFin
*/

    public class ATNConditionConditionVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionConditionVerbNoTransNode_v2 sameNode, InitATNConditionConditionVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Condition_Verb_No_Trans;

        public ATNConditionConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionConditionVerbNoTransNode_v2 mSameNode;
        private InitATNConditionConditionVerbNoTransNodeAction mInitAction;

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

