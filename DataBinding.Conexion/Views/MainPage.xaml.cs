using DataBinding.Conexion.models;


namespace DataBinding.Conexion.Views;

public partial class MainPage : ContentPage
{
    private List<OrigenDelPaquete> _origenes;
	public MainPage()
	{
		InitializeComponent();
        _origenes = new List<OrigenDelPaquete>();
        CargaDatos();
        OrigenesListView.ItemsSource = _origenes;
	}
    private void CargaDatos()
    {
        _origenes.Add(new OrigenDelPaquete
        {
            Nombre = "nuget.org",
            Origen = "Https://api.nuget.org/v3/index.json",
            EstaHabilitado = true,
        });
        _origenes.Add(new OrigenDelPaquete
        {
            Nombre = "Microsoft Visual Studio Offline Packages",
            Origen = "C://Program Files (x86)/Microsoft",
            EstaHabilitado = true
        });
        
    }
    private void onAddButtonClicked(object sender, EventArgs e)
    {
        var origen = new OrigenDelPaquete
        {
            Nombre = "Nombre del origen del paquete",
            Origen = "URL o ruta del origen del paquete",
            EstaHabilitado = true,
        };
        _origenes.Add(origen);
        OrigenesListView.ItemsSource = null;
        OrigenesListView.ItemsSource = _origenes;
        OrigenesListView.SelectedItem = origen;

    }

    private void _ActualizaCamposDeEntrada()
    {
        var origen = OrigenesListView.SelectedItem as OrigenDelPaquete;
        if (origen != null)
        {
            NombreEntry.Text = origen.Nombre;
            OrigenEntry.Text = origen.Origen;
        }
        else
        {
            NombreEntry.Text = string.Empty;
            OrigenEntry.Text = string.Empty;
        }

    }
    private void OnRemoveButtonClicked(object sender, EventArgs e)
    {
        OrigenDelPaquete seleccionado =
            (OrigenDelPaquete) OrigenesListView.SelectedItem;
        if (seleccionado != null)
        {
            _origenes.Remove(seleccionado);
            OrigenesListView.ItemsSource = null;
            OrigenesListView.ItemsSource = _origenes;
            _ActualizaCamposDeEntrada();
        }
    }

    private void OnSelectedOrigenesListViewI(object sender, SelectedItemChangedEventArgs e)
    {
        _ActualizaCamposDeEntrada();
    }

    private void OnActualizarButtonClicked(object sender, EventArgs e)
    {
        OrigenDelPaquete? seleccionado =
            OrigenesListView.SelectedItem as OrigenDelPaquete;
        if (seleccionado != null)
        {
            seleccionado.Nombre = NombreEntry.Text;
            seleccionado.Origen = OrigenEntry.Text;
            OrigenesListView.ItemsSource = null;
            OrigenesListView.ItemsSource= _origenes;

        }
    }
}