using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjVerbNoTransNodeAction(ATNWillSubjVerbNoTransNode_v2 item);

    public class ATNWillSubjVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjVerbNoTransNodeFactory_v2(ATNWillSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjVerbNoTransNodeFactory_v2(ATNWillSubjVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNWillSubjVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_Verb_No_Obj_TransOrFin
*/

    public class ATNWillSubjVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjVerbNoTransNode_v2 sameNode, InitATNWillSubjVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Verb_No_Trans;

        public ATNWillSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjVerbNoTransNode_v2 mSameNode;
        private InitATNWillSubjVerbNoTransNodeAction mInitAction;

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

