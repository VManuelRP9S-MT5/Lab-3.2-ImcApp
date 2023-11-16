using System;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using imcapp.Models;

namespace imcapp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string nombre;
        public string Nombre
        {
            get => nombre;
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nombre)));
                }
            }
        }

        private double peso;
        public double Peso
        {
            get => peso;
            set
            {
                if (peso != value)
                {
                    peso = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Peso)));
                }
            }
        }

        private double estatura;
        public double Estatura
        {
            get => estatura;
            set
            {
                if (estatura != value)
                {
                    estatura = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Estatura)));
                }
            }
        }

        private string estadoNutricional;
        public string EstadoNutricional
        {
            get => estadoNutricional;
            set
            {
                if (estadoNutricional != value)
                {
                    estadoNutricional = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EstadoNutricional)));
                }
            }
        }

        public ICommand CalcularIMCCommand => new Command(CalcularIMC);
        public ICommand LimpiarCommand => new Command(Limpiar);

        private void CalcularIMC()
        {
            if (!string.IsNullOrEmpty(Nombre) && Peso > 0 && Estatura > 0)
            {
                decimal imc = CalculadoraIMC.IndiceDeMasaCorporal((decimal)Peso, (decimal)Estatura);
                string estadoNutricional = CalculadoraIMC.EstadoNutricionalComoCadena(CalculadoraIMC.SituacionNutricional(imc));

                // Construir el mensaje del IMC y la situación nutricional
                string mensaje = $"Nombre: {Nombre}\nEl Índice de Masa Corporal de la persona es: {imc:F2}\nLa situación nutricional de la persona es: {estadoNutricional}";

                EstadoNutricional = mensaje;
            }
            else
            {
                EstadoNutricional = "Por favor, ingrese un nombre, peso y una estatura válidos.";
            }
        }

        private void Limpiar()
        {
            Nombre = string.Empty;
            Peso = 0;
            Estatura = 0;
            EstadoNutricional = string.Empty;
        }
    }
}
