using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoNotConditionVerbObjTransOrFinNodeAction(ATNFToDoNotConditionVerbObjTransOrFinNode_v2 item);

    public class ATNFToDoNotConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoNotConditionVerbObjTransOrFinNodeFactory_v2(ATNFToDoNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoNotConditionVerbObjTransOrFinNodeFactory_v2(ATNFToDoNotConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoNotConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoNotConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNFToDoNotConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoNotConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoNotConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoNotConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToDo_Not_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNFToDoNotConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToDoNotConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoNotConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoNotConditionVerbObjTransOrFinNode_v2 sameNode, InitATNFToDoNotConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Not_Condition_Verb_Obj_TransOrFin;

        public ATNFToDoNotConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToDoNotConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNFToDoNotConditionVerbObjTransOrFinNodeAction mInitAction;

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

