namespace AvaliacaoEquipe;

public class PlanoSaude{
    public string? Titulo {get; set;}

    private double valorMes {get; set;}
    
    public double ValorMes { 
        get {
            return valorMes;
        }
        set {
            if(value <= 0){
                throw new Exception("Valor do plano não pode ser negativo");
            }

            valorMes = value;
        }
    }

    public PlanoSaude(string titulo, double valorMes){
        Titulo = titulo;
        ValorMes = valorMes;
    }
}
