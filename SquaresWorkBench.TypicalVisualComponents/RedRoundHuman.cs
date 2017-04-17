using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SquaresWorkBench.TypicalVisualComponents
{
    public class RedRoundHuman: BaseRoundHuman
    {
        public RedRoundHuman()
        {
            Class.Add("red");

            CurrentBrush = Brushes.Red;
        }
    }
}
