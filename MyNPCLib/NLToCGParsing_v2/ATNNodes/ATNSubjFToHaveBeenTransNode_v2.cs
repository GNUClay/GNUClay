using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveBeenTransNodeAction(ATNSubjFToHaveBeenTransNode_v2 item);

    public class ATNSubjFToHaveBeenTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveBeenTransNodeFactory_v2(ATNSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveBeenTransNodeFactory_v2(ATNSubjFToHaveBeenTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveBeenTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveTransNode_v2 mParentNode;
        private ATNSubjFToHaveBeenTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveBeenTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveBeenTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveBeenTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToHave_Been_Ving_TransOrFin
    Subj_FToHave_Been_V3_TransOrFin
    Subj_FToHave_Been_Condition_Trans
*/

    public class ATNSubjFToHaveBeenTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenTransNode_v2 sameNode, InitATNSubjFToHaveBeenTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Been_Trans;

        public ATNSubjFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveBeenTransNode_v2 mSameNode;
        private InitATNSubjFToHaveBeenTransNodeAction mInitAction;

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

