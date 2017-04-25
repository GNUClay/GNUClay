using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SquaresWorkBench.TypicalVisualComponents
{
    public class LimeSquareHuman : BaseSquareHuman
    {
        public LimeSquareHuman()
        {
            Class.Add("lime square human");

            CurrentBrush = Brushes.Lime;
        }
    }
}
