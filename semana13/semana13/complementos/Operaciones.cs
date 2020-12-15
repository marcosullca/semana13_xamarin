using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace semana13.complementos
{
    public static class Operaciones
    {
        public static double Calculate(double valor1, double valor2, string operador)
        {
            double resultado = 0;
            switch (operador)
            {
                case "÷":
                    resultado = valor1 / valor2;
                    break;
                case "×":
                    resultado = valor1 * valor2;
                    break;
                case "+":
                    resultado = valor1 + valor2;
                    break;
                case "-":
                    resultado = valor1 - valor2;
                    break;
            }
            return resultado;
        }
    }
}