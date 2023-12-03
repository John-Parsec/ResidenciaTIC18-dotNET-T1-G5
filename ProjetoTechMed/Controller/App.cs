using System;
class App{
    public List<Medico> Medicos => medicos;
    public List<Paciente> Pacientes => pacientes;

    private List<Medico> medicos = new List<Medico>();
    private List<Paciente> pacientes = new List<Paciente>();

    public void AdicionarMedico(){
        string nome;
        string cpf;
        string crm;
        DateTime dataNascimento;

        Console.WriteLine("--------Cadastro Medico--------");
        Console.Write("Digite o nome do médico: ");
        nome = Console.ReadLine()!;
        try{
            Console.Write("Digite a data de nascimento do médico: ");
            dataNascimento = DateTime.Parse(Console.ReadLine()!);
        }catch (Exception e){
            Console.WriteLine("Data de nascimento inválida!");
            return;
        }
        
        Console.Write("Digite o CPF do médico: ");
        cpf = Console.ReadLine()!;

        Console.Write("Digite o CRM do médico: ");
        crm = Console.ReadLine()!;

        try{
            Medico m = new Medico(nome, dataNascimento, cpf, crm);
        }catch (Exception e){
            Console.WriteLine(e.Message);
            return;
        }

        if(ExisteMedico(cpf, crm)){
            Console.WriteLine("Médico já cadastrado");
            return;
        }else{
            medicos.Add(new Medico(nome, dataNascimento, cpf, crm));
            Console.WriteLine("Médico cadastrado com sucesso");
        }
    }

    public bool ExisteMedico(string cpf, string crm){
        if(medicos.Count == 0)
            return false;
        try{
            Medico p = medicos.Find(p => p.CPF == cpf || p.CRM == crm);

            if(p.CPF == cpf || p.CRM == crm)
                return true;
            else
                return false;
        }catch (Exception e){
            return false;
        }
    }

    public void AdicionarPaciente(){
        string nome;
        string cpf;
        string sexo;
        DateTime dataNascimento;

        Console.WriteLine("--------Cadastro Paciente--------");
        Console.Write("Digite o nome do paciente: ");
        nome = Console.ReadLine()!;

        try{
            Console.Write("Digite a data de nascimento do paciente: ");
            dataNascimento = DateTime.Parse(Console.ReadLine()!);
        }catch (Exception e){
            Console.WriteLine("Data de nascimento inválida!");
            return;
        }
        
        Console.Write("Digite o CPF do paciente: ");
        cpf = Console.ReadLine()!;

        Console.Write("Digite o sexo do paciente (feminino/masculino): ");
        sexo = Console.ReadLine()!;

        try{
            Paciente p = new Paciente(nome, dataNascimento, cpf, sexo);
        }catch (Exception e){
            Console.WriteLine(e.Message);
            return;
        }

        if(ExistePaciente(cpf)){
            Console.WriteLine("Paciente já cadastrado!");
            return;
        }else{
            pacientes.Add(new Paciente(nome, dataNascimento, cpf, sexo));
            Console.WriteLine("Paciente cadastrado com sucesso!");
        }
    }

    public bool ExistePaciente(string cpf){
        if(pacientes.Count == 0)
            return false;
        try{
            Paciente p = pacientes.Find(p => p.CPF == cpf);
            if(p.CPF == cpf)
                return true;
            else
                return false;
        }catch (Exception e){
            return false;
        }
    }

    public void AdicionarSintoma(){
        string cpf;
        string sintoma;

        Console.WriteLine("--------Adicionar Sintoma--------");
        Console.Write("Digite o CPF do paciente: ");
        cpf = Console.ReadLine()!;

        if(!ExistePaciente(cpf)){
            Console.WriteLine("Paciente não cadastrado!");
            return;
        }

        Console.Write("Digite o sintoma: ");
        sintoma = Console.ReadLine()!;

        Paciente p = pacientes.Find(p => p.CPF == cpf);

        if (p.Sintomas.Contains(sintoma)){
            Console.WriteLine("Sintoma já cadastrado!");
            return;
        }else{
            p.AdicionarSintoma(sintoma);
            Console.WriteLine("Sintoma adicionado com sucesso!");
        }
    }

    public void RelatorioPacientesEntre(){
        int idadeInicio, idadeFim;

        try{
            Console.Write("Digite a idade inicial: ");
            idadeInicio = int.Parse(Console.ReadLine()!);
        }catch (Exception e){
            Console.WriteLine("Idade inválida!");
            return;
        }

        try{
            Console.Write("Digite a idade final: ");
            idadeFim = int.Parse(Console.ReadLine()!);
        }catch (Exception e){
            Console.WriteLine("Idade inválida!");
            return;
        }

        Console.WriteLine("\n--------Relatório Paciente Entre--------");

        List<Paciente> pacientesEntre = pacientes.FindAll(p => p.Idade >= idadeInicio && p.Idade <= idadeFim);
        if (pacientesEntre.Count == 0){
            Console.WriteLine("Nenhum paciente encontrado");
            return;
        }

        ImprimirPacientes(pacientesEntre);
    }

    public static void ImprimirPacientes(List<Paciente> pacientes){
        foreach (Paciente p in pacientes){
            Console.Write("Nome: " + p.Nome);
            Console.WriteLine(" | CPF: " + p.CPF);
            Console.WriteLine(" - Sexo: " + p.Sexo);
            Console.WriteLine(" - Idade: " + p.Idade);
            Console.WriteLine(" - Data de Nascimento: " + p.DataNascimento.ToLongDateString());
            Console.WriteLine(" - Sintomas: ");

            if (p.Sintomas.Count == 0){
                Console.WriteLine("\tNenhum sintoma cadastrado");
                continue;
            }else{
                foreach (string s in p.Sintomas){
                    Console.WriteLine("\t+ " + s);
                }
            }
        }
    }

    public void RelatorioMedicosEntre(){
        int idadeInicio, idadeFim;

        try{
            Console.Write("Digite a idade inicial: ");
            idadeInicio = int.Parse(Console.ReadLine()!);
        }catch (Exception e){
            Console.WriteLine("Idade inválida!");
            return;
        }

        try{
            Console.Write("Digite a idade final: ");
            idadeFim = int.Parse(Console.ReadLine()!);
        }catch (Exception e){
            Console.WriteLine("Idade inválida!");
            return;
        }

        Console.WriteLine("\n--------Relatório Médico Entre--------");

        List<Medico> medicosEntre = medicos.FindAll(m => m.Idade >= idadeInicio && m.Idade <= idadeFim);
        if (medicosEntre.Count == 0){
            Console.WriteLine("Nenhum médico encontrado");
            return;
        }

        ImprimirMedicos(medicosEntre);
    }

    public static void ImprimirMedicos(List<Medico> medicos){
        foreach (Medico m in medicos){
            Console.Write("Nome: " + m.Nome);
            Console.Write(" | CPF: " + m.CPF);
            Console.Write(" | CRM: " + m.CRM);
            Console.WriteLine(" | Data de Nascimento: " + m.DataNascimento.ToLongDateString());
            Console.WriteLine(" - Idade: " + m.Idade);
        }
    }

    public void RelatorioPacienteSexo(){
        int opc;
        string sexo;

        Console.WriteLine("1 - Feminino");
        Console.WriteLine("2 - Masculino");
        Console.Write("Digite a opção desejada: ");

        try{
            opc = int.Parse(Console.ReadLine()!);
        }catch (Exception e){
            Console.WriteLine("Opção inválida!");
            return;
        }

        if (opc == 1)
            sexo = "feminino";
        else
            sexo = "masculino";
    
        Console.WriteLine($"\n--------Relatório Paciente do Sexo {sexo}--------");
        List<Paciente> pacientesSexo = pacientes.FindAll(p => p.Sexo == sexo);
        if (pacientesSexo.Count == 0){
            Console.WriteLine("Nenhum paciente encontrado");
            return;
        }

        ImprimirPacientes(pacientesSexo);
    }

    public void RelatorioPacientesAlfabetico(){
        Console.WriteLine("--------Relatório Paciente--------");

        List<Paciente> pacientesOrdenados = pacientes.OrderBy(p => p.Nome).ToList();
        if (pacientesOrdenados.Count == 0){
            Console.WriteLine("Nenhum paciente encontrado");
            return;
        }

        ImprimirPacientes(pacientesOrdenados);
    }

    public void RelatorioPacienteSintoma(){
        string sintoma;

        Console.Write("Digite o sintoma: ");
        sintoma = Console.ReadLine()!;

        Console.WriteLine($"\n--------Relatório Paciente com '{sintoma}'--------");

        List<Paciente> pacientesSintoma = pacientes.FindAll(p => p.Sintomas.Contains(sintoma));
        if (pacientesSintoma.Count == 0){
            Console.WriteLine("Nenhum paciente encontrado");
            return;
        }

        ImprimirPacientes(pacientesSintoma);
    }

    public void AniversariantesDoMes(){
        Console.WriteLine("--------Relatório Aniversariantes do Mês--------");

        List<Paciente> pacientesAniversariantes = pacientes.FindAll(p => p.DataNascimento.Month == DateTime.Now.Month);
        List<Medico> medicosAniversariantes = medicos.FindAll(m => m.DataNascimento.Month == DateTime.Now.Month);
        
        Console.WriteLine("Médicos--------------------------");
        if (medicosAniversariantes.Count == 0){
            Console.WriteLine("Nenhum médico encontrado");
        }
        ImprimirMedicos(medicosAniversariantes);

        Console.WriteLine("\nPacientes------------------------");
        if (pacientesAniversariantes.Count == 0){
            Console.WriteLine("Nenhum paciente encontrado");
        }

        ImprimirPacientes(pacientesAniversariantes);
    }

}