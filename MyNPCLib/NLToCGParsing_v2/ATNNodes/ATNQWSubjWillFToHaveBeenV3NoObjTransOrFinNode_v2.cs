using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNodeAction(ATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNode_v2 item);

    public class ATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNodeFactory_v2(ATNQWSubjWillFToHaveBeenV3NoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNodeFactory_v2(ATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillFToHaveBeenV3NoTransNode_v2 mParentNode;
        private ATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_FToHave_Been_V3_No_Obj_Condition_Fin
*/

    public class ATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenV3NoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNode_v2 sameNode, InitATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_FToHave_Been_V3_No_Obj_TransOrFin;

        public ATNQWSubjWillFToHaveBeenV3NoTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjWillFToHaveBeenV3NoObjTransOrFinNodeAction mInitAction;

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

