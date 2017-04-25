using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.TypicalVisualComponents
{
    public class RedSquareHuman : BaseSquareHuman
    {
        public RedSquareHuman()
        {
            Class.Add("red square human");

            CurrentBrush = System.Windows.Media.Brushes.Red;
        }

        protected override void OnSetAlive()
        {
            if (Alive)
            {
                CurrentBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                CurrentBrush = System.Windows.Media.Brushes.Black;
            }
        }
    }
}
