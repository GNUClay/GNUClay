using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToDoVerbObjTransOrFinNodeAction(ATNConditionQWSubjFToDoVerbObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjFToDoVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToDoVerbObjTransOrFinNodeFactory_v2(ATNConditionQWSubjFToDoVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToDoVerbObjTransOrFinNodeFactory_v2(ATNConditionQWSubjFToDoVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToDoVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToDoVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToDoVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToDoVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToDoVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToDoVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToDo_Verb_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjFToDoVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToDoVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToDoVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoVerbObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjFToDoVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToDo_Verb_Obj_TransOrFin;

        public ATNConditionQWSubjFToDoVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToDoVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToDoVerbObjTransOrFinNodeAction mInitAction;

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

