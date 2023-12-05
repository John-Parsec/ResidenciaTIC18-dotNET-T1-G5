namespace AvaliacaoEquipe;

class Exame{
    private static int id = 0;
    public string Nome {get; set;}
    public float Valor {get; set;}
    public string Descricao {get; set;}
    public string Local {get; set;}
    public int Id {
        get{
            return Id;
        }
        private set{
            id++;
        }
    }

    public Exame(string nome, float valor, string descricao, string local){
        Nome = nome;
        Valor = valor;
        Descricao = descricao;
        Local = local;
        Id = id;
    }
}