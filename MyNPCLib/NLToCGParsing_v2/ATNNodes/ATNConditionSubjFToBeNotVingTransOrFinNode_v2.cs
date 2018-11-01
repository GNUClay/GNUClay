using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeNotVingTransOrFinNodeAction(ATNConditionSubjFToBeNotVingTransOrFinNode_v2 item);

    public class ATNConditionSubjFToBeNotVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeNotVingTransOrFinNodeFactory_v2(ATNConditionSubjFToBeNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeNotVingTransOrFinNodeFactory_v2(ATNConditionSubjFToBeNotVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeNotVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeNotTransNode_v2 mParentNode;
        private ATNConditionSubjFToBeNotVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeNotVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeNotVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeNotVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Not_Ving_Obj_TransOrFin
    Condition_Subj_FToBe_Not_Ving_Condition_Fin
*/

    public class ATNConditionSubjFToBeNotVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeNotVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeNotVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotVingTransOrFinNode_v2 sameNode, InitATNConditionSubjFToBeNotVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Not_Ving_TransOrFin;

        public ATNConditionSubjFToBeNotTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeNotVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeNotVingTransOrFinNodeAction mInitAction;

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

