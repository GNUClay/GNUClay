using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveBeenVingObjTransOrFinNodeAction(ATNSubjFToHaveBeenVingObjTransOrFinNode_v2 item);

    public class ATNSubjFToHaveBeenVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveBeenVingObjTransOrFinNodeFactory_v2(ATNSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveBeenVingObjTransOrFinNodeFactory_v2(ATNSubjFToHaveBeenVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveBeenVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveBeenVingTransOrFinNode_v2 mParentNode;
        private ATNSubjFToHaveBeenVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveBeenVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveBeenVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveBeenVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToHave_Been_Ving_Obj_Condition_Fin
*/

    public class ATNSubjFToHaveBeenVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveBeenVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveBeenVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenVingObjTransOrFinNode_v2 sameNode, InitATNSubjFToHaveBeenVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Been_Ving_Obj_TransOrFin;

        public ATNSubjFToHaveBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveBeenVingObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjFToHaveBeenVingObjTransOrFinNodeAction mInitAction;

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

