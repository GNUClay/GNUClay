using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotVerbObjTransOrFinNodeAction(ATNConditionSubjWillNotVerbObjTransOrFinNode_v2 item);

    public class ATNConditionSubjWillNotVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotVerbObjTransOrFinNodeFactory_v2(ATNConditionSubjWillNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotVerbObjTransOrFinNodeFactory_v2(ATNConditionSubjWillNotVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillNotVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Not_Verb_Obj_Condition_Fin
*/

    public class ATNConditionSubjWillNotVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotVerbObjTransOrFinNode_v2 sameNode, InitATNConditionSubjWillNotVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_Verb_Obj_TransOrFin;

        public ATNConditionSubjWillNotVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotVerbObjTransOrFinNodeAction mInitAction;

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

