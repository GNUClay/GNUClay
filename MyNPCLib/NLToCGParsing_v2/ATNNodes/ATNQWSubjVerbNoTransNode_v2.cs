using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjVerbNoTransNodeAction(ATNQWSubjVerbNoTransNode_v2 item);

    public class ATNQWSubjVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjVerbNoTransNodeFactory_v2(ATNQWSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjVerbNoTransNodeFactory_v2(ATNQWSubjVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNQWSubjVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Verb_No_Obj_TransOrFin
*/

    public class ATNQWSubjVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjVerbNoTransNode_v2 sameNode, InitATNQWSubjVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Verb_No_Trans;

        public ATNQWSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjVerbNoTransNode_v2 mSameNode;
        private InitATNQWSubjVerbNoTransNodeAction mInitAction;

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

