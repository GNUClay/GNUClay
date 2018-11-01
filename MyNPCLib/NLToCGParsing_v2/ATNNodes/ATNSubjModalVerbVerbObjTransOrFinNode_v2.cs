using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjModalVerbVerbObjTransOrFinNodeAction(ATNSubjModalVerbVerbObjTransOrFinNode_v2 item);

    public class ATNSubjModalVerbVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjModalVerbVerbObjTransOrFinNodeFactory_v2(ATNSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjModalVerbVerbObjTransOrFinNodeFactory_v2(ATNSubjModalVerbVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjModalVerbVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjModalVerbVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjModalVerbVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjModalVerbVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjModalVerbVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjModalVerbVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_ModalVerb_Verb_Obj_Condition_Fin
*/

    public class ATNSubjModalVerbVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjModalVerbVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjModalVerbVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbVerbObjTransOrFinNode_v2 sameNode, InitATNSubjModalVerbVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_ModalVerb_Verb_Obj_TransOrFin;

        public ATNSubjModalVerbVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjModalVerbVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjModalVerbVerbObjTransOrFinNodeAction mInitAction;

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

