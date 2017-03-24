using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SquaresWorkBench.SimpleGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();         
        }

        private TSTWindow1 mTSTWindow1 = null;

        private void button_1_Click(object sender, RoutedEventArgs e)
        {
            mTSTWindow1 = new TSTWindow1();
            mTSTWindow1.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window2();
            window.Show();
        }
    }
}
