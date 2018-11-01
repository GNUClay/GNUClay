using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjConditionVerbNoObjTransOrFinNodeAction(ATNWillSubjConditionVerbNoObjTransOrFinNode_v2 item);

    public class ATNWillSubjConditionVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjConditionVerbNoObjTransOrFinNodeFactory_v2(ATNWillSubjConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjConditionVerbNoObjTransOrFinNodeFactory_v2(ATNWillSubjConditionVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjConditionVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjConditionVerbNoTransNode_v2 mParentNode;
        private ATNWillSubjConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjConditionVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjConditionVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjConditionVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_Condition_Verb_No_Obj_Condition_Fin
*/

    public class ATNWillSubjConditionVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjConditionVerbNoObjTransOrFinNode_v2 sameNode, InitATNWillSubjConditionVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Condition_Verb_No_Obj_TransOrFin;

        public ATNWillSubjConditionVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNWillSubjConditionVerbNoObjTransOrFinNodeAction mInitAction;

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

