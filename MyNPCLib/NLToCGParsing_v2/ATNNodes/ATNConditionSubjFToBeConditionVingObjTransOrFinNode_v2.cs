using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeConditionVingObjTransOrFinNodeAction(ATNConditionSubjFToBeConditionVingObjTransOrFinNode_v2 item);

    public class ATNConditionSubjFToBeConditionVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeConditionVingObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeConditionVingObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeConditionVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeConditionVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeConditionVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeConditionVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeConditionVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeConditionVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Condition_Ving_Obj_Condition_Fin
*/

    public class ATNConditionSubjFToBeConditionVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeConditionVingObjTransOrFinNode_v2 sameNode, InitATNConditionSubjFToBeConditionVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Condition_Ving_Obj_TransOrFin;

        public ATNConditionSubjFToBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeConditionVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeConditionVingObjTransOrFinNodeAction mInitAction;

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

