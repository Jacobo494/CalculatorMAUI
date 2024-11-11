
using CalculatorEnClases.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace CalculatorEnClases.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _importe = string.Empty; // varibale de isntanica  
        private string _numeroDePersonas="1"; 
        private string _porcentajeDePropina="10";

        //Inicio de las 4 propiedades
        private string _propina =string.Empty;  
        private string _propinaPorPersona= string.Empty;
        private string _importePorPersona=string.Empty;
        private string _importeConPropina=string.Empty;

        public string Propina // tipo cadena
        {
            get => _propina;
            set
            {
                if (value != _propina)
                {
                    _propina = value;
                    OnPropertyChanged(nameof(Propina));
                }
            }
        }

        public string PropinaPorPersona // tipo cadena
        {
            get => _propinaPorPersona;
            set
            {
                if (value != _propinaPorPersona)
                {
                    _propinaPorPersona = value;
                    OnPropertyChanged(nameof(PropinaPorPersona));
                }
            }
        }
        public string ImportePorPersona // tipo cadena
        {
            get => _importePorPersona;
            set
            {
                if (value != _importePorPersona)
                {
                    _importePorPersona = value;
                    OnPropertyChanged(nameof(ImportePorPersona));
                }
            }
        }

        public string ImporteConPropina // tipo cadena
        {
            get => _importeConPropina;
            set
            {
                if (value != _importeConPropina)
                {
                    _importeConPropina = value;
                    OnPropertyChanged(nameof(ImporteConPropina));
                }
            }
        }
   
        //Fin de las 4 propiedades 

        public string Importe // tipo cadena
        {
            get => _importe;
            set
            {
                if (value != _importe)
                {
                    _importe = value;
                    OnPropertyChanged(nameof(Importe));
                }
            }
        }

        public string NumeroDePersonas
            {
            get => _numeroDePersonas;
            set
            {
                if (value != _numeroDePersonas)
                {
                    _numeroDePersonas = value;
                    OnPropertyChanged(nameof(NumeroDePersonas));
                }
            }

            }
        //propiedad
        public string PorcentajeDePropina 
        {
            get => _porcentajeDePropina;
            set
            {
                if (value != _porcentajeDePropina)
                {
                    _porcentajeDePropina = value;
                    OnPropertyChanged(nameof(PorcentajeDePropina));
                }
            }

        }



        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName) 
        { 
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ICommand CalcularCommand { get; private set; }
        public ICommand LimpiarCommand { get; private set; }
        public ICommand PorcentajeDePropinaCommand { get; private set; }

        //Se agrego constructor 
        public MainViewModel()
        {
            LimpiarCommand = new Command(Limpiar);
            CalcularCommand = new Command(Calcular);
            PorcentajeDePropinaCommand = new Command<string>(ActualizarPorcentajeDePropina);


        }

        //dos metodos 
        public void Limpiar()
        {
            Importe = string.Empty;
            NumeroDePersonas = "1";
            PorcentajeDePropina = "10";

            Propina = string.Empty;
            PropinaPorPersona = string.Empty;
            ImporteConPropina = string.Empty;
            ImportePorPersona= string.Empty;

        }

        public void Calcular()
        {
            decimal importe = Convert.ToDecimal(Importe);
            decimal porcentajeDePropina = Convert.ToDecimal(PorcentajeDePropina);
            decimal numeroDePersonas = Convert.ToDecimal(NumeroDePersonas);


            decimal propina = CalculadoraDePropinas.Propina(importe, porcentajeDePropina);
            Propina=propina.ToString("C2");

            decimal propinaPorPersona = CalculadoraDePropinas.PropinaPorPersona(importe, numeroDePersonas, porcentajeDePropina);
            PropinaPorPersona = propinaPorPersona.ToString("C2");

            decimal importeConPropina = CalculadoraDePropinas.ImporteConPropina(importe, porcentajeDePropina);
            ImporteConPropina = importeConPropina.ToString();

            decimal importeporpersona = CalculadoraDePropinas.ImportePorPersona(importe, numeroDePersonas, porcentajeDePropina);
            ImportePorPersona = importeporpersona.ToString();

        }


        public void ActualizarPorcentajeDePropina(string nuevoValor)
        {
            PorcentajeDePropina = nuevoValor;
        }
        
    }
}
