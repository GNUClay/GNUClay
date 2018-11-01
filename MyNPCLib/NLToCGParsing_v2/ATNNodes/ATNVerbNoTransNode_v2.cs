using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNVerbNoTransNodeAction(ATNVerbNoTransNode_v2 item);

    public class ATNVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNVerbNoTransNodeFactory_v2(ATNVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNVerbNoTransNodeFactory_v2(ATNVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNVerbTransOrFinNode_v2 mParentNode;
        private ATNVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Verb_No_Obj_TransOrFin
*/

    public class ATNVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNVerbNoTransNode_v2 sameNode, InitATNVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Verb_No_Trans;

        public ATNVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNVerbNoTransNode_v2 mSameNode;
        private InitATNVerbNoTransNodeAction mInitAction;

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

