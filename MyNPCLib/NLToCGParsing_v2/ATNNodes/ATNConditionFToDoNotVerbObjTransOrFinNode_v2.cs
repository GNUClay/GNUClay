using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToDoNotVerbObjTransOrFinNodeAction(ATNConditionFToDoNotVerbObjTransOrFinNode_v2 item);

    public class ATNConditionFToDoNotVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToDoNotVerbObjTransOrFinNodeFactory_v2(ATNConditionFToDoNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToDoNotVerbObjTransOrFinNodeFactory_v2(ATNConditionFToDoNotVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToDoNotVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToDoNotVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionFToDoNotVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToDoNotVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToDoNotVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToDoNotVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToDo_Not_Verb_Obj_Condition_Fin
*/

    public class ATNConditionFToDoNotVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToDoNotVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToDoNotVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoNotVerbObjTransOrFinNode_v2 sameNode, InitATNConditionFToDoNotVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToDo_Not_Verb_Obj_TransOrFin;

        public ATNConditionFToDoNotVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToDoNotVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionFToDoNotVerbObjTransOrFinNodeAction mInitAction;

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

