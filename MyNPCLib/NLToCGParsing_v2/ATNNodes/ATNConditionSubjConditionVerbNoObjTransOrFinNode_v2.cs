using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjConditionVerbNoObjTransOrFinNodeAction(ATNConditionSubjConditionVerbNoObjTransOrFinNode_v2 item);

    public class ATNConditionSubjConditionVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjConditionVerbNoObjTransOrFinNodeFactory_v2(ATNConditionSubjConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjConditionVerbNoObjTransOrFinNodeFactory_v2(ATNConditionSubjConditionVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjConditionVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjConditionVerbNoTransNode_v2 mParentNode;
        private ATNConditionSubjConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjConditionVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjConditionVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjConditionVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Condition_Verb_No_Obj_Condition_Fin
*/

    public class ATNConditionSubjConditionVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjConditionVerbNoObjTransOrFinNode_v2 sameNode, InitATNConditionSubjConditionVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Condition_Verb_No_Obj_TransOrFin;

        public ATNConditionSubjConditionVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjConditionVerbNoObjTransOrFinNodeAction mInitAction;

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

