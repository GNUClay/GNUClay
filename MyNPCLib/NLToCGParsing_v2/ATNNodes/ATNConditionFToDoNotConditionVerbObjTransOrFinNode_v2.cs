using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToDoNotConditionVerbObjTransOrFinNodeAction(ATNConditionFToDoNotConditionVerbObjTransOrFinNode_v2 item);

    public class ATNConditionFToDoNotConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToDoNotConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionFToDoNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToDoNotConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionFToDoNotConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToDoNotConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToDoNotConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionFToDoNotConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToDoNotConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToDoNotConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToDoNotConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToDo_Not_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNConditionFToDoNotConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToDoNotConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToDoNotConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoNotConditionVerbObjTransOrFinNode_v2 sameNode, InitATNConditionFToDoNotConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToDo_Not_Condition_Verb_Obj_TransOrFin;

        public ATNConditionFToDoNotConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToDoNotConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionFToDoNotConditionVerbObjTransOrFinNodeAction mInitAction;

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

