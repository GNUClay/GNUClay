using SquaresWorkBench.CommonEngine;
using SquaresWorkBench.TypicalCases;
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

        private void ShowWindow(BaseSoftCreator sceneCreator)
        {
            var window = new SceneWindow(sceneCreator);
            window.Show();
        }

        private void button_1_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(new TSTSoftCreator());
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(new Room_1_SoftCreator());
        }
    }
}
