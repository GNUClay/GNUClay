using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotFToHaveBeenConditionTransNodeAction(ATNConditionSubjWillNotFToHaveBeenConditionTransNode_v2 item);

    public class ATNConditionSubjWillNotFToHaveBeenConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotFToHaveBeenConditionTransNodeFactory_v2(ATNConditionSubjWillNotFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotFToHaveBeenConditionTransNodeFactory_v2(ATNConditionSubjWillNotFToHaveBeenConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotFToHaveBeenConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotFToHaveBeenTransNode_v2 mParentNode;
        private ATNConditionSubjWillNotFToHaveBeenConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotFToHaveBeenConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotFToHaveBeenConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotFToHaveBeenConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Not_FToHave_Been_Condition_Ving_TransOrFin
    Condition_Subj_Will_Not_FToHave_Been_Condition_V3_TransOrFin
*/

    public class ATNConditionSubjWillNotFToHaveBeenConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveBeenConditionTransNode_v2 sameNode, InitATNConditionSubjWillNotFToHaveBeenConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_FToHave_Been_Condition_Trans;

        public ATNConditionSubjWillNotFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotFToHaveBeenConditionTransNode_v2 mSameNode;
        private InitATNConditionSubjWillNotFToHaveBeenConditionTransNodeAction mInitAction;

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

