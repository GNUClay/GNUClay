using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveNotBeenV3ObjTransOrFinNodeAction(ATNSubjFToHaveNotBeenV3ObjTransOrFinNode_v2 item);

    public class ATNSubjFToHaveNotBeenV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveNotBeenV3ObjTransOrFinNodeFactory_v2(ATNSubjFToHaveNotBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveNotBeenV3ObjTransOrFinNodeFactory_v2(ATNSubjFToHaveNotBeenV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveNotBeenV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveNotBeenV3TransOrFinNode_v2 mParentNode;
        private ATNSubjFToHaveNotBeenV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveNotBeenV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveNotBeenV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveNotBeenV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToHave_Not_Been_V3_Obj_Condition_Fin
*/

    public class ATNSubjFToHaveNotBeenV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveNotBeenV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveNotBeenV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotBeenV3ObjTransOrFinNode_v2 sameNode, InitATNSubjFToHaveNotBeenV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Not_Been_V3_Obj_TransOrFin;

        public ATNSubjFToHaveNotBeenV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveNotBeenV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjFToHaveNotBeenV3ObjTransOrFinNodeAction mInitAction;

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

