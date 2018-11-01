using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotFToHaveBeenTransNodeAction(ATNConditionSubjWillNotFToHaveBeenTransNode_v2 item);

    public class ATNConditionSubjWillNotFToHaveBeenTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotFToHaveBeenTransNodeFactory_v2(ATNConditionSubjWillNotFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotFToHaveBeenTransNodeFactory_v2(ATNConditionSubjWillNotFToHaveBeenTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotFToHaveBeenTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotFToHaveTransNode_v2 mParentNode;
        private ATNConditionSubjWillNotFToHaveBeenTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotFToHaveBeenTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotFToHaveBeenTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotFToHaveBeenTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Not_FToHave_Been_Ving_TransOrFin
    Condition_Subj_Will_Not_FToHave_Been_V3_TransOrFin
    Condition_Subj_Will_Not_FToHave_Been_Condition_Trans
*/

    public class ATNConditionSubjWillNotFToHaveBeenTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotFToHaveBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotFToHaveBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveBeenTransNode_v2 sameNode, InitATNConditionSubjWillNotFToHaveBeenTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_FToHave_Been_Trans;

        public ATNConditionSubjWillNotFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotFToHaveBeenTransNode_v2 mSameNode;
        private InitATNConditionSubjWillNotFToHaveBeenTransNodeAction mInitAction;

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

