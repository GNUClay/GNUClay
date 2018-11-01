using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbVerbNoObjTransOrFinNodeAction(ATNConditionSubjModalVerbVerbNoObjTransOrFinNode_v2 item);

    public class ATNConditionSubjModalVerbVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbVerbNoObjTransOrFinNodeFactory_v2(ATNConditionSubjModalVerbVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbVerbNoObjTransOrFinNodeFactory_v2(ATNConditionSubjModalVerbVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbVerbNoTransNode_v2 mParentNode;
        private ATNConditionSubjModalVerbVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_ModalVerb_Verb_No_Obj_Condition_Fin
*/

    public class ATNConditionSubjModalVerbVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbVerbNoObjTransOrFinNode_v2 sameNode, InitATNConditionSubjModalVerbVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Verb_No_Obj_TransOrFin;

        public ATNConditionSubjModalVerbVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbVerbNoObjTransOrFinNodeAction mInitAction;

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

