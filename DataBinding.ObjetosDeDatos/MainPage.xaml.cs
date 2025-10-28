using DataBinding.ObjetosDeDatos.Models;

namespace DataBinding.ObjetosDeDatos
{
    public partial class MainPage : ContentPage
    {
        private Contador _contador;

        public MainPage()
        {
            InitializeComponent();
            _contador = new Contador();
            BindingContext = _contador;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _contador.Contar();
          
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            _contador.Reiniciar();
        }

    }
}
