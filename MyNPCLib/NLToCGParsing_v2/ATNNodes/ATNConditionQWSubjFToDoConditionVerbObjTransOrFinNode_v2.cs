using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToDoConditionVerbObjTransOrFinNodeAction(ATNConditionQWSubjFToDoConditionVerbObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjFToDoConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToDoConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToDoConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionQWSubjFToDoConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToDoConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToDoConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToDoConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToDoConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToDoConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToDo_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjFToDoConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToDoConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToDoConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoConditionVerbObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjFToDoConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToDo_Condition_Verb_Obj_TransOrFin;

        public ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToDoConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToDoConditionVerbObjTransOrFinNodeAction mInitAction;

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

