using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItesDemo.Models;
using System.Windows.Input;

namespace ItesDemo.ViewModels
{
    internal class ProductoDetalleViewModel : BaseViewModel
    {
        #region VARIABLES
        private string myVar;
        private ProductosModel productoSeleccion;
        #endregion

        #region CONSTRUCTOR
        public ProductoDetalleViewModel()
        {
            Title = "Detalle de Producto";
        }
        #endregion

        #region OBJETOS
        public ProductosModel ProductoSeleccion
        {
            get { return productoSeleccion; }
            set { SetProperty(ref productoSeleccion, value); }
        }
        #endregion

        #region METODOS   

        private async Task GoToBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        #endregion

        #region COMANDOS
        public ICommand GoToBackCommand => new Command(async () => await GoToBack());
        // public ICommand ProcesoSimpleComando => new Command(SimpleMetodo);    

        #endregion
    }
}
