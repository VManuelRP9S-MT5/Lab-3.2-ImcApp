using System;

namespace imcapp.Models
{
    public class CalculadoraIMC
    {
        public static decimal IndiceDeMasaCorporal(decimal peso, decimal estatura)
        {
            return peso / (estatura * estatura);
        }

        public enum EstadoNutricional
        {
            SinDeterminar,
            PesoBajo,
            PesoNormal,
            SobrePeso,
            Obesidad,
            ObesidadExtrema,
        }

        public static EstadoNutricional SituacionNutricional(decimal IMC)
        {
            if (IMC < 18.5M)
            {
                return EstadoNutricional.PesoBajo;
            }
            else if (IMC < 24.9M)
            {
                return EstadoNutricional.PesoNormal;
            }
            else if (IMC < 29.9M)
            {
                return EstadoNutricional.SobrePeso;
            }
            else if (IMC < 39.9M)
            {
                return EstadoNutricional.Obesidad;
            }
            else
            {
                return EstadoNutricional.ObesidadExtrema;
            }
        }

        public static string EstadoNutricionalComoCadena(EstadoNutricional estado)
        {
            switch (estado)
            {
                case EstadoNutricional.SinDeterminar:
                    return string.Empty;
                case EstadoNutricional.PesoBajo:
                    return "Peso Bajo";
                case EstadoNutricional.PesoNormal:
                    return "Peso Normal";
                case EstadoNutricional.SobrePeso:
                    return "Sobrepeso";
                case EstadoNutricional.Obesidad:
                    return "Obesidad";
                case EstadoNutricional.ObesidadExtrema:
                    return "Obesidad Extrema";
                default:
                    return string.Empty;
            }
        }
    }
}
