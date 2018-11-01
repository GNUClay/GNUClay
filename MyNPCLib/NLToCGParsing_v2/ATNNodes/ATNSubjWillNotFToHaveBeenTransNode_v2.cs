using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotFToHaveBeenTransNodeAction(ATNSubjWillNotFToHaveBeenTransNode_v2 item);

    public class ATNSubjWillNotFToHaveBeenTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotFToHaveBeenTransNodeFactory_v2(ATNSubjWillNotFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotFToHaveBeenTransNodeFactory_v2(ATNSubjWillNotFToHaveBeenTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotFToHaveBeenTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotFToHaveTransNode_v2 mParentNode;
        private ATNSubjWillNotFToHaveBeenTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotFToHaveBeenTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotFToHaveBeenTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotFToHaveBeenTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Not_FToHave_Been_Ving_TransOrFin
    Subj_Will_Not_FToHave_Been_V3_TransOrFin
    Subj_Will_Not_FToHave_Been_Condition_Trans
*/

    public class ATNSubjWillNotFToHaveBeenTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotFToHaveBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotFToHaveBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveBeenTransNode_v2 sameNode, InitATNSubjWillNotFToHaveBeenTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_FToHave_Been_Trans;

        public ATNSubjWillNotFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotFToHaveBeenTransNode_v2 mSameNode;
        private InitATNSubjWillNotFToHaveBeenTransNodeAction mInitAction;

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

