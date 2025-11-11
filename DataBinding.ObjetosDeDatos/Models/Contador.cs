using System.Collections.Specialized;
using System.ComponentModel;

namespace DataBinding.ObjetosDeDatos.Models
{
    public class Contador : INotifyPropertyChanged
    {
        private int _conteo;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int Conteo
        {
            get => _conteo;
            set
            {
                if (value != _conteo)
                {
                    _conteo = value;
                    OnpropertyChanged(nameof(Conteo));
                }
            }

        }
        public Contador(int conteoinicial = 0)
        {
            Conteo = conteoinicial;
        }

        public void Contar()
        {
            Conteo++;
        }

        public void Reiniciar()
        {
            Conteo = 0;
        }

        private void OnpropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)); 
        }

    }
}
