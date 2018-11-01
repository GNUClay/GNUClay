using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotFToHaveBeenVingObjTransOrFinNodeAction(ATNSubjWillNotFToHaveBeenVingObjTransOrFinNode_v2 item);

    public class ATNSubjWillNotFToHaveBeenVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotFToHaveBeenVingObjTransOrFinNodeFactory_v2(ATNSubjWillNotFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotFToHaveBeenVingObjTransOrFinNodeFactory_v2(ATNSubjWillNotFToHaveBeenVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotFToHaveBeenVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotFToHaveBeenVingTransOrFinNode_v2 mParentNode;
        private ATNSubjWillNotFToHaveBeenVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotFToHaveBeenVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotFToHaveBeenVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotFToHaveBeenVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Not_FToHave_Been_Ving_Obj_Condition_Fin
*/

    public class ATNSubjWillNotFToHaveBeenVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotFToHaveBeenVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotFToHaveBeenVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveBeenVingObjTransOrFinNode_v2 sameNode, InitATNSubjWillNotFToHaveBeenVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_FToHave_Been_Ving_Obj_TransOrFin;

        public ATNSubjWillNotFToHaveBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotFToHaveBeenVingObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillNotFToHaveBeenVingObjTransOrFinNodeAction mInitAction;

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

