using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeNotVingObjTransOrFinNodeAction(ATNConditionSubjFToBeNotVingObjTransOrFinNode_v2 item);

    public class ATNConditionSubjFToBeNotVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeNotVingObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeNotVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeNotVingObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeNotVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeNotVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeNotVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeNotVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeNotVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeNotVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeNotVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Not_Ving_Obj_Condition_Fin
*/

    public class ATNConditionSubjFToBeNotVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeNotVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeNotVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotVingObjTransOrFinNode_v2 sameNode, InitATNConditionSubjFToBeNotVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Not_Ving_Obj_TransOrFin;

        public ATNConditionSubjFToBeNotVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeNotVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeNotVingObjTransOrFinNodeAction mInitAction;

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

