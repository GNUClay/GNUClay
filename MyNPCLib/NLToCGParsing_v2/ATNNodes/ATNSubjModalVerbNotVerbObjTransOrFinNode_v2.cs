using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjModalVerbNotVerbObjTransOrFinNodeAction(ATNSubjModalVerbNotVerbObjTransOrFinNode_v2 item);

    public class ATNSubjModalVerbNotVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjModalVerbNotVerbObjTransOrFinNodeFactory_v2(ATNSubjModalVerbNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjModalVerbNotVerbObjTransOrFinNodeFactory_v2(ATNSubjModalVerbNotVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjModalVerbNotVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjModalVerbNotVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjModalVerbNotVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjModalVerbNotVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjModalVerbNotVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjModalVerbNotVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_ModalVerb_Not_Verb_Obj_Condition_Fin
*/

    public class ATNSubjModalVerbNotVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjModalVerbNotVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjModalVerbNotVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbNotVerbObjTransOrFinNode_v2 sameNode, InitATNSubjModalVerbNotVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_ModalVerb_Not_Verb_Obj_TransOrFin;

        public ATNSubjModalVerbNotVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjModalVerbNotVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjModalVerbNotVerbObjTransOrFinNodeAction mInitAction;

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

