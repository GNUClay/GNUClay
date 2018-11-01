using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotFToHaveBeenVingTransOrFinNodeAction(ATNSubjWillNotFToHaveBeenVingTransOrFinNode_v2 item);

    public class ATNSubjWillNotFToHaveBeenVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotFToHaveBeenVingTransOrFinNodeFactory_v2(ATNSubjWillNotFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotFToHaveBeenVingTransOrFinNodeFactory_v2(ATNSubjWillNotFToHaveBeenVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotFToHaveBeenVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotFToHaveBeenTransNode_v2 mParentNode;
        private ATNSubjWillNotFToHaveBeenVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotFToHaveBeenVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotFToHaveBeenVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotFToHaveBeenVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Not_FToHave_Been_Ving_Obj_TransOrFin
    Subj_Will_Not_FToHave_Been_Ving_Condition_Fin
*/

    public class ATNSubjWillNotFToHaveBeenVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotFToHaveBeenVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotFToHaveBeenVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveBeenVingTransOrFinNode_v2 sameNode, InitATNSubjWillNotFToHaveBeenVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_FToHave_Been_Ving_TransOrFin;

        public ATNSubjWillNotFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotFToHaveBeenVingTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillNotFToHaveBeenVingTransOrFinNodeAction mInitAction;

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

