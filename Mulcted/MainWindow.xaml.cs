using Mulcted.Processes.Implementations;
using Mulcted.Processes.Interfaces;
using Mulcted.Processes.Models;
using System.ComponentModel;
using System.Windows;

namespace Mulcted
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int _age;
        private TaxPayableItem _currentItem;
        private decimal _relief;
        private decimal _salary;
        private ITaxCalculator _taxCalculator;
        private decimal _total;

        public MainWindow()
        {
            _taxCalculator = new TaxCalculator();
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value != _age)
                {
                    _age = value;
                    OnPropertyChanged("Age");
                }
            }
        }

        public TaxPayableItem CurrentItem
        {
            get
            {
                return _currentItem;
            }
            set
            {
                if (value != _currentItem)
                {
                    _currentItem = value;
                    OnPropertyChanged("CurrentItem");
                }
            }
        }

        public decimal Relief
        {
            get
            {
                return _relief;
            }
            set
            {
                if (value != _relief)
                {
                    _relief = value;
                    OnPropertyChanged("Relief");
                }
            }
        }

        public decimal Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value != _salary)
                {
                    _salary = value;
                    OnPropertyChanged("Salary");
                }
            }
        }

        public decimal Total
        {
            get
            {
                return _total;
            }
            set
            {
                if (value != _total)
                {
                    _total = value;
                    OnPropertyChanged("Total");
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DecimalUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Salary = (decimal)e.NewValue;
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            CurrentItem = _taxCalculator.Calculate(Age, Salary);
            Relief = CurrentItem.ReliefAmount;
            Total = CurrentItem.DeductionAmount;
        }

        private void IntegerUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Age = (int)e.NewValue;
        }
    }
}