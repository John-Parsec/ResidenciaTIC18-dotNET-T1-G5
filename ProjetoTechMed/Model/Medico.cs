namespace AvaliacaoEquipe;

class Medico : Pessoa{
    public string CRM {get; private set;}
    public bool Vinculo {get; private set;}

    public void Desvincular(){
        Vinculo = false;
    }

    public Medico(string nome, DateTime dataNascimento, string cpf, string crm) : base(nome, dataNascimento, cpf){
        Vinculo = true;
        if (crm.Length !=0)
            CRM = crm;
        else
            throw new Exception("CRM vazio");
    }
}