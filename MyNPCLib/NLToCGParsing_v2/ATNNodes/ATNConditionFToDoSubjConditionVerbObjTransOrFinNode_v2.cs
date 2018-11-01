using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToDoSubjConditionVerbObjTransOrFinNodeAction(ATNConditionFToDoSubjConditionVerbObjTransOrFinNode_v2 item);

    public class ATNConditionFToDoSubjConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToDoSubjConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToDoSubjConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionFToDoSubjConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToDoSubjConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionFToDoSubjConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToDoSubjConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToDoSubjConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToDoSubjConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToDo_Subj_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNConditionFToDoSubjConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToDoSubjConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToDoSubjConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjConditionVerbObjTransOrFinNode_v2 sameNode, InitATNConditionFToDoSubjConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToDo_Subj_Condition_Verb_Obj_TransOrFin;

        public ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToDoSubjConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionFToDoSubjConditionVerbObjTransOrFinNodeAction mInitAction;

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

