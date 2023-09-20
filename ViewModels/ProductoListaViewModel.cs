using ItesDemo.Models;
using ItesDemo.Services;
using ItesDemo.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ItesDemo.ViewModels
{
    internal class ProductoListaViewModel : BaseViewModel
    {
        #region VARIABLES
        private bool isRefreshing;
        private ProductosModel productoSeleccion;

        private ObservableCollection<ProductosModel> productos = new ObservableCollection<ProductosModel>();
        #endregion

        #region CONSTRUCTOR
        public ProductoListaViewModel()
        {
            Title = "Lista Productos";

            Task.Run(async () => { await ConsultarApi(); }).Wait();

            // ConsultarApi();

            RefreshCommand = new Command(async () =>
            {
                if (IsBusy)
                {
                    return;
                }

                await ConsultarApi();
            });
            
        }
        #endregion

        #region OBJETOS
        public ObservableCollection<ProductosModel> Productos
        {
            get { return productos; }
            set { SetProperty(ref productos, value); }
        }

        public ProductosModel ProductoSeleccion
        {
            get { return productoSeleccion; }
            set { SetProperty(ref productoSeleccion, value); }
        }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetProperty(ref isRefreshing, value); }
        }
        #endregion

        #region METODOS
        private async Task ConsultarApi()
        {
            IsBusy = IsRefreshing = true;

            Productos.Clear();

            var apiClient = new ApiClient();

            var lista = await apiClient.ObtenerProductos();

            Productos = new ObservableCollection<ProductosModel>(lista);

            IsBusy = IsRefreshing = false;
        }

        private void GoToCancelar()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

        private void GoToDetail()
        {
            Application.Current.MainPage.Navigation.PushAsync(new ProductoDetallePage(productoSeleccion));
        }
        #endregion

        #region COMANDOS
        public ICommand GoToCancelarCommand => new Command(() => GoToCancelar());
        public ICommand GoToDetailCommand => new Command(() => GoToDetail());
        public ICommand RefreshCommand { get; set; }
        #endregion
    }
}
