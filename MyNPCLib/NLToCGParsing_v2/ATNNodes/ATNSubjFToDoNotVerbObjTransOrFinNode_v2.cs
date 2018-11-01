using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToDoNotVerbObjTransOrFinNodeAction(ATNSubjFToDoNotVerbObjTransOrFinNode_v2 item);

    public class ATNSubjFToDoNotVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToDoNotVerbObjTransOrFinNodeFactory_v2(ATNSubjFToDoNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToDoNotVerbObjTransOrFinNodeFactory_v2(ATNSubjFToDoNotVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToDoNotVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToDoNotVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjFToDoNotVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToDoNotVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToDoNotVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToDoNotVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToDo_Not_Verb_Obj_Condition_Fin
*/

    public class ATNSubjFToDoNotVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToDoNotVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToDoNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToDoNotVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToDoNotVerbObjTransOrFinNode_v2 sameNode, InitATNSubjFToDoNotVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToDo_Not_Verb_Obj_TransOrFin;

        public ATNSubjFToDoNotVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToDoNotVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjFToDoNotVerbObjTransOrFinNodeAction mInitAction;

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

