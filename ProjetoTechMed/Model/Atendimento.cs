namespace AvaliacaoEquipe;

class Atendimento{
     private static int id = 0;
    public DateTime DataInicio {get; set;}
    public DateTime DataFim {get; private set;}
    public string Suspeita {get; set;}

    public float ValorTotal {get; private set;}

    public int Id {
        get{
            return id;
        }
        private set{
            id++;
        }
    }
    public Medico Responsavel {get; set;}
    public Paciente Paciente {get;}

    public string Diagnostico {get; private set;} 

    public List<(Exame, string)> Exames {get;}

    public Atendimento(DateTime dataInicio,string suspeita, Medico responsavel, Paciente paciente){
        DataInicio = dataInicio;
        DataFim = DateTime.MinValue;
        Suspeita = suspeita;
        ValorTotal = 0;
        Responsavel = responsavel;
        Paciente = paciente;
        Diagnostico = "";
        Exames = new List<(Exame exame, string resultado)>();
        Id = id;
    }

    public void AdicionarExame(Exame exame, string resultado){
        Exames.Add((exame, resultado));
        ValorTotal += exame.Valor;
    }

    public void FinalizarAtendimento(string diagnostico){
        Diagnostico = diagnostico;
        DataFim = DateTime.Now;
    }

    

    


}