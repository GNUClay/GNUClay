using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillTransNodeAction(ATNSubjWillTransNode_v2 item);

    public class ATNSubjWillTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillTransNodeFactory_v2(ATNSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillTransNodeFactory_v2(ATNSubjWillTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjTransNode_v2 mParentNode;
        private ATNSubjWillTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Verb_TransOrFin
    Subj_Will_Not_Trans
    Subj_Will_Be_Trans
    Subj_Will_FToHave_Trans
    Subj_Will_Condition_Trans
*/

    public class ATNSubjWillTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillTransNode_v2 sameNode, InitATNSubjWillTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Trans;

        public ATNSubjTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillTransNode_v2 mSameNode;
        private InitATNSubjWillTransNodeAction mInitAction;

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

