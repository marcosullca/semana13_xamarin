using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using semana13.complementos;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace semana13.viewModels
{
    public class CalculadoraViewModel : INotifyPropertyChanged
    {
		int currentState = 1;
		double firstNumber, secondNumber;
		string resultText;
		string mathOperator;
		string inputString = "";
		public CalculadoraViewModel()
        {
			AgregarValor = new Command<string>((key) =>
			  {
				  
                  if (InputString == "0" || currentState < 0)
                  {
                      InputString = "";
                      if (currentState < 0)
                          currentState *= -1;
                  }
				  InputString += key;
				  System.Console.WriteLine("calculadora valor: " + InputString);
				  double number;
                  if (double.TryParse(InputString, out number))
                  {
                      InputString = number.ToString("N0");
                      if (currentState == 1)
                      {
                          firstNumber = number;
                      }
                      else
                      {
                          secondNumber = number;
                      }
                  }
              });

			AgregarOperador = new Command<string>((key) =>
			  {
				  currentState = -2;
				  mathOperator = key;	
			  });

			Limpiar = new Command<string>((key) =>
			 {
				 firstNumber = 0;
				 secondNumber = 0;
				 currentState = 1;
				 InputString = "0";
			 });

			Resultado = new Command<string>((key) =>
			  {
				  if (currentState == 2)
				  {
					  var result = Operaciones.Calculate(firstNumber, secondNumber, mathOperator);

					  InputString = result.ToString();
					  firstNumber = result;
					  currentState = -1;
					  System.Console.WriteLine("calculadora res: " + InputString);

				  }
			  });






        }

		public string InputString
		{
			protected set
			{
				if (inputString != value)
				{
					inputString = value;
					OnPropertyChanged("InputString");
					ResultText = inputString;
					// Perhaps the delete button must be enabled/disabled.

				}
			}

			get { return inputString; }
		}


        #region Icommand
        
		public ICommand AgregarValor { protected set; get; }
		public ICommand AgregarOperador { protected set; get; }
		public ICommand Limpiar { protected set; get; }
		public ICommand Resultado { protected set; get; }
		
		#endregion

		public string ResultText
		{
			protected set
			{
				if (resultText != value)
				{
					resultText = value;
					OnPropertyChanged("ResultText");
				}
				
			}
            get
            {
				return resultText;
            }
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}