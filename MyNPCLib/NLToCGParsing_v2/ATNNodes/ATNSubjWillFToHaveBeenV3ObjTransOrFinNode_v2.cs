using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillFToHaveBeenV3ObjTransOrFinNodeAction(ATNSubjWillFToHaveBeenV3ObjTransOrFinNode_v2 item);

    public class ATNSubjWillFToHaveBeenV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillFToHaveBeenV3ObjTransOrFinNodeFactory_v2(ATNSubjWillFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillFToHaveBeenV3ObjTransOrFinNodeFactory_v2(ATNSubjWillFToHaveBeenV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillFToHaveBeenV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillFToHaveBeenV3TransOrFinNode_v2 mParentNode;
        private ATNSubjWillFToHaveBeenV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillFToHaveBeenV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillFToHaveBeenV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillFToHaveBeenV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_FToHave_Been_V3_Obj_Condition_Fin
*/

    public class ATNSubjWillFToHaveBeenV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillFToHaveBeenV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillFToHaveBeenV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenV3ObjTransOrFinNode_v2 sameNode, InitATNSubjWillFToHaveBeenV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_FToHave_Been_V3_Obj_TransOrFin;

        public ATNSubjWillFToHaveBeenV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillFToHaveBeenV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillFToHaveBeenV3ObjTransOrFinNodeAction mInitAction;

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

