namespace AvaliacaoEquipe;

public class PlanoSaude{
    public string? Titulo {get; set;}
    private double ValorMes { 
        get {
            return ValorMes;
        }
        set {
            if(value <= 0){
                throw new Exception("Valor do plano não pode ser negativo");
            }
            ValorMes = value;
        }
    }

    public PlanoSaude(string titulo, double valorMes){
        Titulo = titulo;
        ValorMes = valorMes;
    }
}
