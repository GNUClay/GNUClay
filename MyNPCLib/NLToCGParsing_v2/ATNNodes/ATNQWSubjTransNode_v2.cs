using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjTransNodeAction(ATNQWSubjTransNode_v2 item);

    public class ATNQWSubjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjTransNodeFactory_v2(ATNInitNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjTransNodeFactory_v2(ATNQWSubjTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNInitNode_v2 mParentNode;
        private ATNQWSubjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Verb_TransOrFin
    QWSubj_FToDo_Trans
    QWSubj_Will_Trans
    QWSubj_FToBe_Trans
    QWSubj_FToHave_Trans
    QWSubj_ModalVerb_Trans
    QWSubj_Condition_Trans
*/

    public class ATNQWSubjTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNInitNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
            SlaveNAPNode = new ATNSlaveNAPNode(context, new SubjectTargetOfATNSlaveNAPNode());
            RegATNSlaveNAPNode(SlaveNAPNode);
        }

        public ATNQWSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjTransNode_v2 sameNode, InitATNQWSubjTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            CommaInstruction = mSameNode.CommaInstruction;
            SlaveNAPNode = mSameNode.SlaveNAPNode.Fork(context);
            RegATNSlaveNAPNode(SlaveNAPNode);
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Trans;

        public ATNInitNode_v2 ParentNode { get; private set; }
        private ATNQWSubjTransNode_v2 mSameNode;
        private InitATNQWSubjTransNodeAction mInitAction;

        public ATNSlaveNAPNode SlaveNAPNode { get; set; }
        public CommaInstructionsOfATNSlaveNAPNode CommaInstruction { get; set; } = CommaInstructionsOfATNSlaveNAPNode.None;

        protected override void ImplementGoalToken()
        {
#if DEBUG
            //LogInstance.Log($"Token = {Token}");
            //LogInstance.Log($"Context = {Context}");
#endif

            Context.Sentence.IsQuestion = true;

            SetAsSuccess(SlaveNAPNode.Run(Token, CommaInstruction));
        }

        protected override void ProcessNextToken()
        {
            var extendedTokensList = Get—lusterOfExtendedTokens();

#if DEBUG
            //LogInstance.Log($"extendedTokensList.Count = {extendedTokensList.Count}");
#endif

            if (extendedTokensList.Count == 0)
            {
                throw new NotImplementedException();
            }

            foreach (var item in extendedTokensList)
            {
#if DEBUG
                //LogInstance.Log($"item = {item}");
#endif

                var kindOfItem = item.KindOfItem;

                switch (kindOfItem)
                {
                    case KindOfItemOfSentence.Verb:
                        AddTask(new ATNQWSubjVerbTransOrFinNodeFactory_v2(this, item));
                        break;

                    case KindOfItemOfSentence.FToDo:
                        AddTask(new ATNQWSubjFToDoTransNodeFactory_v2(this, item));
                        break;

                    case KindOfItemOfSentence.FToBe:
                        AddTask(new ATNQWSubjFToBeTransNodeFactory_v2(this, item));
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfItem), kindOfItem, null);
                }
            }
        }
    }
}

