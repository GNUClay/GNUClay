using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNodeAction(ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 item);

    public class ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillFToHaveBeenConditionTransNode_v2 mParentNode;
        private ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_FToHave_Been_Condition_Ving_Obj_TransOrFin
    Condition_Subj_Will_FToHave_Been_Condition_Ving_No_Trans
    Condition_Subj_Will_FToHave_Been_Condition_Ving_Condition_Fin
*/

    public class ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 sameNode, InitATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_FToHave_Been_Condition_Ving_TransOrFin;

        public ATNConditionSubjWillFToHaveBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNodeAction mInitAction;

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

