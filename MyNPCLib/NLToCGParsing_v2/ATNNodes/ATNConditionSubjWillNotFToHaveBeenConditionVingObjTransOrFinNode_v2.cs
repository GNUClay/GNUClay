using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNodeAction(ATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2 item);

    public class ATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNodeFactory_v2(ATNConditionSubjWillNotFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNodeFactory_v2(ATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotFToHaveBeenConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Not_FToHave_Been_Condition_Ving_Obj_Condition_Fin
*/

    public class ATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2 sameNode, InitATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_FToHave_Been_Condition_Ving_Obj_TransOrFin;

        public ATNConditionSubjWillNotFToHaveBeenConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotFToHaveBeenConditionVingObjTransOrFinNodeAction mInitAction;

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

