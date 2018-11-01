using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbSubjVerbNoObjTransOrFinNodeAction(ATNConditionModalVerbSubjVerbNoObjTransOrFinNode_v2 item);

    public class ATNConditionModalVerbSubjVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbSubjVerbNoObjTransOrFinNodeFactory_v2(ATNConditionModalVerbSubjVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbSubjVerbNoObjTransOrFinNodeFactory_v2(ATNConditionModalVerbSubjVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbSubjVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbSubjVerbNoTransNode_v2 mParentNode;
        private ATNConditionModalVerbSubjVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbSubjVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbSubjVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbSubjVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_ModalVerb_Subj_Verb_No_Obj_Condition_Fin
*/

    public class ATNConditionModalVerbSubjVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbSubjVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbSubjVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjVerbNoObjTransOrFinNode_v2 sameNode, InitATNConditionModalVerbSubjVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_Subj_Verb_No_Obj_TransOrFin;

        public ATNConditionModalVerbSubjVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbSubjVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionModalVerbSubjVerbNoObjTransOrFinNodeAction mInitAction;

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

