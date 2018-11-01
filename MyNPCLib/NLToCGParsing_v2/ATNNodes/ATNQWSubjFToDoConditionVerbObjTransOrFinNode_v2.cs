using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToDoConditionVerbObjTransOrFinNodeAction(ATNQWSubjFToDoConditionVerbObjTransOrFinNode_v2 item);

    public class ATNQWSubjFToDoConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToDoConditionVerbObjTransOrFinNodeFactory_v2(ATNQWSubjFToDoConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToDoConditionVerbObjTransOrFinNodeFactory_v2(ATNQWSubjFToDoConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToDoConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToDoConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToDoConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToDoConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToDoConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToDoConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToDo_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNQWSubjFToDoConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToDoConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToDoConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoConditionVerbObjTransOrFinNode_v2 sameNode, InitATNQWSubjFToDoConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToDo_Condition_Verb_Obj_TransOrFin;

        public ATNQWSubjFToDoConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToDoConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjFToDoConditionVerbObjTransOrFinNodeAction mInitAction;

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

