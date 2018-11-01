using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjModalVerbVerbObjTransOrFinNodeAction(ATNQWSubjModalVerbVerbObjTransOrFinNode_v2 item);

    public class ATNQWSubjModalVerbVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjModalVerbVerbObjTransOrFinNodeFactory_v2(ATNQWSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjModalVerbVerbObjTransOrFinNodeFactory_v2(ATNQWSubjModalVerbVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjModalVerbVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjModalVerbVerbTransOrFinNode_v2 mParentNode;
        private ATNQWSubjModalVerbVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjModalVerbVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjModalVerbVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjModalVerbVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_ModalVerb_Verb_Obj_Condition_Fin
*/

    public class ATNQWSubjModalVerbVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjModalVerbVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjModalVerbVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjModalVerbVerbObjTransOrFinNode_v2 sameNode, InitATNQWSubjModalVerbVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_ModalVerb_Verb_Obj_TransOrFin;

        public ATNQWSubjModalVerbVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjModalVerbVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjModalVerbVerbObjTransOrFinNodeAction mInitAction;

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

