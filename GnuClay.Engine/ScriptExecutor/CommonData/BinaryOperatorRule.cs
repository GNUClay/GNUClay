using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public class BinaryOperatorRule
    {
        public int FirstOperandType = 0;
        public int SecondOperandType = 0;
        public BinaryOperatorHandler OperatorHandler = null;
    }
}
