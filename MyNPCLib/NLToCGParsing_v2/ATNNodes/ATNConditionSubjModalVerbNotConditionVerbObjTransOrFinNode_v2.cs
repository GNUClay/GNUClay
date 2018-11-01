using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNodeAction(ATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNode_v2 item);

    public class ATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_ModalVerb_Not_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNode_v2 sameNode, InitATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Not_Condition_Verb_Obj_TransOrFin;

        public ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNodeAction mInitAction;

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

