using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjConditionVerbNoObjTransOrFinNodeAction(ATNConditionQWSubjConditionVerbNoObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjConditionVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjConditionVerbNoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjConditionVerbNoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjConditionVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjConditionVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjConditionVerbNoTransNode_v2 mParentNode;
        private ATNConditionQWSubjConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjConditionVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjConditionVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjConditionVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Condition_Verb_No_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjConditionVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjConditionVerbNoObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjConditionVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Condition_Verb_No_Obj_TransOrFin;

        public ATNConditionQWSubjConditionVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjConditionVerbNoObjTransOrFinNodeAction mInitAction;

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

