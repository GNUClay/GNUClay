using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjVerbTransOrFinNodeAction(ATNWillSubjVerbTransOrFinNode_v2 item);

    public class ATNWillSubjVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjVerbTransOrFinNodeFactory_v2(ATNWillSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjVerbTransOrFinNodeFactory_v2(ATNWillSubjVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjTransNode_v2 mParentNode;
        private ATNWillSubjVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_Verb_Obj_TransOrFin
    Will_Subj_Verb_No_Trans
    Will_Subj_Verb_Condition_Fin
*/

    public class ATNWillSubjVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjVerbTransOrFinNode_v2 sameNode, InitATNWillSubjVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Verb_TransOrFin;

        public ATNWillSubjTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjVerbTransOrFinNode_v2 mSameNode;
        private InitATNWillSubjVerbTransOrFinNodeAction mInitAction;

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

