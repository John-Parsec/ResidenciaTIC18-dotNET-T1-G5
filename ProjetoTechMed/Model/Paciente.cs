namespace AvaliacaoEquipe;

class Paciente : Pessoa{
    public string Sexo {get; set;}
    public List<String> Sintomas = new List<String>();

    public PlanoSaude Plano {get; set;}
    public List<Pagamento> Pagamentos { get; set; }

    public Paciente(string nome, DateTime dataNascimento, string cpf, string sexo, PlanoSaude plano) : base(nome, dataNascimento, cpf){
        if (sexo.ToLower() == "masculino" || sexo.ToLower() == "feminino")
            Sexo = sexo.ToLower();
        else
            throw new Exception("Insira um sexo válido.");

        if (plano != null)
            Plano = plano!;
        else
            throw new Exception("Plano inválido");

        Pagamentos = new List<Pagamento>();
    }

    public void AdicionarSintoma(string sintoma){
        Sintomas.Add(sintoma);
    }
     public void AdicionarPagamento(Pagamento pagamento)
    {
        if (Pagamentos == null)
        {
            Pagamentos = new List<Pagamento>();
        }
        Pagamentos.Add(pagamento);
    }

    public void AdicionarPlano(PlanoSaude plano){
        if (plano != null){
            Plano = plano!;
        } else {
            throw new Exception("Plano inválido");
        }
    }

    public void ListarPagamentos()
    {
        if ( Pagamentos.Count == 0 ) {
            throw new Exception("Não há pagamentos registrados no momento.");
        }
        else 
        {
            foreach(Pagamento pgmt in Pagamentos)
            {
                    Console.Write("Tipo: " + pgmt.Tipo);
                    Console.Write(" | Valor bruto: " + pgmt.ValorBruto);
                    Console.Write(" | Descrição: " + pgmt.Descricao);
                    Console.WriteLine(" | Desconto: " + pgmt.Desconto);
                    Console.WriteLine(" - Data e hora: " + pgmt.DataHora.ToString("dd/MM/yyyy HH:mm:ss"));
            }
        }
        
    }
}