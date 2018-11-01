using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotFToHaveTransNodeAction(ATNSubjWillNotFToHaveTransNode_v2 item);

    public class ATNSubjWillNotFToHaveTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotFToHaveTransNodeFactory_v2(ATNSubjWillNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotFToHaveTransNodeFactory_v2(ATNSubjWillNotFToHaveTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotFToHaveTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotTransNode_v2 mParentNode;
        private ATNSubjWillNotFToHaveTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotFToHaveTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotFToHaveTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotFToHaveTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Not_FToHave_V3_TransOrFin
    Subj_Will_Not_FToHave_Been_Trans
    Subj_Will_Not_FToHave_Condition_Trans
*/

    public class ATNSubjWillNotFToHaveTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotFToHaveTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotFToHaveTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveTransNode_v2 sameNode, InitATNSubjWillNotFToHaveTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_FToHave_Trans;

        public ATNSubjWillNotTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotFToHaveTransNode_v2 mSameNode;
        private InitATNSubjWillNotFToHaveTransNodeAction mInitAction;

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

