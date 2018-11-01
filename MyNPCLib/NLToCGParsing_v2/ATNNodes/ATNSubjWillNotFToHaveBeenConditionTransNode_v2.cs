using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotFToHaveBeenConditionTransNodeAction(ATNSubjWillNotFToHaveBeenConditionTransNode_v2 item);

    public class ATNSubjWillNotFToHaveBeenConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotFToHaveBeenConditionTransNodeFactory_v2(ATNSubjWillNotFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotFToHaveBeenConditionTransNodeFactory_v2(ATNSubjWillNotFToHaveBeenConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotFToHaveBeenConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotFToHaveBeenTransNode_v2 mParentNode;
        private ATNSubjWillNotFToHaveBeenConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotFToHaveBeenConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotFToHaveBeenConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotFToHaveBeenConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Not_FToHave_Been_Condition_Ving_TransOrFin
    Subj_Will_Not_FToHave_Been_Condition_V3_TransOrFin
*/

    public class ATNSubjWillNotFToHaveBeenConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveBeenConditionTransNode_v2 sameNode, InitATNSubjWillNotFToHaveBeenConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_FToHave_Been_Condition_Trans;

        public ATNSubjWillNotFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotFToHaveBeenConditionTransNode_v2 mSameNode;
        private InitATNSubjWillNotFToHaveBeenConditionTransNodeAction mInitAction;

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

