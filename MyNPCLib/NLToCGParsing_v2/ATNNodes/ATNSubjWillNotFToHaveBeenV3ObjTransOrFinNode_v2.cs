using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotFToHaveBeenV3ObjTransOrFinNodeAction(ATNSubjWillNotFToHaveBeenV3ObjTransOrFinNode_v2 item);

    public class ATNSubjWillNotFToHaveBeenV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotFToHaveBeenV3ObjTransOrFinNodeFactory_v2(ATNSubjWillNotFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotFToHaveBeenV3ObjTransOrFinNodeFactory_v2(ATNSubjWillNotFToHaveBeenV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotFToHaveBeenV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotFToHaveBeenV3TransOrFinNode_v2 mParentNode;
        private ATNSubjWillNotFToHaveBeenV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotFToHaveBeenV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotFToHaveBeenV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotFToHaveBeenV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Not_FToHave_Been_V3_Obj_Condition_Fin
*/

    public class ATNSubjWillNotFToHaveBeenV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotFToHaveBeenV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotFToHaveBeenV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveBeenV3ObjTransOrFinNode_v2 sameNode, InitATNSubjWillNotFToHaveBeenV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_FToHave_Been_V3_Obj_TransOrFin;

        public ATNSubjWillNotFToHaveBeenV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotFToHaveBeenV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillNotFToHaveBeenV3ObjTransOrFinNodeAction mInitAction;

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

