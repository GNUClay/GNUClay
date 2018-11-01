using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjModalVerbTransNodeAction(ATNQWObjModalVerbTransNode_v2 item);

    public class ATNQWObjModalVerbTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjModalVerbTransNodeFactory_v2(ATNQWObjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjModalVerbTransNodeFactory_v2(ATNQWObjModalVerbTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjModalVerbTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjTransNode_v2 mParentNode;
        private ATNQWObjModalVerbTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjModalVerbTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjModalVerbTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjModalVerbTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_ModalVerb_Subj_Trans
*/

    public class ATNQWObjModalVerbTransNode_v2: BaseATNNode_v2
    {
        public ATNQWObjModalVerbTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjModalVerbTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjModalVerbTransNode_v2 sameNode, InitATNQWObjModalVerbTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_ModalVerb_Trans;

        public ATNQWObjTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjModalVerbTransNode_v2 mSameNode;
        private InitATNQWObjModalVerbTransNodeAction mInitAction;

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

