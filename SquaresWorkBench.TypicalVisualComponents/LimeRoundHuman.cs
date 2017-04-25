using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SquaresWorkBench.TypicalVisualComponents
{
    public class LimeRoundHuman: BaseRoundHuman
    {
        public LimeRoundHuman()
        {
            Class.Add("lime round human");

            CurrentBrush = Brushes.Lime;
        }
    }
}
