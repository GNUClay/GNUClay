using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveNotBeenVingTransOrFinNodeAction(ATNSubjFToHaveNotBeenVingTransOrFinNode_v2 item);

    public class ATNSubjFToHaveNotBeenVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveNotBeenVingTransOrFinNodeFactory_v2(ATNSubjFToHaveNotBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveNotBeenVingTransOrFinNodeFactory_v2(ATNSubjFToHaveNotBeenVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveNotBeenVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveNotBeenTransNode_v2 mParentNode;
        private ATNSubjFToHaveNotBeenVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveNotBeenVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveNotBeenVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveNotBeenVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToHave_Not_Been_Ving_Obj_TransOrFin
    Subj_FToHave_Not_Been_Ving_Condition_Fin
*/

    public class ATNSubjFToHaveNotBeenVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveNotBeenVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveNotBeenVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotBeenVingTransOrFinNode_v2 sameNode, InitATNSubjFToHaveNotBeenVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Not_Been_Ving_TransOrFin;

        public ATNSubjFToHaveNotBeenTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveNotBeenVingTransOrFinNode_v2 mSameNode;
        private InitATNSubjFToHaveNotBeenVingTransOrFinNodeAction mInitAction;

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

