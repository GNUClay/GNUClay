using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToDoNotVerbTransOrFinNodeAction(ATNConditionFToDoNotVerbTransOrFinNode_v2 item);

    public class ATNConditionFToDoNotVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToDoNotVerbTransOrFinNodeFactory_v2(ATNConditionFToDoNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToDoNotVerbTransOrFinNodeFactory_v2(ATNConditionFToDoNotVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToDoNotVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToDoNotTransNode_v2 mParentNode;
        private ATNConditionFToDoNotVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToDoNotVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToDoNotVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToDoNotVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToDo_Not_Verb_Obj_TransOrFin
    Condition_FToDo_Not_Verb_Condition_Fin
*/

    public class ATNConditionFToDoNotVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToDoNotVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToDoNotVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoNotVerbTransOrFinNode_v2 sameNode, InitATNConditionFToDoNotVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToDo_Not_Verb_TransOrFin;

        public ATNConditionFToDoNotTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToDoNotVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionFToDoNotVerbTransOrFinNodeAction mInitAction;

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

