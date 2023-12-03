using System;
using System.Collections.Generic;

class Interface{
#region Menu Principal Do Sistema
   public static void App(){

        bool sair = false;
    
        List<string> menuPrincipal = new List<string>{"Menu Pacientes", "Menu Medicos", "Menu Atendimento", "Menu Relatorios", "Sair"};
    
        while (!sair)
        {
            Console.WriteLine("Sistema de Gerenciamento de Consultório Médico");

            Exibir(menuPrincipal);
            int opcao = ObterOpcao(menuPrincipal.Count); // Obtém uma opção válida para o menu
            
            switch (opcao)
            {
                case 1:
                    MenuPacientes();
                    break;
                case 2:
                    MenuMedicos();
                    break;
                case 3:
                    MenuAtendimento();
                    break;
                case 4:
                    MenuRelatorios();
                    break;
                case 5:
                    sair = true;
                    return;
            }
            
        }
        
}

#endregion

#region Menu Pacientes

  public static void MenuPacientes()
{
    bool sair = false;
    List<string> menu = new List<string>{ "Inserir Paciente", "Remover Paciente", "Listar Pacientes", "Sair"};
   
    while (!sair)
    {
        Console.WriteLine("Sistema de Gerenciamento de Consultório Médico");
        Console.WriteLine("Menu  Pacientes");
        
        Exibir(menu);
        int opcao = ObterOpcao(menu.Count);
        Console.Clear();
       
        switch (opcao)
        {
            case 1:
                // Lógica para inserir um paciente
                Console.WriteLine("Inserindo Paciente...");
                break;
            case 2:
                // Lógica para remover um paciente
                Console.WriteLine("Removendo Paciente...");
                break;
            case 3:
                 // Lógica para listar os pacientes
                Console.WriteLine("Listando Pacientes...");
                break;
            case 4:
                // Lógica para sair
                return;
        }
    }
    
}


#endregion

#region Menu Medicos
 public static void MenuMedicos()
{
    bool sair = false;
    List<string> menu = new List<string>{
        "Inserir Médico", "Remover Médico", "Listar Médicos", "Sair"
    };

    while (!sair)
    {
        Console.WriteLine("Sistema de Gerenciamento de Consultório Médico");
         Console.WriteLine("Menu Medicos");
        Exibir(menu);
        int opcao = ObterOpcao(menu.Count);;
       
        switch (opcao)
        {
            case 1:
                // Lógica para inserir um médico
                Console.WriteLine("Inserindo Médico...");
                break;
            case 2:
                // Lógica para remover um médico
                Console.WriteLine("Removendo Médico...");
                break;
            case 3:
                // Lógica para listar os médicos
                Console.WriteLine("Listando Médicos...");
                break;
            case 4:
                
                // Lógica para sair
                return;
            
        }

    }
    App();
}

#endregion

#region Menu Atendimento
   public static void MenuAtendimento(){
        bool sair = false;
        List<string> menu = new List<string>{
            "Inserir Novo Atendimento", "Listar Atendimentos", "Sair"
        };

        while (!sair)
        {
            Console.WriteLine("Sistema de Gerenciamento de Consultório Médico");
            Console.WriteLine("Menu Atendimento");
            Exibir(menu);
            int opcao = ObterOpcao(menu.Count);
            Console.Clear();
        
            switch (opcao)
            {
                case 1:
                    // Lógica para inserir um novo atendimento
                    Console.WriteLine("Inserindo Novo Atendimento...");
                    // Aqui você pode chamar uma função para inserir um novo atendimento
                    break;
                case 2:
                    // Lógica para listar os atendimentos
                    Console.WriteLine("Listando Atendimentos...");
                    // Aqui você pode chamar uma função para listar os atendimentos existentes
                    break;
                case 3:
                     // Lógica para sair
                    return;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        }
        App();
    }
#endregion

#region Menu Relatorios
    public static void MenuRelatorios()
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
        "Os 10 exames mais utilizados nos atendimentos",
        "Sair"
    };

    while (!sair)
    {
        Console.WriteLine("Sistema de Gerenciamento de Consultório Médico");
        Console.WriteLine("Menu Relatórios");
        Exibir(menu);
        int opcao = ObterOpcao(menu.Count);
        Console.Clear();
       
        switch (opcao)
        {
            case 1:
                // Lógica para relatório de médicos com idade entre dois valores
                Console.WriteLine("Gerando relatório de médicos com idade entre dois valores...");
                break;
            case 2:
                // Lógica para relatório de pacientes com idade entre dois valores
                Console.WriteLine("Gerando relatório de pacientes com idade entre dois valores...");
                break;
            case 3:
                // Lógica para relatório de pacientes do sexo informado
                Console.WriteLine("Gerando relatório de pacientes pelo sexo informado...");
                break;
            case 4:
                // Lógica para relatório de pacientes em ordem alfabética
                Console.WriteLine("Gerando relatório de pacientes em ordem alfabética...");
                break;
            case 5:
                // Lógica para relatório de pacientes cujos sintomas contenham texto informado
                Console.WriteLine("Gerando relatório de pacientes por sintomas...");
                break;
            case 6:
                // Lógica para relatório de médicos e pacientes aniversariantes do mês informado
                Console.WriteLine("Gerando relatório de aniversariantes do mês...");
                break;
            case 7:
                // Lógica para relatório de atendimentos em aberto em ordem decrescente pela data de início
                Console.WriteLine("Gerando relatório de atendimentos em aberto...");
                break;
            case 8:
                // Lógica para relatório de médicos em ordem decrescente da quantidade de atendimentos concluídos
                Console.WriteLine("Gerando relatório de médicos por quantidade de atendimentos...");
                break;
            case 9:
                // Lógica para relatório de atendimentos cuja suspeita ou diagnóstico contenha determinada palavra
                Console.WriteLine("Gerando relatório de atendimentos por palavra chave...");
                break;
            case 10:
                // Lógica para relatório dos 10 exames mais utilizados nos atendimentos
                Console.WriteLine("Gerando relatório dos 10 exames mais utilizados...");
                break;
            case 11:
                // Lógica para sair
                 // Lógica para sair
                return;
            default:
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
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
    }
    
    public static int ObterOpcao(int maxOpcao)
    {
        int opcao;
        Console.Write("Escolha uma opção: ");
        while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > maxOpcao)
        {
            Console.WriteLine("Opção inválida. Escolha uma opção válida.");
            Console.Write("Escolha uma opção: ");
        }
        return opcao;
    }
}
#endregion

