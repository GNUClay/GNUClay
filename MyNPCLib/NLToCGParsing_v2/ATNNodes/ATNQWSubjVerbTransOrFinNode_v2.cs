using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjVerbTransOrFinNodeAction(ATNQWSubjVerbTransOrFinNode_v2 item);

    public class ATNQWSubjVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjVerbTransOrFinNodeFactory_v2(ATNQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjVerbTransOrFinNodeFactory_v2(ATNQWSubjVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjTransNode_v2 mParentNode;
        private ATNQWSubjVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Verb_Obj_TransOrFin
    QWSubj_Verb_No_Trans
    QWSubj_Verb_Condition_Fin
*/

    public class ATNQWSubjVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjVerbTransOrFinNode_v2 sameNode, InitATNQWSubjVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Verb_TransOrFin;

        public ATNQWSubjTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjVerbTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjVerbTransOrFinNodeAction mInitAction;

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

