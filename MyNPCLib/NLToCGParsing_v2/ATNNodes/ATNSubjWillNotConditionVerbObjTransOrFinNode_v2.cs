using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotConditionVerbObjTransOrFinNodeAction(ATNSubjWillNotConditionVerbObjTransOrFinNode_v2 item);

    public class ATNSubjWillNotConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotConditionVerbObjTransOrFinNodeFactory_v2(ATNSubjWillNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotConditionVerbObjTransOrFinNodeFactory_v2(ATNSubjWillNotConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjWillNotConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Not_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNSubjWillNotConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotConditionVerbObjTransOrFinNode_v2 sameNode, InitATNSubjWillNotConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_Condition_Verb_Obj_TransOrFin;

        public ATNSubjWillNotConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillNotConditionVerbObjTransOrFinNodeAction mInitAction;

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

