using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillFToHaveTransNodeAction(ATNSubjWillFToHaveTransNode_v2 item);

    public class ATNSubjWillFToHaveTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillFToHaveTransNodeFactory_v2(ATNSubjWillTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillFToHaveTransNodeFactory_v2(ATNSubjWillFToHaveTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillFToHaveTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillTransNode_v2 mParentNode;
        private ATNSubjWillFToHaveTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillFToHaveTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillFToHaveTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillFToHaveTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_FToHave_V3_TransOrFin
    Subj_Will_FToHave_Been_Trans
    Subj_Will_FToHave_Condition_Trans
*/

    public class ATNSubjWillFToHaveTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillFToHaveTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillFToHaveTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveTransNode_v2 sameNode, InitATNSubjWillFToHaveTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_FToHave_Trans;

        public ATNSubjWillTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillFToHaveTransNode_v2 mSameNode;
        private InitATNSubjWillFToHaveTransNodeAction mInitAction;

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

