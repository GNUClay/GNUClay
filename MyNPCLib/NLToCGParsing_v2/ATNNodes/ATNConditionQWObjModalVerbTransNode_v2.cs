using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjModalVerbTransNodeAction(ATNConditionQWObjModalVerbTransNode_v2 item);

    public class ATNConditionQWObjModalVerbTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjModalVerbTransNodeFactory_v2(ATNConditionQWObjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjModalVerbTransNodeFactory_v2(ATNConditionQWObjModalVerbTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjModalVerbTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjTransNode_v2 mParentNode;
        private ATNConditionQWObjModalVerbTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjModalVerbTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjModalVerbTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjModalVerbTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_ModalVerb_Subj_Trans
*/

    public class ATNConditionQWObjModalVerbTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjModalVerbTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjModalVerbTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjModalVerbTransNode_v2 sameNode, InitATNConditionQWObjModalVerbTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_ModalVerb_Trans;

        public ATNConditionQWObjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjModalVerbTransNode_v2 mSameNode;
        private InitATNConditionQWObjModalVerbTransNodeAction mInitAction;

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

