using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjFToHaveBeenVingNoObjTransOrFinNodeAction(ATNWillSubjFToHaveBeenVingNoObjTransOrFinNode_v2 item);

    public class ATNWillSubjFToHaveBeenVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjFToHaveBeenVingNoObjTransOrFinNodeFactory_v2(ATNWillSubjFToHaveBeenVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjFToHaveBeenVingNoObjTransOrFinNodeFactory_v2(ATNWillSubjFToHaveBeenVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjFToHaveBeenVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjFToHaveBeenVingNoTransNode_v2 mParentNode;
        private ATNWillSubjFToHaveBeenVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjFToHaveBeenVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjFToHaveBeenVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjFToHaveBeenVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_FToHave_Been_Ving_No_Obj_Condition_Fin
*/

    public class ATNWillSubjFToHaveBeenVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjFToHaveBeenVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjFToHaveBeenVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenVingNoObjTransOrFinNode_v2 sameNode, InitATNWillSubjFToHaveBeenVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_FToHave_Been_Ving_No_Obj_TransOrFin;

        public ATNWillSubjFToHaveBeenVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjFToHaveBeenVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNWillSubjFToHaveBeenVingNoObjTransOrFinNodeAction mInitAction;

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

