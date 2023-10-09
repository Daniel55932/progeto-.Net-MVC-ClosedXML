namespace AgendaVeicular.Models;
public class PropertyRelatorioModel
{
    public int IdRelatorio {get;set;}
    public string? DataAtual {get;set;}
    public string? Veiculo {get;set;}
    public string? PecasNome {get;set;}
    public int PecasDurabilidade {get;set;}
    public int PecasSubstituicao {get;set;}
    public int Km {get;set;}
    public int SomaE_F {get;set;}
    public int SubtraiG_B1 {get;set;}
    public int SubtraiE_B1 {get;set;}
    public int DiminuiKmSubKmDur {get;set;}
}