using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CalculadoraModel : PageModel
{
    // Propriedades que armazenam os dados inseridos pelo usuário
    [BindProperty]
    public double KmDirigidos { get; set; } // Quilômetros dirigidos por dia
    [BindProperty]
    public double KwhConsumidos { get; set; } // Consumo de eletricidade diário
    [BindProperty]
    public string TipoDieta { get; set; } // Tipo de dieta (carne, vegetariana, vegana)

    // Propriedade para armazenar o resultado da calculadora
    public double? Resultado { get; set; } // Resultado (toneladas de CO₂)

    // Método que lida com o POST (quando o usuário submete o formulário)
    public void OnPost()
    {
        // Fatores de emissão de carbono (valores fictícios, você pode ajustar)
        double fatorCarro = 0.00021; // toneladas de CO₂ por km dirigido
        double fatorEletricidade = 0.0005; // toneladas de CO₂ por kWh consumido

        // Fatores de dieta (em toneladas de CO₂ por ano)
        double fatorDieta = TipoDieta switch
        {
            "carne" => 2.5,
            "vegetariana" => 1.5,
            "vegana" => 1.0,
            _ => 0
        };

        // Cálculos das emissões
        double emissaoCarro = KmDirigidos * 365 * fatorCarro; // Emissão anual por km
        double emissaoEletricidade = KwhConsumidos * 365 * fatorEletricidade; // Emissão anual por kWh
        double emissaoDieta = fatorDieta; // Emissão anual pela dieta

        // Somando todas as emissões para obter o resultado final
        Resultado = emissaoCarro + emissaoEletricidade + emissaoDieta;
    }
}
