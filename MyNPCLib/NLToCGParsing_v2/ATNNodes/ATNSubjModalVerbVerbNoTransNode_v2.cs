using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjModalVerbVerbNoTransNodeAction(ATNSubjModalVerbVerbNoTransNode_v2 item);

    public class ATNSubjModalVerbVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjModalVerbVerbNoTransNodeFactory_v2(ATNSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjModalVerbVerbNoTransNodeFactory_v2(ATNSubjModalVerbVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjModalVerbVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjModalVerbVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjModalVerbVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjModalVerbVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjModalVerbVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjModalVerbVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_ModalVerb_Verb_No_Obj_TransOrFin
*/

    public class ATNSubjModalVerbVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjModalVerbVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjModalVerbVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbVerbNoTransNode_v2 sameNode, InitATNSubjModalVerbVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_ModalVerb_Verb_No_Trans;

        public ATNSubjModalVerbVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjModalVerbVerbNoTransNode_v2 mSameNode;
        private InitATNSubjModalVerbVerbNoTransNodeAction mInitAction;

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

