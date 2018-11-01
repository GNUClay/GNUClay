using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNodeAction(ATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjModalVerbConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjModalVerbConditionVerbNoTransNode_v2 mParentNode;
        private ATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_ModalVerb_Condition_Verb_No_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_ModalVerb_Condition_Verb_No_Obj_TransOrFin;

        public ATNConditionQWSubjModalVerbConditionVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNodeAction mInitAction;

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

