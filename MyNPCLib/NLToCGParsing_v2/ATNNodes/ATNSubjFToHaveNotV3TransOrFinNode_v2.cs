using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveNotV3TransOrFinNodeAction(ATNSubjFToHaveNotV3TransOrFinNode_v2 item);

    public class ATNSubjFToHaveNotV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveNotV3TransOrFinNodeFactory_v2(ATNSubjFToHaveNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveNotV3TransOrFinNodeFactory_v2(ATNSubjFToHaveNotV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveNotV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveNotTransNode_v2 mParentNode;
        private ATNSubjFToHaveNotV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveNotV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveNotV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveNotV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToHave_Not_V3_Obj_TransOrFin
    Subj_FToHave_Not_V3_Condition_Fin
*/

    public class ATNSubjFToHaveNotV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveNotV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveNotV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotV3TransOrFinNode_v2 sameNode, InitATNSubjFToHaveNotV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Not_V3_TransOrFin;

        public ATNSubjFToHaveNotTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveNotV3TransOrFinNode_v2 mSameNode;
        private InitATNSubjFToHaveNotV3TransOrFinNodeAction mInitAction;

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

