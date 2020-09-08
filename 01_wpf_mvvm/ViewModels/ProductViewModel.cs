using _01_wpf_mvvm.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace _01_wpf_mvvm
{
    class ProductViewModel : BaseViewModel
    {
        private Product selectedProduct;
        private ObservableCollection<Product> products;
       

        public Product SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Product> Products
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged();
            }

        }
        
        public RelayCommand AddProductCommand { get; set; }
        public RelayCommand DeleteProductCommand { get; set; }

        public ProductViewModel()
        {
            initValues();

            AddProductCommand = new RelayCommand(AddProduct);
            DeleteProductCommand = new RelayCommand(DeleteProduct, CanExecuteDeleteProduct);

        }

        private void AddProduct(object parameter)
        {
            Product p = new Product { Name = "TBD", Price = 0, Stock = 0 };
            Products.Add ( p );
            SelectedProduct = p;
        }

        private void DeleteProduct(object parameter)
        {
            Product p = SelectedProduct;
            SelectedProduct = null;
            Products.Remove(p);

        }
        private bool CanExecuteDeleteProduct(object parameter)
        {
            return SelectedProduct == null ? false : true;
        }

        private void initValues()
        {
            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Patate", Price = 2.99, Stock = 50},
                new Product { Name = "Pomme", Price = 2.99, Stock = 50},
                new Product { Name = "Poire", Price = 2.99, Stock = 50},
                new Product { Name = "Piment", Price = 2.99, Stock = 50},
            };


        }


    }
}
