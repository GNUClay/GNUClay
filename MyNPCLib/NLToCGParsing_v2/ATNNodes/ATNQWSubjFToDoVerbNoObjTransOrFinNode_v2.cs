using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToDoVerbNoObjTransOrFinNodeAction(ATNQWSubjFToDoVerbNoObjTransOrFinNode_v2 item);

    public class ATNQWSubjFToDoVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToDoVerbNoObjTransOrFinNodeFactory_v2(ATNQWSubjFToDoVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToDoVerbNoObjTransOrFinNodeFactory_v2(ATNQWSubjFToDoVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToDoVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToDoVerbNoTransNode_v2 mParentNode;
        private ATNQWSubjFToDoVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToDoVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToDoVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToDoVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToDo_Verb_No_Obj_Condition_Fin
*/

    public class ATNQWSubjFToDoVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToDoVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToDoVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoVerbNoObjTransOrFinNode_v2 sameNode, InitATNQWSubjFToDoVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToDo_Verb_No_Obj_TransOrFin;

        public ATNQWSubjFToDoVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToDoVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjFToDoVerbNoObjTransOrFinNodeAction mInitAction;

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

