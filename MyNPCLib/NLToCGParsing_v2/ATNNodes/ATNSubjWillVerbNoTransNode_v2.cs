using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillVerbNoTransNodeAction(ATNSubjWillVerbNoTransNode_v2 item);

    public class ATNSubjWillVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillVerbNoTransNodeFactory_v2(ATNSubjWillVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillVerbNoTransNodeFactory_v2(ATNSubjWillVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjWillVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Verb_No_Obj_TransOrFin
*/

    public class ATNSubjWillVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillVerbNoTransNode_v2 sameNode, InitATNSubjWillVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Verb_No_Trans;

        public ATNSubjWillVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillVerbNoTransNode_v2 mSameNode;
        private InitATNSubjWillVerbNoTransNodeAction mInitAction;

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

