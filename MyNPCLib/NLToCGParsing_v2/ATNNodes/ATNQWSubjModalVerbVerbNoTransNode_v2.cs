using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjModalVerbVerbNoTransNodeAction(ATNQWSubjModalVerbVerbNoTransNode_v2 item);

    public class ATNQWSubjModalVerbVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjModalVerbVerbNoTransNodeFactory_v2(ATNQWSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjModalVerbVerbNoTransNodeFactory_v2(ATNQWSubjModalVerbVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjModalVerbVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjModalVerbVerbTransOrFinNode_v2 mParentNode;
        private ATNQWSubjModalVerbVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjModalVerbVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjModalVerbVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjModalVerbVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_ModalVerb_Verb_No_Obj_TransOrFin
*/

    public class ATNQWSubjModalVerbVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjModalVerbVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjModalVerbVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjModalVerbVerbNoTransNode_v2 sameNode, InitATNQWSubjModalVerbVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_ModalVerb_Verb_No_Trans;

        public ATNQWSubjModalVerbVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjModalVerbVerbNoTransNode_v2 mSameNode;
        private InitATNQWSubjModalVerbVerbNoTransNodeAction mInitAction;

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

