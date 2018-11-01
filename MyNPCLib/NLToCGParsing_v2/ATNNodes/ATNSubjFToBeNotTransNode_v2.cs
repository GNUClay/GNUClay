using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeNotTransNodeAction(ATNSubjFToBeNotTransNode_v2 item);

    public class ATNSubjFToBeNotTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeNotTransNodeFactory_v2(ATNSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeNotTransNodeFactory_v2(ATNSubjFToBeNotTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeNotTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeTransNode_v2 mParentNode;
        private ATNSubjFToBeNotTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeNotTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeNotTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeNotTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToBe_Not_Ving_TransOrFin
    Subj_FToBe_Not_V3_TransOrFin
    Subj_FToBe_Not_Being_Trans
    Subj_FToBe_Not_Condition_Trans
*/

    public class ATNSubjFToBeNotTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeNotTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeNotTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotTransNode_v2 sameNode, InitATNSubjFToBeNotTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Not_Trans;

        public ATNSubjFToBeTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeNotTransNode_v2 mSameNode;
        private InitATNSubjFToBeNotTransNodeAction mInitAction;

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

