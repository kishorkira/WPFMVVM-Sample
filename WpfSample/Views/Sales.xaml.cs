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
using WpfSample.Models;
using WpfSample.ViewModels;

namespace WpfSample.Views
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Page
    {
        SalesViewModel ViewModel { get { return (DataContext as SalesViewModel); }}
        public Sales()
        {
            InitializeComponent();
            DataContext = new SalesViewModel();
        }
        private void OnProductSelected(object sender, EventArgs e)
        {
            
            if (!ViewModel.OnProductSelectedCommand.CanExecute(null)) return;
            ViewModel.OnProductSelectedCommand.Execute(null);
               
        }
    }
}
