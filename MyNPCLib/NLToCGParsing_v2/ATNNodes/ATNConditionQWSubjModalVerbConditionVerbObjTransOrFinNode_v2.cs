using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNodeAction(ATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_ModalVerb_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_ModalVerb_Condition_Verb_Obj_TransOrFin;

        public ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNodeAction mInitAction;

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

