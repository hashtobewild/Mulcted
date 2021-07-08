using Mulcted.Processes.Implementations;
using System.Windows;

namespace Mulcted
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

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            var testingCalc = new TaxCalculator();
            var xx = testingCalc.Calculate(51, 120000);
            var yy = xx.DeductionAmount;
        }
    }
}