using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillFToHaveBeenVingTransOrFinNodeAction(ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2 item);

    public class ATNConditionSubjWillFToHaveBeenVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillFToHaveBeenVingTransOrFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillFToHaveBeenVingTransOrFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillFToHaveBeenVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillFToHaveBeenTransNode_v2 mParentNode;
        private ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillFToHaveBeenVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_FToHave_Been_Ving_Obj_TransOrFin
    Condition_Subj_Will_FToHave_Been_Ving_No_Trans
    Condition_Subj_Will_FToHave_Been_Ving_Condition_Fin
*/

    public class ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2 sameNode, InitATNConditionSubjWillFToHaveBeenVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_FToHave_Been_Ving_TransOrFin;

        public ATNConditionSubjWillFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillFToHaveBeenVingTransOrFinNodeAction mInitAction;

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

