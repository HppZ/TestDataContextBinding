using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel = new ViewModel();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.Item.Layout.Name = "world";
            _viewModel.Item.Notify();
        }

        private void FrameworkElement_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine("data changed");
        }
    }

    public class ViewModel
    {
        public Item Item { get; set; }

        public ViewModel()
        {
            Item = new Item
            {
                Layout = new Layout()
                {
                    Name = "hello"
                }
            };
        }
    }

    public class Item : ObservableObject
    {
        public Layout Layout
        {
            get;
            set;
        }

        public void Notify()
        {
            OnPropertyChanged(nameof(Layout));
        }
    }

    public class Layout
    {
        public string Name { get; set; }
    }
}
