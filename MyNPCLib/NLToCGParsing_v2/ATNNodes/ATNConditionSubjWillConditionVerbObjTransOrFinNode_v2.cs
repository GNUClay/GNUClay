using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillConditionVerbObjTransOrFinNodeAction(ATNConditionSubjWillConditionVerbObjTransOrFinNode_v2 item);

    public class ATNConditionSubjWillConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionSubjWillConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionSubjWillConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNConditionSubjWillConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillConditionVerbObjTransOrFinNode_v2 sameNode, InitATNConditionSubjWillConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Condition_Verb_Obj_TransOrFin;

        public ATNConditionSubjWillConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillConditionVerbObjTransOrFinNodeAction mInitAction;

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

