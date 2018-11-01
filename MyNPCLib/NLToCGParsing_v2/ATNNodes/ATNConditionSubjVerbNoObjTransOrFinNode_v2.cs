using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjVerbNoObjTransOrFinNodeAction(ATNConditionSubjVerbNoObjTransOrFinNode_v2 item);

    public class ATNConditionSubjVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjVerbNoObjTransOrFinNodeFactory_v2(ATNConditionSubjVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjVerbNoObjTransOrFinNodeFactory_v2(ATNConditionSubjVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjVerbNoTransNode_v2 mParentNode;
        private ATNConditionSubjVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Verb_No_Obj_Condition_Fin
*/

    public class ATNConditionSubjVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjVerbNoObjTransOrFinNode_v2 sameNode, InitATNConditionSubjVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Verb_No_Obj_TransOrFin;

        public ATNConditionSubjVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjVerbNoObjTransOrFinNodeAction mInitAction;

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

