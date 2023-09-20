using ItesDemo.Models;
using ItesDemo.ViewModels;

namespace ItesDemo.Views;

public partial class ProductoDetallePage : ContentPage
{
    public ProductoDetallePage(ProductosModel seleccion)
    {
        InitializeComponent();
        ProductoDetalleViewModel viewModel = new ProductoDetalleViewModel();
        viewModel.ProductoSeleccion = seleccion;
        BindingContext = viewModel;
    }
}