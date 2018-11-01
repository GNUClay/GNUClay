using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjVerbNoObjTransOrFinNodeAction(ATNConditionWillSubjVerbNoObjTransOrFinNode_v2 item);

    public class ATNConditionWillSubjVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjVerbNoObjTransOrFinNodeFactory_v2(ATNConditionWillSubjVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjVerbNoObjTransOrFinNodeFactory_v2(ATNConditionWillSubjVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjVerbNoTransNode_v2 mParentNode;
        private ATNConditionWillSubjVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_Verb_No_Obj_Condition_Fin
*/

    public class ATNConditionWillSubjVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjVerbNoObjTransOrFinNode_v2 sameNode, InitATNConditionWillSubjVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Verb_No_Obj_TransOrFin;

        public ATNConditionWillSubjVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionWillSubjVerbNoObjTransOrFinNodeAction mInitAction;

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

