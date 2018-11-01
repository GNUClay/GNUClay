using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjFToHaveBeenV3ObjTransOrFinNodeAction(ATNWillSubjFToHaveBeenV3ObjTransOrFinNode_v2 item);

    public class ATNWillSubjFToHaveBeenV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjFToHaveBeenV3ObjTransOrFinNodeFactory_v2(ATNWillSubjFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjFToHaveBeenV3ObjTransOrFinNodeFactory_v2(ATNWillSubjFToHaveBeenV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjFToHaveBeenV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjFToHaveBeenV3TransOrFinNode_v2 mParentNode;
        private ATNWillSubjFToHaveBeenV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjFToHaveBeenV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjFToHaveBeenV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjFToHaveBeenV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_FToHave_Been_V3_Obj_Condition_Fin
*/

    public class ATNWillSubjFToHaveBeenV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjFToHaveBeenV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjFToHaveBeenV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenV3ObjTransOrFinNode_v2 sameNode, InitATNWillSubjFToHaveBeenV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_FToHave_Been_V3_Obj_TransOrFin;

        public ATNWillSubjFToHaveBeenV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjFToHaveBeenV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNWillSubjFToHaveBeenV3ObjTransOrFinNodeAction mInitAction;

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

