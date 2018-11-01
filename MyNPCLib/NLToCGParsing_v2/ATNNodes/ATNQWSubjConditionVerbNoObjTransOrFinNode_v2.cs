using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjConditionVerbNoObjTransOrFinNodeAction(ATNQWSubjConditionVerbNoObjTransOrFinNode_v2 item);

    public class ATNQWSubjConditionVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjConditionVerbNoObjTransOrFinNodeFactory_v2(ATNQWSubjConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjConditionVerbNoObjTransOrFinNodeFactory_v2(ATNQWSubjConditionVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjConditionVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjConditionVerbNoTransNode_v2 mParentNode;
        private ATNQWSubjConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjConditionVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjConditionVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjConditionVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Condition_Verb_No_Obj_Condition_Fin
*/

    public class ATNQWSubjConditionVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjConditionVerbNoObjTransOrFinNode_v2 sameNode, InitATNQWSubjConditionVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Condition_Verb_No_Obj_TransOrFin;

        public ATNQWSubjConditionVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjConditionVerbNoObjTransOrFinNodeAction mInitAction;

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

