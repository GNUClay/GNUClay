using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotFToHaveBeenV3TransOrFinNodeAction(ATNConditionSubjWillNotFToHaveBeenV3TransOrFinNode_v2 item);

    public class ATNConditionSubjWillNotFToHaveBeenV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotFToHaveBeenV3TransOrFinNodeFactory_v2(ATNConditionSubjWillNotFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotFToHaveBeenV3TransOrFinNodeFactory_v2(ATNConditionSubjWillNotFToHaveBeenV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotFToHaveBeenV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotFToHaveBeenTransNode_v2 mParentNode;
        private ATNConditionSubjWillNotFToHaveBeenV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotFToHaveBeenV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotFToHaveBeenV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotFToHaveBeenV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Not_FToHave_Been_V3_Obj_TransOrFin
    Condition_Subj_Will_Not_FToHave_Been_V3_Condition_Fin
*/

    public class ATNConditionSubjWillNotFToHaveBeenV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotFToHaveBeenV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotFToHaveBeenV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveBeenV3TransOrFinNode_v2 sameNode, InitATNConditionSubjWillNotFToHaveBeenV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_FToHave_Been_V3_TransOrFin;

        public ATNConditionSubjWillNotFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotFToHaveBeenV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotFToHaveBeenV3TransOrFinNodeAction mInitAction;

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

