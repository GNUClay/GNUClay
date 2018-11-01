using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillFToHaveBeenVingNoTransNodeAction(ATNSubjWillFToHaveBeenVingNoTransNode_v2 item);

    public class ATNSubjWillFToHaveBeenVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillFToHaveBeenVingNoTransNodeFactory_v2(ATNSubjWillFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillFToHaveBeenVingNoTransNodeFactory_v2(ATNSubjWillFToHaveBeenVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillFToHaveBeenVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillFToHaveBeenVingTransOrFinNode_v2 mParentNode;
        private ATNSubjWillFToHaveBeenVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillFToHaveBeenVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillFToHaveBeenVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillFToHaveBeenVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_FToHave_Been_Ving_No_Obj_TransOrFin
*/

    public class ATNSubjWillFToHaveBeenVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillFToHaveBeenVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillFToHaveBeenVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenVingNoTransNode_v2 sameNode, InitATNSubjWillFToHaveBeenVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_FToHave_Been_Ving_No_Trans;

        public ATNSubjWillFToHaveBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillFToHaveBeenVingNoTransNode_v2 mSameNode;
        private InitATNSubjWillFToHaveBeenVingNoTransNodeAction mInitAction;

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

