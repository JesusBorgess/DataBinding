using DataBinding.Conexion.models;
using System.Collections.ObjectModel;


namespace DataBinding.Conexion.Views;
public partial class MainPage : ContentPage
{
    private OrigenDelPaquete? _origenSeleccionado;
    private string _nombreDelOrigen = string.Empty;
    private string _rutaDelOrigen = string.Empty;

    public ObservableCollection<OrigenDelPaquete> Origenes { get;}

    public OrigenDelPaquete? OrigenSeleccionado
    {
        get => _origenSeleccionado;
        set
        {
            if (_origenSeleccionado != value)
            {
                _origenSeleccionado = value;
                OnPropertyChanged(nameof(OrigenSeleccionado));
            }
        }
    }

    public string NombreDelOrigen
    {
        get => _nombreDelOrigen;
        set
        {
            if (_nombreDelOrigen != value)
            {
                _nombreDelOrigen = value;
                OnPropertyChanged(nameof(NombreDelOrigen));
            }
        }
    }
    public string RutaDelOrigen
    {
        get => _rutaDelOrigen;
        set
        {
            if (_rutaDelOrigen != value) ;
            OnPropertyChanged(nameof(RutaDelOrigen));
        }
    }
    public MainPage()
    {
        InitializeComponent();
        Origenes = new ObservableCollection<OrigenDelPaquete>();
        CargarDatos();
        BindingContext = this;

        _origenSeleccionado = Origenes[1];
        //OrigenesListView.ItemsSource = _origenes;
    }

    private void CargarDatos()
    {
        Origenes.Add(new OrigenDelPaquete()
        {
            Nombre = "nuget.org",
            Origen = "https://api.nuget.org/v3/index.json",
            EstaHabilitado = true,
        });
        Origenes.Add(new OrigenDelPaquete
        {
            Nombre = "Microsoft Visual Studio Offline Packages",
            Origen = "C:??\\Program Files (x86)\\Microsoft SDKs\\NuGetPackages\\",
            EstaHabilitado = true,
        });
        //OrignesListView.Add(origen);

    }
    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        var origen = new OrigenDelPaquete

        {
            Nombre = "Nombre del Origen del paquete",
            Origen = "URL o ruta del origen del paquete",
            EstaHabilitado = false,
        };
        Origenes.Add(origen);
        _origenSeleccionado = origen;

    }

    private void OnRemoveButtonClicked(object sender, EventArgs e)
    {
        OrigenDelPaquete? seleccionado = (OrigenDelPaquete)OriginesListView.SelectedItem;
        if (_origenSeleccionado != null)
        {
            var indice = Origenes.IndexOf(seleccionado);
            OrigenDelPaquete? nuevoSeleccionado;
            if (indice < Origenes.Count - 1)
            {
                nuevoSeleccionado = Origenes[indice + 1];

            }
            else
            {
                if (Origenes.Count > 1)
                {
                    nuevoSeleccionado = Origenes[Origenes.Count - 2];
                }
                else
                {
                    nuevoSeleccionado = null;
                }

            }
            Origenes.Remove(seleccionado);
            _origenSeleccionado = nuevoSeleccionado;

        }
    }



    private void OrigenesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //ActualizaCamposDeEntrada();
    }

    private void OnActualizarButtonClicked(object sender, EventArgs e)
    {
        if (OrigenSeleccionado != null)
        {
            if (!OrigenSeleccionado.Nombre.Equals(NombreDelOrigen)
                || !OrigenSeleccionado.Origen.Equals(RutaDelOrigen))
            {
                OrigenSeleccionado.Nombre = NombreDelOrigen;
                OrigenSeleccionado.Origen = RutaDelOrigen;

            }
        }
    }

       

    private void OrigenesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (OrigenSeleccionado != null)
        {
            NombreDelOrigen = OrigenSeleccionado.Nombre;
            RutaDelOrigen = OrigenSeleccionado.Origen;
        }
        else
        {
            NombreDelOrigen = string.Empty;
            RutaDelOrigen = string.Empty;
        }

    }
}
