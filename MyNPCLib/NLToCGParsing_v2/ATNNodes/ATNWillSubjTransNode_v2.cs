using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjTransNodeAction(ATNWillSubjTransNode_v2 item);

    public class ATNWillSubjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjTransNodeFactory_v2(ATNWillTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjTransNodeFactory_v2(ATNWillSubjTransNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillTransNode_v2 mParentNode;
        private ATNWillSubjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_Verb_TransOrFin
    Will_Subj_Be_Trans
    Will_Subj_FToHave_Trans
    Will_Subj_Condition_Trans
*/

    public class ATNWillSubjTransNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNWillTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjTransNode_v2 sameNode, InitATNWillSubjTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Trans;

        public ATNWillTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjTransNode_v2 mSameNode;
        private InitATNWillSubjTransNodeAction mInitAction;

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

