using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Xaml.Diagnostics;

namespace ItesDemo.ViewModels
{
    internal class TemplateViewModel: BaseViewModel
    {
        #region VARIABLES
        private string myVar;
        #endregion

        #region CONSTRUCTOR
        public TemplateViewModel()
        {

        }
        #endregion

        #region OBJETOS
        public string MyProperty
        {
            get { return myVar; }
            set { SetProperty(ref myVar, value); }
        }
        #endregion

        #region METODOS
        private void SimpleMetodo()
        {

        }

        private async Task ProcesoAsync()
        {

        }
        #endregion

        #region COMANDOS
        public ICommand ProcesoAsyncComando => new Command(async () => await ProcesoAsync());
        public ICommand ProcesoSimpleComando => new Command(SimpleMetodo);

        #endregion
    }
}

