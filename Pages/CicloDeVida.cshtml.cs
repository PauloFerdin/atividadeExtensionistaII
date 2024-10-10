using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CicloDeVidaModel : PageModel
{
    // Propriedades para armazenar os dados inseridos pelo usuário
    [BindProperty]
    public string TipoProduto { get; set; } // Tipo de produto
    [BindProperty]
    public double DistanciaTransporte { get; set; } // Distância de transporte em km
    [BindProperty]
    public double VidaUtil { get; set; } // Vida útil em anos
    [BindProperty]
    public double EnergiaUso { get; set; } // Energia consumida em kWh por ano

    // Propriedade para armazenar o resultado do cálculo
    public double? Resultado { get; set; }

    // Método que lida com o POST (quando o formulário é submetido)
    public void OnPost()
    {
        // Fatores de emissão de carbono (valores fictícios para exemplo)
        double fatorProducao = TipoProduto switch
        {
            "roupas" => 0.025, // toneladas de CO₂ por item de roupa
            "eletronicos" => 0.15, // toneladas de CO₂ por eletrônico
            "alimentos" => 0.05, // toneladas de CO₂ por kg de alimento
            _ => 0
        };

        double fatorTransporte = 0.0001; // toneladas de CO₂ por km transportado
        double fatorEnergia = 0.0005; // toneladas de CO₂ por kWh consumido

        // Cálculo do impacto do ciclo de vida do produto
        double emissaoProducao = fatorProducao; // Emissão durante a produção
        double emissaoTransporte = DistanciaTransporte * fatorTransporte; // Emissão durante o transporte
        double emissaoUso = EnergiaUso * VidaUtil * fatorEnergia; // Emissão durante o uso ao longo da vida útil

        // Somando todas as emissões
        Resultado = emissaoProducao + emissaoTransporte + emissaoUso;
    }
}