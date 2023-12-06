class Pagamento
{
    public Pagamento(string tipo, double valor_bruto, string descricao = "", double desconto = 0)
    {
        try {
            Tipo = tipo;
            ValorBruto = valor_bruto;
            Descricao = descricao;
            Desconto = desconto;
            DataHora = DateTime.Now;
        } catch ( Exception error ) {
            Console.WriteLine($"Mensagem de erro: {error.Message}");
        }
    }
    public string Tipo { 
        get { return Tipo; } 
        private set
        {
            if ( value != "cartao" && value != "boleto" && value != "dinheiro" ) {
                throw new Exception("Insira um tipo válido.");
            } else {
                Tipo = value;
            }
        }
    }
    public string? Descricao { get; protected set; }
    public double ValorBruto 
    {
        get { return ValorBruto; } 
        protected set
        {
            if ( value <= 0 ) {
                throw new Exception("Insira um valor maior que 0.");
            } else {
                ValorBruto = value;
            }
        }
    }
    public double Desconto { get; protected set; }
    public DateTime DataHora { get; private set; }
}