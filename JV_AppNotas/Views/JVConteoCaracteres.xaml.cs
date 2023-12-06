using Microsoft.Maui.Animations;

namespace JV_AppNotas.Views;

public partial class JVConteoCaracteres : ContentPage
{
	public JVConteoCaracteres()
	{
		InitializeComponent();
	}

    private void JV_CalcularClick(object sender, EventArgs e)
    {
        string input = inputEntry.Text;

        int numeros = ContarNumeros(input);
        int letras = ContarLetras(input);
        int vocales = ContarVocales(input);
        int mayusculas = ContarMayusculas(input);
        int minusculas = ContarMinusculas(input);
        int total = input.Length;

        numerosLabel.Text = $"Números: {numeros}";
        letrasLabel.Text = $"Letras: {letras}";
        vocalesLabel.Text = $"Vocales: {vocales}";
        mayusculasLabel.Text = $"Mayúsculas: {mayusculas}";
        minusculasLabel.Text = $"Minúsculas: {minusculas}";
        totalLabel.Text = $"Total: {total}";
    }

    private void JV_LimpiarClick(object sender, EventArgs e)
    {
 
        inputEntry.Text = string.Empty;
        numerosLabel.Text = string.Empty;
        letrasLabel.Text = string.Empty;
        vocalesLabel.Text = string.Empty;
        mayusculasLabel.Text = string.Empty;
        minusculasLabel.Text = string.Empty;
        totalLabel.Text = string.Empty;
    }

    private int ContarNumeros(string input)
    {
        int contadorNumeros = 0;

        foreach (char caracter in input)
        {
            if (char.IsDigit(caracter))
            {
                contadorNumeros++;
            }
        }

        return contadorNumeros;
    }

    private int ContarLetras(string input)
    {
        int contadorLetras = 0;

        foreach (char caracter in input)
        {
            if (char.IsLetter(caracter))
            {
                contadorLetras++;
            }
        }

        return contadorLetras;
    }

    private int ContarVocales(string input)
    {
        int contadorVocales = 0;

        foreach (char caracter in input)
        {
            if ("AEIOUaeiou".IndexOf(input) >= 0)
            {
                contadorVocales++;
            }
        }

        return contadorVocales;
    }

    private int ContarMayusculas(string input)
    {
        int contadorMayusculas = 0;

        foreach (char caracter in input)
        {
            if (char.IsUpper(caracter))
            {
                contadorMayusculas++;
            }
        }

        return contadorMayusculas;
    }


    private int ContarMinusculas(string input)
    {
        int contadorMinusculas = 0;

        foreach (char caracter in input)
        { 
            if (char.IsLower(caracter))
            {
                contadorMinusculas++;
            }
        }

        return contadorMinusculas;
    }

}