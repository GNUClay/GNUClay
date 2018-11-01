using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToHaveTransNodeAction(ATNQWObjFToHaveTransNode_v2 item);

    public class ATNQWObjFToHaveTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToHaveTransNodeFactory_v2(ATNQWObjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToHaveTransNodeFactory_v2(ATNQWObjFToHaveTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToHaveTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjTransNode_v2 mParentNode;
        private ATNQWObjFToHaveTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToHaveTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToHaveTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToHaveTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_FToHave_Subj_Trans
*/

    public class ATNQWObjFToHaveTransNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToHaveTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToHaveTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToHaveTransNode_v2 sameNode, InitATNQWObjFToHaveTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToHave_Trans;

        public ATNQWObjTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToHaveTransNode_v2 mSameNode;
        private InitATNQWObjFToHaveTransNodeAction mInitAction;

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

