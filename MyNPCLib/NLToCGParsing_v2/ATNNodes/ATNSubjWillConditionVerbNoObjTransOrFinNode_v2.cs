using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillConditionVerbNoObjTransOrFinNodeAction(ATNSubjWillConditionVerbNoObjTransOrFinNode_v2 item);

    public class ATNSubjWillConditionVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillConditionVerbNoObjTransOrFinNodeFactory_v2(ATNSubjWillConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillConditionVerbNoObjTransOrFinNodeFactory_v2(ATNSubjWillConditionVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillConditionVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillConditionVerbNoTransNode_v2 mParentNode;
        private ATNSubjWillConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillConditionVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillConditionVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillConditionVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Condition_Verb_No_Obj_Condition_Fin
*/

    public class ATNSubjWillConditionVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillConditionVerbNoObjTransOrFinNode_v2 sameNode, InitATNSubjWillConditionVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Condition_Verb_No_Obj_TransOrFin;

        public ATNSubjWillConditionVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillConditionVerbNoObjTransOrFinNodeAction mInitAction;

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

