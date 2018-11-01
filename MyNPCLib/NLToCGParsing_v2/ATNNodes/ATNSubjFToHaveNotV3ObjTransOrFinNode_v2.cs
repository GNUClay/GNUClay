using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveNotV3ObjTransOrFinNodeAction(ATNSubjFToHaveNotV3ObjTransOrFinNode_v2 item);

    public class ATNSubjFToHaveNotV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveNotV3ObjTransOrFinNodeFactory_v2(ATNSubjFToHaveNotV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveNotV3ObjTransOrFinNodeFactory_v2(ATNSubjFToHaveNotV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveNotV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveNotV3TransOrFinNode_v2 mParentNode;
        private ATNSubjFToHaveNotV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveNotV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveNotV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveNotV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToHave_Not_V3_Obj_Condition_Fin
*/

    public class ATNSubjFToHaveNotV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveNotV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveNotV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotV3ObjTransOrFinNode_v2 sameNode, InitATNSubjFToHaveNotV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Not_V3_Obj_TransOrFin;

        public ATNSubjFToHaveNotV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveNotV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjFToHaveNotV3ObjTransOrFinNodeAction mInitAction;

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

