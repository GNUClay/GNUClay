using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjFToHaveTransNodeAction(ATNWillSubjFToHaveTransNode_v2 item);

    public class ATNWillSubjFToHaveTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjFToHaveTransNodeFactory_v2(ATNWillSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjFToHaveTransNodeFactory_v2(ATNWillSubjFToHaveTransNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjFToHaveTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjTransNode_v2 mParentNode;
        private ATNWillSubjFToHaveTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjFToHaveTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjFToHaveTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjFToHaveTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_FToHave_V3_TransOrFin
    Will_Subj_FToHave_Been_Trans
    Will_Subj_FToHave_Condition_Trans
*/

    public class ATNWillSubjFToHaveTransNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjFToHaveTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjFToHaveTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveTransNode_v2 sameNode, InitATNWillSubjFToHaveTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_FToHave_Trans;

        public ATNWillSubjTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjFToHaveTransNode_v2 mSameNode;
        private InitATNWillSubjFToHaveTransNodeAction mInitAction;

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

