using CompuTecApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CompuTecApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pedidos : ContentPage
    {
        public Pedidos()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                myCollectionView.ItemsSource = await App.Database.ReadProducts();
            }
            catch { }
        }

        async void Nuevo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.ProductDetail());
        }
        async void Editar_Clicked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var product = item.CommandParameter as Models.ProductModel;
            await Navigation.PushAsync(new ProductDetail(product));
        }
        async void Borrar_Clicked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var product = item.CommandParameter as Models.ProductModel;
            var result = await DisplayAlert("Confirmación", $"¿Está seguro de eliminar {product.Name}?", "Si", "No");
            if(result)
            {
                await App.Database.DeleteProduct(product);
                myCollectionView.ItemsSource = await App.Database.ReadProducts();
            }
        }

        async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                myCollectionView.ItemsSource = await App.Database.SearchProducts(e.NewTextValue);
            }
            catch { }
        }
    }
}