namespace AvaliacaoEquipe;

abstract class Pessoa{
    private string nome;
    public string Nome {
        get {return nome;} 
        set {
            string valor_formatado = Capitalize(value.Trim());         
            this.nome = valor_formatado;
        }
    }
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

    private string Capitalize(string value) 
    {
        char[] delimitadores = {' '};
        List<string> names = value.Split(delimitadores).ToList();
        names = names.Select(name => char.ToUpper(name[0]) + name.Substring(1)).ToList();

        return string.Join(" ", names);
    }
}