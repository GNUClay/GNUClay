using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToBeTransNodeAction(ATNConditionQWObjFToBeTransNode_v2 item);

    public class ATNConditionQWObjFToBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToBeTransNodeFactory_v2(ATNConditionQWObjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToBeTransNodeFactory_v2(ATNConditionQWObjFToBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjTransNode_v2 mParentNode;
        private ATNConditionQWObjFToBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_FToBe_Subj_Trans
*/

    public class ATNConditionQWObjFToBeTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeTransNode_v2 sameNode, InitATNConditionQWObjFToBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToBe_Trans;

        public ATNConditionQWObjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToBeTransNode_v2 mSameNode;
        private InitATNConditionQWObjFToBeTransNodeAction mInitAction;

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

