namespace AvaliacaoEquipe;
using System.Collections.Generic;
using Utils;

class Interface{
#region Menu Principal Do Sistema
   public static void App(Consultorio consultorio){
        
        bool sair = false;
    
        List<string> menuPrincipal = new List<string>{"Menu Pacientes", "Menu Médicos", "Menu Atendimento", "Menu Plano de Saude", "Menu Relatórios"};
    
        while (!sair)
        {
            Util.limparTela();
            Util.Logo();
            Exibir(menuPrincipal);
            int opcao = ObterOpcao(menuPrincipal.Count); // Obtém uma opção válida para o menu
            
            switch (opcao)
            {
                case 0:
                    sair = true;
                    return;
                case 1:
                    MenuPacientes(consultorio);
                    break;
                case 2:
                    MenuMedicos(consultorio);
                    break;
                case 3:
                    MenuAtendimento(consultorio);
                    break;
                case 4:
                    MenuPlano(consultorio);
                    break;
                case 5:
                    MenuRelatorios(consultorio);
                    break;
                default:
                    NotificarOpcaoInvalida();
                    break;
            }
        }
        
}

#endregion

#region Menu Pacientes

  public static void MenuPacientes(Consultorio consultorio){
    bool sair = false;
    List<string> menu = new List<string>{ "Inserir Paciente", "Adicionar Sintoma", "Remover Paciente", "Listar Pacientes"};
   
    while (!sair){
        Util.limparTela();
        Util.Logo();
        Util.TituloMenu("Pacientes 😷");
        Exibir(menu);
        int opcao = ObterOpcao(menu.Count);
        Console.Clear();

        // Declarando instância de App para chamar funcionalidades

        switch (opcao){
            case 0:
                // Lógica para sair do programa
                sair = true;
                return;
            case 1:
                // Lógica para inserir um paciente
                Util.limparTela();
                Util.Logo();
                consultorio.AdicionarPaciente();
                Util.pausa();
                break;
            case 2:
                // Lógica para adicionar sintoma
                Util.limparTela();
                Util.Logo();
                consultorio.AdicionarSintoma();
                Util.pausa();
                break;
            case 3:
                // Lógica para remover um paciente
                Util.limparTela();
                Util.Logo();
                consultorio.RemoverPaciente();
                Util.pausa();
                break;
            case 4:
                 // Lógica para listar os pacientes
                Util.limparTela();
                Util.Logo();
                consultorio.ListaDePacientes();
                Util.pausa();
                break;
            default:
                Util.limparTela();
                Util.Logo();
                NotificarOpcaoInvalida();
                Util.pausa();
                break;
        }
    }
    
}


#endregion

#region Menu Medicos
 public static void MenuMedicos(Consultorio consultorio){
    bool sair = false;
    List<string> menu = new List<string>{
        "Inserir Médico", "Remover Médico", "Listar Médicos"
    };

    while (!sair)
    {
        Util.limparTela();
        Util.Logo();
        Util.TituloMenu("Médicos 🩺");
        Exibir(menu);
        int opcao = ObterOpcao(menu.Count);;

       
        switch (opcao){
            case 0:
                // Lógica para sair do programa
                sair = true;
                return;
            case 1:
                // Lógica para inserir um médico
                Util.limparTela();
                Util.Logo();
                Console.WriteLine("Inserindo Médico...");
                consultorio.AdicionarMedico();
                Util.pausa();
                break;
            case 2:
                // Lógica para remover um médico
                Util.limparTela();
                Util.Logo();
                Console.WriteLine("Removendo Médico...");
                consultorio.RemoverMedico();
                Util.pausa();
                break;
            case 3:
                // Lógica para listar os médicos
                Util.limparTela();
                Util.Logo();
                Console.WriteLine("Listando Médicos...");
                consultorio.ListarMedicos();
                Util.pausa();
                break;
            default:
                Util.limparTela();
                Util.Logo();
                NotificarOpcaoInvalida();
                Util.pausa();
                break;
        }

    }
}

#endregion

#region Menu Atendimento
   public static void MenuAtendimento(Consultorio consultorio){
        bool sair = false;
        List<string> menu = new List<string>{
            "Inserir Novo Atendimento", "Adicionar Exame", "Listar Atendimentos", "Finalizar Atendimento", "Remarcar Atendimento"
        };

        while (!sair){
            Util.limparTela();
            Util.Logo();
            Util.TituloMenu("Atendimentos 🚑");
            Exibir(menu);
            int opcao = ObterOpcao(menu.Count);
            Console.Clear();

        
            switch (opcao)
            {
                case 0:
                    // Lógica para sair do programa
                    sair = true;
                    return;
                case 1:
                    Util.limparTela();
                    Util.Logo();
                    // Lógica para inserir um novo atendimento
                    consultorio.AdicionarAtendimento();
                    Util.pausa();
                    // Aqui você pode chamar uma função para inserir um novo atendimento
                    break;
                case 2:
                    // Lógica para adicionar um exame a um atendimento
                    Util.limparTela();
                    Util.Logo();
                    consultorio.AdicionarExame();
                    Util.pausa();
                    // Aqui você pode chamar uma função para adicionar um exame a um atendimento
                    break;
                case 3:
                    // Lógica para listar os atendimentos
                    Util.limparTela();
                    Util.Logo();
                    consultorio.ListarAtendimentos();
                    Util.pausa();
                    // Aqui você pode chamar uma função para listar os atendimentos existentes
                    // consultorio.ListarAtendimentos();
                    break;
                case 4:
                    // Lógica para finalizar atendimento os atendimentos
                    Util.limparTela();
                    Util.Logo();
                    Console.WriteLine("Listando Atendimentos...");
                    consultorio.FinalizarAtendimento() ;     
                    Util.pausa();          
                    break;
                case 5:
                    // Lógica para Editar atendimento os atendimentos
                    consultorio.EditarAtendimento();               
                    break;
                default:
                    Util.limparTela();
                    Util.Logo();
                    NotificarOpcaoInvalida();
                    Util.pausa();
                    break;
            }
        }
    }
#endregion

#region Menu Relatorios
    public static void MenuRelatorios(Consultorio consultorio)
{
    bool sair = false;
    List<string> menu = new List<string>{
        "Médicos com idade entre dois valores",
        "Pacientes com idade entre dois valores",
        "Pacientes do sexo informado pelo usuário",
        "Pacientes em ordem alfabética",
        "Pacientes cujos sintomas contenham texto informado",
        "Médicos e Pacientes aniversariantes do mês informado",
        "Atendimentos em aberto em ordem decrescente pela data de início",
        "Médicos em ordem decrescente da quantidade de atendimentos concluídos",
        "Atendimentos cuja suspeita ou diagnóstico final contenha determinada palavra",
        "Os 10 exames mais utilizados nos atendimentos"
    };

    while (!sair)
    {
        Util.limparTela();
        Util.Logo();
        Util.TituloMenu("Relatórios");
        Exibir(menu);
        int opcao = ObterOpcao(menu.Count);
        Console.Clear();

       
        switch (opcao)
        {
            case 0:
                // Lógica para sair do programa
                sair = true;
                return;
            case 1:
                Util.limparTela();
                Util.Logo();
                // Lógica para relatório de médicos com idade entre dois valores
                Console.WriteLine("Gerando relatório de médicos com idade entre dois valores...");
                consultorio.RelatorioMedicosEntre();
                Util.pausa();
                break;
            case 2:
                Util.limparTela();
                Util.Logo();
                // Lógica para relatório de pacientes com idade entre dois valores
                Console.WriteLine("Gerando relatório de pacientes com idade entre dois valores...");
                consultorio.RelatorioPacientesEntre();
                Util.pausa();
                break;
            case 3:
                Util.limparTela();
                Util.Logo();
                // Lógica para relatório de pacientes do sexo informado
                Console.WriteLine("Gerando relatório de pacientes pelo sexo informado...");
                consultorio.RelatorioPacienteSexo();
                Util.pausa();
                break;
            case 4:
                Util.limparTela();
                Util.Logo();
                // Lógica para relatório de pacientes em ordem alfabética
                Console.WriteLine("Gerando relatório de pacientes em ordem alfabética...");
                consultorio.RelatorioPacientesAlfabetico();
                Util.pausa();
                break;
            case 5:
                Util.limparTela();
                Util.Logo();
                // Lógica para relatório de pacientes cujos sintomas contenham texto informado
                Console.WriteLine("Gerando relatório de pacientes por sintomas...");
                consultorio.RelatorioPacienteSintoma();
                Util.pausa();
                break;
            case 6:
                Util.limparTela();
                Util.Logo();
                // Lógica para relatório de médicos e pacientes aniversariantes do mês informado
                Console.WriteLine("Gerando relatório de aniversariantes do mês...");
                consultorio.AniversariantesDoMes();
                Util.pausa();
                break;
            case 7:
                Util.limparTela();
                Util.Logo();
                // Lógica para relatório de atendimentos em aberto em ordem decrescente pela data de início
                Console.WriteLine("Gerando relatório de atendimentos em aberto...");
                consultorio.AtendimentosEmAberto();
                Util.pausa();
                break;
            case 8:
                Util.limparTela();
                Util.Logo();
                // Lógica para relatório de médicos em ordem decrescente da quantidade de atendimentos concluídos
                Console.WriteLine("Gerando relatório de médicos por quantidade de atendimentos...");
                consultorio.MedicosPorAtendimento();
                Util.pausa();
                break;
            case 9:
                Util.limparTela();
                Util.Logo();
                // Lógica para relatório de atendimentos cuja suspeita ou diagnóstico contenha determinada palavra
                Console.WriteLine("Gerando relatório de atendimentos por palavra chave...");
                consultorio.AtendimentosPorPalavra();
                Util.pausa();
                break;
            case 10:
                Util.limparTela();
                Util.Logo();
                // Lógica para relatório dos 10 exames mais utilizados nos atendimentos
                Console.WriteLine("Gerando relatório dos 10 exames mais utilizados...");
                consultorio.ExamesMaisUtilizados();
                Util.pausa();
                break;
            default:
                Util.limparTela();
                Util.Logo();
                NotificarOpcaoInvalida();
                Util.pausa();
                break;
        }
    }
}

#endregion

#region Menu Plano

public static void MenuPlano(Consultorio consultorio)
{
    bool sair = false;
    List<string> menu = new List<string>{
        "Inserir Plano", "Associar Plano a um Paciente", "Listar Planos"
    };

    while (!sair)
    {
        Util.limparTela();
        Util.Logo();
        Util.TituloMenu("Plano de Saude 🏥");
        Exibir(menu);
        int opcao = ObterOpcao(menu.Count);
        Console.Clear();

        // Declarando instância de App para chamar funcionalidades

        switch (opcao)
        {
            case 0:
                // Lógica para sair do programa
                sair = true;
                return;
            case 1:
                // Lógica para inserir um plano
                Util.limparTela();
                Util.Logo();
                // consultorio.AdicionarPlano();
                Util.pausa();
                break;
            case 2:
                // Lógica para associar um plano a um paciente
                Util.limparTela();
                Util.Logo();
                // consultorio.AssociarPlano();
                Util.pausa();
                break;
            case 3:
                // Lógica para listar os planos
                Util.limparTela();
                Util.Logo();
                // consultorio.ListarPlanos();
                Util.pausa();
                break; 
            default:
                Util.limparTela();
                Util.Logo();
                NotificarOpcaoInvalida();
                Util.pausa();
                break;
        }
    }
}

#endregion

#region utilitarios e validações
    public static void Exibir(List<string> menu)
    {
        for (int i = 0; i < menu.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {menu[i]}");
        }

        Console.WriteLine($"0 - Sair");
    }
    
    public static int ObterOpcao(int maxOpcao)
    {
        int opcao;
        Console.Write("Escolha uma opção: ");
        while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 0 || opcao > maxOpcao)
        {
            Console.WriteLine("Opção inválida. Escolha uma opção válida.");
            Console.Write("Escolha uma opção: ");
        }
        return opcao;
    }

    public static void NotificarOpcaoInvalida() {
        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
    }

    
}
#endregion

