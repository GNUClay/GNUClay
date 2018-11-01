using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveBeenVingNoTransNodeAction(ATNSubjFToHaveBeenVingNoTransNode_v2 item);

    public class ATNSubjFToHaveBeenVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveBeenVingNoTransNodeFactory_v2(ATNSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveBeenVingNoTransNodeFactory_v2(ATNSubjFToHaveBeenVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveBeenVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveBeenVingTransOrFinNode_v2 mParentNode;
        private ATNSubjFToHaveBeenVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveBeenVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveBeenVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveBeenVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToHave_Been_Ving_No_Obj_TransOrFin
*/

    public class ATNSubjFToHaveBeenVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveBeenVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveBeenVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenVingNoTransNode_v2 sameNode, InitATNSubjFToHaveBeenVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Been_Ving_No_Trans;

        public ATNSubjFToHaveBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveBeenVingNoTransNode_v2 mSameNode;
        private InitATNSubjFToHaveBeenVingNoTransNodeAction mInitAction;

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

