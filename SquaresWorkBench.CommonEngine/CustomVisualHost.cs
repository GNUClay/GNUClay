using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SquaresWorkBench.CommonEngine
{
    public class CustomVisualHost : FrameworkElement
    {
        private DrawingVisual _child;

        public CustomVisualHost(DrawingVisual drawingVisual)
        {
            _child = drawingVisual;
            AddVisualChild(_child);
        }

        public DrawingVisual Child
        {
            get
            {
                return _child;
            }

            set
            {
                if (_child != value)
                {
                    this.RemoveVisualChild(_child);
                    _child = value;
                    this.AddVisualChild(_child);
                }
            }
        }

        // Provide a required override for the VisualChildrenCount property.
        protected override int VisualChildrenCount
        {
            get { return _child == null ? 0 : 1; }
        }

        // Provide a required override for the GetVisualChild method.
        protected override Visual GetVisualChild(int index)
        {
            if (_child == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _child;
        }
    }
}
