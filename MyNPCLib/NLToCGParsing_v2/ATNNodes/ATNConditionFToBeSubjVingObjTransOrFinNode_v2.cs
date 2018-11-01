using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjVingObjTransOrFinNodeAction(ATNConditionFToBeSubjVingObjTransOrFinNode_v2 item);

    public class ATNConditionFToBeSubjVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjVingObjTransOrFinNodeFactory_v2(ATNConditionFToBeSubjVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjVingObjTransOrFinNodeFactory_v2(ATNConditionFToBeSubjVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjVingTransOrFinNode_v2 mParentNode;
        private ATNConditionFToBeSubjVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToBe_Subj_Ving_Obj_Condition_Fin
*/

    public class ATNConditionFToBeSubjVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjVingObjTransOrFinNode_v2 sameNode, InitATNConditionFToBeSubjVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Ving_Obj_TransOrFin;

        public ATNConditionFToBeSubjVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjVingObjTransOrFinNodeAction mInitAction;

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

