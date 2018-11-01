using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjConditionVerbNoObjTransOrFinNodeAction(ATNSubjConditionVerbNoObjTransOrFinNode_v2 item);

    public class ATNSubjConditionVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjConditionVerbNoObjTransOrFinNodeFactory_v2(ATNSubjConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjConditionVerbNoObjTransOrFinNodeFactory_v2(ATNSubjConditionVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjConditionVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjConditionVerbNoTransNode_v2 mParentNode;
        private ATNSubjConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjConditionVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjConditionVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjConditionVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Condition_Verb_No_Obj_Condition_Fin
*/

    public class ATNSubjConditionVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjConditionVerbNoObjTransOrFinNode_v2 sameNode, InitATNSubjConditionVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Condition_Verb_No_Obj_TransOrFin;

        public ATNSubjConditionVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNSubjConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjConditionVerbNoObjTransOrFinNodeAction mInitAction;

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

