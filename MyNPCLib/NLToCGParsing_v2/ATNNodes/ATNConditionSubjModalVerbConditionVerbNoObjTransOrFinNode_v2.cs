using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNodeAction(ATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 item);

    public class ATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNodeFactory_v2(ATNConditionSubjModalVerbConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNodeFactory_v2(ATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbConditionVerbNoTransNode_v2 mParentNode;
        private ATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_ModalVerb_Condition_Verb_No_Obj_Condition_Fin
*/

    public class ATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 sameNode, InitATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Condition_Verb_No_Obj_TransOrFin;

        public ATNConditionSubjModalVerbConditionVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNodeAction mInitAction;

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

