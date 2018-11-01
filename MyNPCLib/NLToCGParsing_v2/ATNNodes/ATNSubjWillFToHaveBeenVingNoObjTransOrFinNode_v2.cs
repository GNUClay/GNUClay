using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillFToHaveBeenVingNoObjTransOrFinNodeAction(ATNSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 item);

    public class ATNSubjWillFToHaveBeenVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillFToHaveBeenVingNoObjTransOrFinNodeFactory_v2(ATNSubjWillFToHaveBeenVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillFToHaveBeenVingNoObjTransOrFinNodeFactory_v2(ATNSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillFToHaveBeenVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillFToHaveBeenVingNoTransNode_v2 mParentNode;
        private ATNSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillFToHaveBeenVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_FToHave_Been_Ving_No_Obj_Condition_Fin
*/

    public class ATNSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 sameNode, InitATNSubjWillFToHaveBeenVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_FToHave_Been_Ving_No_Obj_TransOrFin;

        public ATNSubjWillFToHaveBeenVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillFToHaveBeenVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillFToHaveBeenVingNoObjTransOrFinNodeAction mInitAction;

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

