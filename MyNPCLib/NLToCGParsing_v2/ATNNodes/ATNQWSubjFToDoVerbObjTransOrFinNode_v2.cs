using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToDoVerbObjTransOrFinNodeAction(ATNQWSubjFToDoVerbObjTransOrFinNode_v2 item);

    public class ATNQWSubjFToDoVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToDoVerbObjTransOrFinNodeFactory_v2(ATNQWSubjFToDoVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToDoVerbObjTransOrFinNodeFactory_v2(ATNQWSubjFToDoVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToDoVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToDoVerbTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToDoVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToDoVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToDoVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToDoVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToDo_Verb_Obj_Condition_Fin
*/

    public class ATNQWSubjFToDoVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToDoVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToDoVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoVerbObjTransOrFinNode_v2 sameNode, InitATNQWSubjFToDoVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToDo_Verb_Obj_TransOrFin;

        public ATNQWSubjFToDoVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToDoVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjFToDoVerbObjTransOrFinNodeAction mInitAction;

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

