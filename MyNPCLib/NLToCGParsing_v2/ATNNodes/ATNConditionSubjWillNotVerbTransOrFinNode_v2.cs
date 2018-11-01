using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotVerbTransOrFinNodeAction(ATNConditionSubjWillNotVerbTransOrFinNode_v2 item);

    public class ATNConditionSubjWillNotVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotVerbTransOrFinNodeFactory_v2(ATNConditionSubjWillNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotVerbTransOrFinNodeFactory_v2(ATNConditionSubjWillNotVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotTransNode_v2 mParentNode;
        private ATNConditionSubjWillNotVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Not_Verb_Obj_TransOrFin
    Condition_Subj_Will_Not_Verb_Condition_Fin
*/

    public class ATNConditionSubjWillNotVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotVerbTransOrFinNode_v2 sameNode, InitATNConditionSubjWillNotVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_Verb_TransOrFin;

        public ATNConditionSubjWillNotTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotVerbTransOrFinNodeAction mInitAction;

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

