using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class ATNNode
    {
        public ATNNode(TextPhraseContext context, ATNParser parent)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ATNNode");

            mParent = parent;
            mContext = context;
        }

        private TextPhraseContext mContext = null;
        private ATNParser mParent = null;

        public bool Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            var state = mContext.State;

            NLog.LogManager.GetCurrentClassLogger().Info($"Run state = {state}");

            switch (state)
            {
                case ATNNodeState.Init:
                    throw new NotImplementedException();

                case ATNNodeState.NP:
                    throw new NotImplementedException();

                case ATNNodeState.NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToDo:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToDo_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToDo_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToDo_Not_Have:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToDo_Not_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToDo_Not_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Be:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Be_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Be_Able:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Be_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Be_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Have:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Have_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Not_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Be:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Be_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Be_Able:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Be_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Be_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Have:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Have_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Will_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Not_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Not_Able:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Not_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Not_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Able:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToBe_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToHave:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToHave_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToHave_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToHave_Not_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToHave_To:
                    throw new NotImplementedException();

                case ATNNodeState.NP_FToHave_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Must:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Must_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Must_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Must_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_May:
                    throw new NotImplementedException();

                case ATNNodeState.NP_May_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_May_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_May_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Might:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Might_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Might_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Might_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Can:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Can_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Can_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Can_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Could:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Could_V:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Could_Not:
                    throw new NotImplementedException();

                case ATNNodeState.NP_Could_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW:
                    throw new NotImplementedException();

                case ATNNodeState.QW_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_Not_NP_Have:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_Not_NP_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_Not_NP_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_Not_Have:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_Not_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_Not_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_NP_Have:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_NP_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToDo_NP_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Be:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Be_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Be_Able:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Be_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Be_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Have:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Have_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_NP_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_Be:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_Be_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_Be_Able:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_Be_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_Be_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_Have:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_Have_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Not_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Be:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Be_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Be_Able:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Be_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Be_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Have:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Have_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_NP_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Be:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Be_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Be_Able:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Be_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Be_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Have:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Have_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Will_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Not_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Not_NP_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Not_NP_Able:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Not_NP_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Not_NP_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Not_Able:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Not_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Not_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_NP_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_NP_Able:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_NP_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_NP_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Able:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToBe_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToHave:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToHave_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToHave_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToHave_Not_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToHave_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToHave_Not_NP_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToHave_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToHave_NP_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToHave_To:
                    throw new NotImplementedException();

                case ATNNodeState.QW_FToHave_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Must:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Must_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Must_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Must_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Must_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Must_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Must_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Must_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_May:
                    throw new NotImplementedException();

                case ATNNodeState.QW_May_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_May_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_May_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_May_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_May_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_May_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_May_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Might:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Might_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Might_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Might_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Might_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Might_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Might_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Might_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Can:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Can_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Can_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Can_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Can_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Can_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Can_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Can_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Could:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Could_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Could_Not:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Could_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Could_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Could_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Could_NP:
                    throw new NotImplementedException();

                case ATNNodeState.QW_Could_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_NP:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_NP_Have:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_NP_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_NP_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_Not:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_Not_NP_Have:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_Not_NP_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.FToDo_Not_NP_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.Will:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Be:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Be_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Be_Able:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Be_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Be_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Have:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Have_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.Will_NP_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Be:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Be_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Be_Able:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Be_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Be_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Have:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Have_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Have_To:
                    throw new NotImplementedException();

                case ATNNodeState.Will_Not_NP_Have_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.V:
                    throw new NotImplementedException();

                case ATNNodeState.V_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Do:
                    throw new NotImplementedException();

                case ATNNodeState.Do_Not:
                    throw new NotImplementedException();

                case ATNNodeState.Do_Not_V:
                    throw new NotImplementedException();

                case ATNNodeState.Do_Not_V_NP:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_NP:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_NP_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_NP_Able:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_NP_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_NP_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_Not:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_Not_NP_Ving:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_Not_NP_Able:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_Not_NP_Able_To:
                    throw new NotImplementedException();

                case ATNNodeState.FToBe_Not_NP_Able_To_V:
                    throw new NotImplementedException();

                case ATNNodeState.FToHave:
                    throw new NotImplementedException();

                case ATNNodeState.FToHave_NP:
                    throw new NotImplementedException();

                case ATNNodeState.FToHave_NP_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.FToHave_Not:
                    throw new NotImplementedException();

                case ATNNodeState.FToHave_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.FToHave_Not_NP_V3f:
                    throw new NotImplementedException();

                case ATNNodeState.Must:
                    throw new NotImplementedException();

                case ATNNodeState.Must_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Must_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Must_Not:
                    throw new NotImplementedException();

                case ATNNodeState.Must_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Must_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.May:
                    throw new NotImplementedException();

                case ATNNodeState.May_NP:
                    throw new NotImplementedException();

                case ATNNodeState.May_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.May_Not:
                    throw new NotImplementedException();

                case ATNNodeState.May_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.May_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Might:
                    throw new NotImplementedException();

                case ATNNodeState.Might_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Might_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Might_Not:
                    throw new NotImplementedException();

                case ATNNodeState.Might_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Might_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Can:
                    throw new NotImplementedException();

                case ATNNodeState.Can_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Can_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Can_Not:
                    throw new NotImplementedException();

                case ATNNodeState.Can_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Can_Not_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Could:
                    throw new NotImplementedException();

                case ATNNodeState.Could_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Could_NP_V:
                    throw new NotImplementedException();

                case ATNNodeState.Could_Not:
                    throw new NotImplementedException();

                case ATNNodeState.Could_Not_NP:
                    throw new NotImplementedException();

                case ATNNodeState.Could_Not_NP_V:
                    throw new NotImplementedException();

                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state.ToString());
            }
        }
    }
}
