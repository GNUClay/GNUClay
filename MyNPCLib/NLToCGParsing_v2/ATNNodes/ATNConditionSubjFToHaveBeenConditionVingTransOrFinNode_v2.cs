using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveBeenConditionVingTransOrFinNodeAction(ATNConditionSubjFToHaveBeenConditionVingTransOrFinNode_v2 item);

    public class ATNConditionSubjFToHaveBeenConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveBeenConditionVingTransOrFinNodeFactory_v2(ATNConditionSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveBeenConditionVingTransOrFinNodeFactory_v2(ATNConditionSubjFToHaveBeenConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveBeenConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveBeenConditionTransNode_v2 mParentNode;
        private ATNConditionSubjFToHaveBeenConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveBeenConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveBeenConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveBeenConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToHave_Been_Condition_Ving_Obj_TransOrFin
    Condition_Subj_FToHave_Been_Condition_Ving_No_Trans
    Condition_Subj_FToHave_Been_Condition_Ving_Condition_Fin
*/

    public class ATNConditionSubjFToHaveBeenConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveBeenConditionVingTransOrFinNode_v2 sameNode, InitATNConditionSubjFToHaveBeenConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Been_Condition_Ving_TransOrFin;

        public ATNConditionSubjFToHaveBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveBeenConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveBeenConditionVingTransOrFinNodeAction mInitAction;

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

