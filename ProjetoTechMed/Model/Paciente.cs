namespace AvaliacaoEquipe;

class Paciente : Pessoa{
    public string Sexo {get; set;}
    public List<String> Sintomas = new List<String>();

    public Paciente(string nome, DateTime dataNascimento, string cpf, string sexo) : base(nome, dataNascimento, cpf){
        if (sexo.ToLower() == "masculino" || sexo.ToLower() == "feminino")
            Sexo = sexo.ToLower();
        else
            throw new Exception("Insira um sexo válido.");
    }

    public void AdicionarSintoma(string sintoma){
        Sintomas.Add(sintoma);
    }
}