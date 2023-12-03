namespace P004.Avaliacao;

abstract class Pessoa{
    public string Nome {get; set;}
    public DateTime DataNascimento {get; set;}

    public int Idade => CalcularIdade();

    private string cpf;
    public string CPF {
        get {return cpf;}
        set {
            if (validarCPF(value)){
                cpf = value;
            }else{
                throw new Exception("CPF inválido");
            
            }
        }
    }

    private Boolean validarCPF(string cpf){
        if (cpf.Length == 11 ){

            try{
                long.Parse(cpf);
                return true;
            }catch (Exception e){
                return false;
            }
        }else{
            return false;
        }
    }

    public Pessoa(string nome, DateTime dataNascimento, string cpf){
        if (nome.Length != 0)
            Nome = nome;
        else
            throw new Exception("Nome vazio");
        DataNascimento = dataNascimento;
        CPF = cpf;
    }

    private int CalcularIdade(){
        int idade = DateTime.Now.Year - DataNascimento.Year;
        if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
            idade--;
        return idade;
    }
}