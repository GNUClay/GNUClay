using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillTransNodeAction(ATNQWObjWillTransNode_v2 item);

    public class ATNQWObjWillTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillTransNodeFactory_v2(ATNQWObjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillTransNodeFactory_v2(ATNQWObjWillTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjTransNode_v2 mParentNode;
        private ATNQWObjWillTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_Will_Subj_Trans
*/

    public class ATNQWObjWillTransNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillTransNode_v2 sameNode, InitATNQWObjWillTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Trans;

        public ATNQWObjTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillTransNode_v2 mSameNode;
        private InitATNQWObjWillTransNodeAction mInitAction;

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

