using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotConditionVerbObjTransOrFinNodeAction(ATNConditionSubjWillNotConditionVerbObjTransOrFinNode_v2 item);

    public class ATNConditionSubjWillNotConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionSubjWillNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionSubjWillNotConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillNotConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Not_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNConditionSubjWillNotConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotConditionVerbObjTransOrFinNode_v2 sameNode, InitATNConditionSubjWillNotConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_Condition_Verb_Obj_TransOrFin;

        public ATNConditionSubjWillNotConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotConditionVerbObjTransOrFinNodeAction mInitAction;

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

