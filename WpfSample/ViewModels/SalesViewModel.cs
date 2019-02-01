using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfSample.Models;

namespace WpfSample.ViewModels
{
    public class SalesViewModel : ViewModel
    {
        List<Product> _products;
        int _quantity;
        decimal _rate;
        RelayCommand _saveCommand;
        RelayCommand _onProductSelectedCommand;

        public SalesViewModel()
        {
            _products = new List<Product>()
            {
                new Product {Id=1,Name="Mouse",Rate=500 },
                new Product {Id=2,Name="Keyboard",Rate=999.99m },
                new Product {Id=3,Name="Monitor",Rate=12458.64m }
            };

        }
        public Product SelectedProduct { get; set; }
        public int ProductId { get; set; }
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                SetProperty(ref _quantity, value);
                OnPropertyChanged("Total");

            }
        }
        public decimal Rate
        {
            get { return _rate; }
            set
            {
                SetProperty(ref _rate, value);
                OnPropertyChanged("Total");

            }
        }
        public decimal Total { get { return _rate * _quantity; } private set { } }
        public List<Product> Products { get { return _products; } }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(param => this.CanSave(), param => this.Save());
                }
                return _saveCommand;


            }
        }
        public ICommand OnProductSelectedCommand
        {
            get
            {
                if (_onProductSelectedCommand == null)
                {
                    _onProductSelectedCommand = new RelayCommand(p => CanUpdateOnProductSelected(p as Product), p=> UpdateOnProductSelected(p as Product));
                }
                return _onProductSelectedCommand;


            }
        }             

        private bool CanSave()
        {
            return Total >= 0;
        }

        private void Save()
        {
            // reminder :: convert to page service
            // temp code
            MessageBox.Show("Save Clicked");
        }
        private bool CanUpdateOnProductSelected(Product selcetedProduct)
        {
            return selcetedProduct != null;
        }
        public void UpdateOnProductSelected(Product selcetedProduct)
        {
            Rate = selcetedProduct.Rate;
            Quantity = 0;
        }

    }
}
