using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjFToHaveBeenVingTransOrFinNodeAction(ATNConditionWillSubjFToHaveBeenVingTransOrFinNode_v2 item);

    public class ATNConditionWillSubjFToHaveBeenVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjFToHaveBeenVingTransOrFinNodeFactory_v2(ATNConditionWillSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjFToHaveBeenVingTransOrFinNodeFactory_v2(ATNConditionWillSubjFToHaveBeenVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjFToHaveBeenVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjFToHaveBeenTransNode_v2 mParentNode;
        private ATNConditionWillSubjFToHaveBeenVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjFToHaveBeenVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjFToHaveBeenVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjFToHaveBeenVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_FToHave_Been_Ving_Obj_TransOrFin
    Condition_Will_Subj_FToHave_Been_Ving_No_Trans
    Condition_Will_Subj_FToHave_Been_Ving_Condition_Fin
*/

    public class ATNConditionWillSubjFToHaveBeenVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjFToHaveBeenVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjFToHaveBeenVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveBeenVingTransOrFinNode_v2 sameNode, InitATNConditionWillSubjFToHaveBeenVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_FToHave_Been_Ving_TransOrFin;

        public ATNConditionWillSubjFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjFToHaveBeenVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionWillSubjFToHaveBeenVingTransOrFinNodeAction mInitAction;

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

