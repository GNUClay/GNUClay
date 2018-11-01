using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjVerbNoObjTransOrFinNodeAction(ATNConditionQWSubjVerbNoObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjVerbNoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjVerbNoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjVerbNoTransNode_v2 mParentNode;
        private ATNConditionQWSubjVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Verb_No_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjVerbNoObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Verb_No_Obj_TransOrFin;

        public ATNConditionQWSubjVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjVerbNoObjTransOrFinNodeAction mInitAction;

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

