using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjVerbTransOrFinNodeAction(ATNQWObjWillSubjVerbTransOrFinNode_v2 item);

    public class ATNQWObjWillSubjVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjVerbTransOrFinNodeFactory_v2(ATNQWObjWillSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjVerbTransOrFinNodeFactory_v2(ATNQWObjWillSubjVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjTransNode_v2 mParentNode;
        private ATNQWObjWillSubjVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_Will_Subj_Verb_Condition_Fin
*/

    public class ATNQWObjWillSubjVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjVerbTransOrFinNode_v2 sameNode, InitATNQWObjWillSubjVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_Verb_TransOrFin;

        public ATNQWObjWillSubjTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjVerbTransOrFinNode_v2 mSameNode;
        private InitATNQWObjWillSubjVerbTransOrFinNodeAction mInitAction;

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

