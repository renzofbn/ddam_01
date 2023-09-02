using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CompuTecApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetail : ContentPage
    {
        public ProductDetail()
        {
            InitializeComponent();
        }

        Models.ProductModel _product;
        public ProductDetail(Models.ProductModel product)
        {
            InitializeComponent();
            Title = "Editar Producto";
            _product = product;
            nameEntry.Text = _product.Name;
            priceEntry.Text = _product.Price;
            nameEntry.Focus();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameEntry.Text) || string.IsNullOrWhiteSpace(priceEntry.Text))
            {
                await DisplayAlert("Error", "Porfavor llene todos los campos", "OK");
            }
            else if (_product != null)
                UpdateProduct();
            else
                AddNewProduct();

        }

        async void AddNewProduct()
        {
            await App.Database.CreateProduct(new Models.ProductModel
            {
                Name = nameEntry.Text,
                Price = priceEntry.Text
            });
            await Navigation.PopAsync();
        }

        async void UpdateProduct()
        {
            _product.Name = nameEntry.Text;
            _product.Price = priceEntry.Text;
            await App.Database.UpdateProduct(_product);
            await Navigation.PopAsync();
        }
    }
}