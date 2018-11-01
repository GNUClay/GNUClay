using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillVerbTransOrFinNodeAction(ATNSubjWillVerbTransOrFinNode_v2 item);

    public class ATNSubjWillVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillVerbTransOrFinNodeFactory_v2(ATNSubjWillTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillVerbTransOrFinNodeFactory_v2(ATNSubjWillVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillTransNode_v2 mParentNode;
        private ATNSubjWillVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Verb_Obj_TransOrFin
    Subj_Will_Verb_No_Trans
    Subj_Will_Verb_Condition_Fin
*/

    public class ATNSubjWillVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillVerbTransOrFinNode_v2 sameNode, InitATNSubjWillVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Verb_TransOrFin;

        public ATNSubjWillTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillVerbTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillVerbTransOrFinNodeAction mInitAction;

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

