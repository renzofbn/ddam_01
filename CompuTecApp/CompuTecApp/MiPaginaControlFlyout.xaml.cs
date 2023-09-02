using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CompuTecApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MiPaginaControlFlyout : ContentPage
    {
        public ListView ListView;

        public MiPaginaControlFlyout()
        {
            InitializeComponent();

            BindingContext = new MiPaginaControlFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class MiPaginaControlFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MiPaginaControlFlyoutMenuItem> MenuItems { get; set; }

            public MiPaginaControlFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MiPaginaControlFlyoutMenuItem>(new[]
                {
                    new MiPaginaControlFlyoutMenuItem { Id = 0, Title = "Pedidos", TargetType=typeof(Pedidos), IconSource="pedido.png" },
                    //new MiPaginaControlFlyoutMenuItem { Id = 1, Title = "Page 2" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}