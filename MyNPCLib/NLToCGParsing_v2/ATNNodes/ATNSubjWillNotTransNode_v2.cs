using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotTransNodeAction(ATNSubjWillNotTransNode_v2 item);

    public class ATNSubjWillNotTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotTransNodeFactory_v2(ATNSubjWillTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotTransNodeFactory_v2(ATNSubjWillNotTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillTransNode_v2 mParentNode;
        private ATNSubjWillNotTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Not_Verb_TransOrFin
    Subj_Will_Not_Be_Trans
    Subj_Will_Not_FToHave_Trans
    Subj_Will_Not_Condition_Trans
*/

    public class ATNSubjWillNotTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotTransNode_v2 sameNode, InitATNSubjWillNotTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_Trans;

        public ATNSubjWillTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotTransNode_v2 mSameNode;
        private InitATNSubjWillNotTransNodeAction mInitAction;

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

