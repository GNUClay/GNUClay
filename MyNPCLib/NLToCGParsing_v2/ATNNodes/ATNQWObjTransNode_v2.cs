using MyNPCLib.NLToCGParsing;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjTransNodeAction(ATNQWObjTransNode_v2 item);

    public class ATNQWObjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjTransNodeFactory_v2(ATNInitNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjTransNodeFactory_v2(ATNQWObjTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNInitNode_v2 mParentNode;
        private ATNQWObjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_FToDo_Trans
    QWObj_Will_Trans
    QWObj_FToBe_Trans
    QWObj_FToHave_Trans
    QWObj_ModalVerb_Trans
*/

    public class ATNQWObjTransNode_v2: BaseATNNode_v2
    {
        public ATNQWObjTransNode_v2(ContextOfATNParsing_v2 context, ATNInitNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
            SlaveNAPNode = new ATNSlaveNAPNode(context, new QuestionToObjectOfSentenceTargetOfATNSlaveNAPNode());
            RegATNSlaveNAPNode(SlaveNAPNode);
        }

        public ATNQWObjTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjTransNode_v2 sameNode, InitATNQWObjTransNodeAction initAction, ATNExtendedToken token)
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

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Trans;

        public ATNInitNode_v2 ParentNode { get; private set; }
        private ATNQWObjTransNode_v2 mSameNode;
        private InitATNQWObjTransNodeAction mInitAction;

        public ATNSlaveNAPNode SlaveNAPNode { get; set; }
        public CommaInstructionsOfATNSlaveNAPNode CommaInstruction { get; set; } = CommaInstructionsOfATNSlaveNAPNode.None;

        protected override void ImplementGoalToken()
        {
#if DEBUG
            LogInstance.Log($"Token = {Token}");
            LogInstance.Log($"Context = {Context}");
#endif

            Context.Sentence.IsQuestion = true;

            SetAsSuccess(SlaveNAPNode.Run(Token, CommaInstruction));
        }

        protected override void ProcessNextToken()
        {
            var extendedTokensList = Get—lusterOfExtendedTokens();

#if DEBUG
            LogInstance.Log($"extendedTokensList.Count = {extendedTokensList.Count}");
#endif

            if (extendedTokensList.Count == 0)
            {
                throw new NotImplementedException();
            }

            var hasObjOrSubj = false;

            foreach (var item in extendedTokensList)
            {
#if DEBUG
                LogInstance.Log($"item = {item}");
#endif

                var kindOfItem = item.KindOfItem;

                switch (kindOfItem)
                {
                    case KindOfItemOfSentence.Condition:
                        if(item.IsOf)
                        {
                            break;
                        }
                        throw new ArgumentOutOfRangeException(nameof(kindOfItem), kindOfItem, null);

                    case KindOfItemOfSentence.Subj:
                        if (hasObjOrSubj)
                        {
                            break;
                        }
                        hasObjOrSubj = true;
                        AddTask(new ATNQWObjTransNodeFactory_v2(this, item, null));
                        break;

                    case KindOfItemOfSentence.Obj:
                        if (hasObjOrSubj)
                        {
                            break;
                        }
                        hasObjOrSubj = true;
                        AddTask(new ATNQWObjTransNodeFactory_v2(this, item, null));
                        break;

                    case KindOfItemOfSentence.Verb:
                        break;

                    case KindOfItemOfSentence.FToDo:
                        AddTask(new ATNQWObjFToDoTransNodeFactory_v2(this, item));
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfItem), kindOfItem, null);
                }
            }
        }
    }
}

