using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToDoNotConditionVerbObjTransOrFinNodeAction(ATNConditionSubjFToDoNotConditionVerbObjTransOrFinNode_v2 item);

    public class ATNConditionSubjFToDoNotConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToDoNotConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToDoNotConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionSubjFToDoNotConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToDoNotConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToDoNotConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToDoNotConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToDoNotConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToDoNotConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToDo_Not_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNConditionSubjFToDoNotConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToDoNotConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToDoNotConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToDoNotConditionVerbObjTransOrFinNode_v2 sameNode, InitATNConditionSubjFToDoNotConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToDo_Not_Condition_Verb_Obj_TransOrFin;

        public ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToDoNotConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToDoNotConditionVerbObjTransOrFinNodeAction mInitAction;

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

