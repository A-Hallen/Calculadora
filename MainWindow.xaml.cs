using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VentanaBase;

namespace Calculadora
{
    public partial class MainWindow : WindowBase
    {
        private string operador;
        private double numero1;
        private double numero2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;

            string contenidoBoton = boton.Content.ToString();

            switch (contenidoBoton)
            {
                case "C":
                    txtResultado.Text = "";
                    numero1 = 0;
                    numero2 = 0;
                    break;
                case "=":
                    numero2 = double.Parse(txtResultado.Text);

                    double resultado = RealizarCalculo();

                    txtResultado.Text = resultado.ToString();
                    break;
                case ".":
                    if (string.IsNullOrEmpty(txtResultado.Text))
                    {
                        txtResultado.Text = "0.";
                    }
                    else
                    {
                        txtResultado.Text += contenidoBoton;
                    }
                    break;
                default:
                    if (contenidoBoton == "+" || contenidoBoton == "-" || contenidoBoton == "*" || contenidoBoton == "/")
                    {
                        if (string.IsNullOrWhiteSpace(txtResultado.Text))
                        {
                            break;
                        }

                        operador = contenidoBoton;
                        numero1 = double.Parse(txtResultado.Text);
                        txtResultado.Text = "";
                    }
                    else
                    {
                        txtResultado.Text += contenidoBoton;
                    }
                    break;
            }


        }

        private double RealizarCalculo()
        {
            double resultado = 0.0;

            switch (operador)
            {
                case "+":
                    resultado = numero1 + numero2;
                    break;
                case "-":
                    resultado = numero1 - numero2;
                    break;
                case "*":
                    resultado = numero1 * numero2;
                    break;
                case "/":
                    resultado = numero1 / numero2;
                    break;
            }

            return resultado;
        }

        private void Resultado_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (var character in e.Text)
            {
                if (!char.IsDigit(character))
                {
                    e.Handled = true; // Evita que se ingrese el carácter no numérico
                    break;
                }
            }
        }
    }
}
