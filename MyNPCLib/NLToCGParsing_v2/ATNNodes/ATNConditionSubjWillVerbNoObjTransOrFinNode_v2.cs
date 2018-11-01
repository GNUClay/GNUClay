using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillVerbNoObjTransOrFinNodeAction(ATNConditionSubjWillVerbNoObjTransOrFinNode_v2 item);

    public class ATNConditionSubjWillVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillVerbNoObjTransOrFinNodeFactory_v2(ATNConditionSubjWillVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillVerbNoObjTransOrFinNodeFactory_v2(ATNConditionSubjWillVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillVerbNoTransNode_v2 mParentNode;
        private ATNConditionSubjWillVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Verb_No_Obj_Condition_Fin
*/

    public class ATNConditionSubjWillVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillVerbNoObjTransOrFinNode_v2 sameNode, InitATNConditionSubjWillVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Verb_No_Obj_TransOrFin;

        public ATNConditionSubjWillVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillVerbNoObjTransOrFinNodeAction mInitAction;

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

