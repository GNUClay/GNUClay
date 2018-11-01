using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillTransNodeAction(ATNConditionQWObjWillTransNode_v2 item);

    public class ATNConditionQWObjWillTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillTransNodeFactory_v2(ATNConditionQWObjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillTransNodeFactory_v2(ATNConditionQWObjWillTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjTransNode_v2 mParentNode;
        private ATNConditionQWObjWillTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_Will_Subj_Trans
*/

    public class ATNConditionQWObjWillTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillTransNode_v2 sameNode, InitATNConditionQWObjWillTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Trans;

        public ATNConditionQWObjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillTransNode_v2 mSameNode;
        private InitATNConditionQWObjWillTransNodeAction mInitAction;

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

