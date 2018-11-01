using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeNotConditionVingObjTransOrFinNodeAction(ATNConditionSubjFToBeNotConditionVingObjTransOrFinNode_v2 item);

    public class ATNConditionSubjFToBeNotConditionVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeNotConditionVingObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeNotConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeNotConditionVingObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeNotConditionVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeNotConditionVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeNotConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeNotConditionVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeNotConditionVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeNotConditionVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeNotConditionVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Not_Condition_Ving_Obj_Condition_Fin
*/

    public class ATNConditionSubjFToBeNotConditionVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeNotConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeNotConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotConditionVingObjTransOrFinNode_v2 sameNode, InitATNConditionSubjFToBeNotConditionVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Not_Condition_Ving_Obj_TransOrFin;

        public ATNConditionSubjFToBeNotConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeNotConditionVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeNotConditionVingObjTransOrFinNodeAction mInitAction;

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

