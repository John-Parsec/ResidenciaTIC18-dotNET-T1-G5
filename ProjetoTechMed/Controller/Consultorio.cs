using System.Data;

namespace AvaliacaoEquipe;
class Consultorio{
    public List<Medico> Medicos => medicos;
    public List<Paciente> Pacientes => pacientes;

    public List<Atendimento> Atendimentos => atendimentos;

    public List<PlanoSaude> Planos => planos;

    private List<Pagamento> pagamentos = new List<Pagamento>();

    private List<Medico> medicos =  new List<Medico>();
    private List<Paciente> pacientes = new List<Paciente>();

    private List<Atendimento> atendimentos = new List<Atendimento>();

    private List<PlanoSaude> planos = new List<PlanoSaude>();

#region Gerenciar Plano
    public void AdicionarPlano(){
        string titulo;
        double valor;

        Console.WriteLine("Digite o nome do Plano: ");
        titulo = Console.ReadLine()!;
        Console.WriteLine("Digite o valor do Plano: ");
        valor = double.Parse(Console.ReadLine()!);

        PlanoSaude novo_plano = new PlanoSaude(titulo,valor);
        planos.Add(novo_plano);

    }

    public void ListarPlanos(){
        foreach (var item in planos)
        {
            Console.WriteLine($"Plano: {item.Titulo}\n,Valor:{item.ValorMes}");
        }
    }
#endregion

#region  Gerencia de Medicos
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
        }catch (Exception){
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

    public bool RemoverMedico() {
        string crm = "";
        string cpf = "";
        Console.Write("Digite o CPF ou CRM do médico: ");
        string resposta = Console.ReadLine()!;
        if(resposta.Length == 11 && resposta.All(char.IsDigit)){
            cpf = resposta;
        }else{
            crm = resposta;
        }
        if(medicos.Count == 0)
            return false;

        try{
            Medico p = medicos.Find(p => p.CPF == cpf || p.CRM == crm)!;

            if(p.CPF == cpf || p.CRM == crm){
                // Verificar se o medico esta vinculado
                if(!p.Vinculo){
                    Console.WriteLine("Médico ja não é vinculado !!");
                    return false;
                }
                Console.WriteLine($"Deseja Realmente Desvincular o médico {p.Nome} ?(sim ou nao)");
                Console.WriteLine("OBS: Qualquer resposta que não seja sim, não irá Desvincular o Médico !!");
                Console.Write("Resposta: ");
                resposta = Console.ReadLine()!;
                if(resposta == "sim"){
                    p.Desvincular();
                    Console.WriteLine("Médico Desvinculado com sucesso !!");
                    return true;
                }
                Console.WriteLine("Operação cancelada pelo usuário !!");
                return false;
            }
            else{
                Console.WriteLine("Médico não encontrado !!");
                return false;
            }
        }catch (Exception){
            Console.WriteLine("Voce digitou algo errado ou Médico não encontrado !!");
            return false;
        }
    }

    public bool ExisteMedico(string cpf, string crm){
        if(medicos.Count == 0)
            return false;
        try{
            Medico p = medicos.Find(p => p.CPF == cpf || p.CRM == crm)!;

            if(p.CPF == cpf || p.CRM == crm){
                return true;
            }
            else
                return false;
        }catch (Exception){
            return false;
        }
    }

    public bool ExisteMedico(string crm){
        if(medicos.Count == 0)
            return false;
        try{
            Medico p = medicos.Find(p => p.CRM == crm)!;
            if(p.CRM == crm){
                return true;
            }
            else
                return false;
        }catch (Exception){
            return false;
        }
    }

    public void ListarPagamentosPorPaciente(Paciente paciente)
    {
        foreach(Pagamento pgmt in paciente.Pagamentos.ToList())
        {
                Console.Write("Tipo: " + pgmt.Tipo);
                Console.Write(" | Valor bruto: " + pgmt.ValorBruto);
                Console.Write(" | Descrição: " + pgmt.Descricao);
                Console.WriteLine(" | Desconto: " + pgmt.Desconto);
                Console.WriteLine(" - Data e hora: " + pgmt.DataHora.ToString("dd/MM/yyyy HH:mm:ss"));
        }
    }
    
    public void ListarMedicos(){
        ImprimirMedicos(medicos);
    }

    public static void ImprimirTodosMedicos(List<Medico> medicos){
        foreach (Medico m in medicos){
                Console.Write("Nome: " + m.Nome);
                Console.Write(" | CPF: " + m.CPF);
                Console.Write(" | CRM: " + m.CRM);
                Console.WriteLine(" | Data de Nascimento: " + m.DataNascimento.ToLongDateString());
                Console.WriteLine(" - Idade: " + m.Idade);
                Console.WriteLine($" - Vinculo: {(m.Vinculo ? "Vinculado" : "Desvinculado")}");
        }
    }
    public static void ImprimirMedicos(List<Medico> medicos){
        foreach (Medico m in medicos){
            if(m.Vinculo){
                Console.Write("Nome: " + m.Nome);
                Console.Write(" | CPF: " + m.CPF);
                Console.Write(" | CRM: " + m.CRM);
                Console.WriteLine(" | Data de Nascimento: " + m.DataNascimento.ToLongDateString());
                Console.WriteLine(" - Idade: " + m.Idade);
                Console.WriteLine($" - Vinculo: {(m.Vinculo ? "Vinculado" : "Desvinculado")}");
            }
        }
    }
# endregion

#region Relatorios da Atividade 1
    public void RelatorioMedicosEntre(){
        int idadeInicio, idadeFim;

        try{
            Console.Write("Digite a idade inicial: ");
            idadeInicio = int.Parse(Console.ReadLine()!);
        }catch (Exception){
            Console.WriteLine("Idade inválida!");
            return;
        }

        try{
            Console.Write("Digite a idade final: ");
            idadeFim = int.Parse(Console.ReadLine()!);
        }catch (Exception){
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

    public void RelatorioPacientesEntre(){
        int idadeInicio, idadeFim;

        try{
            Console.Write("Digite a idade inicial: ");
            idadeInicio = int.Parse(Console.ReadLine()!);
        }catch (Exception){
            Console.WriteLine("Idade inválida!");
            return;
        }

        try{
            Console.Write("Digite a idade final: ");
            idadeFim = int.Parse(Console.ReadLine()!);
        }catch (Exception){
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

    public void RelatorioPacienteSexo(){
        int opc;
        string sexo;

        Console.WriteLine("1 - Feminino");
        Console.WriteLine("2 - Masculino");
        Console.Write("Número da opção desejada: ");

        try{
            opc = int.Parse(Console.ReadLine()!);
        }catch (Exception){
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
        sintoma = sintoma.ToLower();

        Console.WriteLine($"\n--------Relatório Paciente com '{sintoma}'--------");

        List<Paciente> pacientesSintoma = pacientes.FindAll(p => p.Sintomas.Contains(sintoma));
        if (pacientesSintoma.Count == 0){
            Console.WriteLine("Nenhum paciente encontrado");
            return;
        }

        ImprimirPacientes(pacientesSintoma);
    }

#endregion

#region Gerencia de Pacientes
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
        }catch (Exception){
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

    public void RemoverPaciente() {
        // Verificar se há pacientes cadastrados antes de prosseguir
        if ( pacientes.Count == 0 ) 
        {
            Console.WriteLine($"Não há pacientes cadastrados no momento.");
        }
        else
        {
            string cpf;

            Console.Write("Digite o CPF do paciente: ");
            cpf = Console.ReadLine()!;

            if ( ExistePaciente(cpf) ) {
                Paciente paciente = pacientes.Find(item => item.CPF == cpf);
                
                pacientes.Remove(paciente);
                Console.WriteLine($"Paciente removido com sucesso!");
            }
            else {
                Console.WriteLine($"O paciente de CPF {cpf} não está cadastrado.");
            }
        }
    }

    public bool ExistePaciente(string cpf){
        if(pacientes.Count == 0)
            return false;
        try{
            Paciente? p = pacientes.Find(p => p.CPF == cpf)!;
            if(p.CPF == cpf)
                return true;
            else
                return false;
        }catch (Exception){
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

        Paciente p = pacientes.Find(p => p.CPF == cpf)!;

        if (p.Sintomas.Contains(sintoma)){
            Console.WriteLine("Sintoma já cadastrado!");
            return;
        }else{
            p.AdicionarSintoma(sintoma);
            Console.WriteLine("Sintoma adicionado com sucesso!");
        }
    }


    public static void ImprimirPacientes(List<Paciente> pacientes){
        foreach (Paciente p in pacientes){
            Console.Write("Nome: " + p.Nome);
            Console.WriteLine(" | CPF: " + p.CPF);
            Console.WriteLine(" - Sexo: " + p.Sexo);
            Console.WriteLine(" - Idade: " + p.Idade);
            Console.WriteLine(" - Plano: " + p.Plano.Titulo);
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

    public void ListaDePacientes(){
       ImprimirPacientes(pacientes);
    }

# endregion


#region  Relatorio de Medicos e Pacientes Aniversariantes
    public void AniversariantesDoMes(){
        int mes = 0;
        bool flag;

        Console.WriteLine("--------Relatório Aniversariantes do Mês--------");

        try {
            do {
                Console.Write("Digite o mês (em número): ");
                mes = int.Parse(Console.ReadLine()!);
                flag = true;

                if ( mes < 1 || mes > 12 ) {
                    Console.WriteLine($"Insira um mês válido, entre 1 e 12.");
                    flag = false;
                }
            } while ( !flag );
        } 
        catch (Exception) {
            Console.WriteLine($"Insira um número.");
            return;
        }
        
        List<Paciente> pacientesAniversariantes = pacientes.FindAll(p => p.DataNascimento.Month == mes);
        List<Medico> medicosAniversariantes = medicos.FindAll(m => m.DataNascimento.Month == mes);
        
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
#endregion

#region Gerenciar de Atendimentos

    //Adicionar Exame
    public void AdicionarExame(){
        string cpf;
        string crm;
        string nomeExame;
        string descricao;
        string resultado;
        string local;
        float valor;

        Console.WriteLine("--------Adicionar Exame--------");
        Console.Write("Digite o CPF do paciente: ");
        cpf = Console.ReadLine()!;

        if(!ExistePaciente(cpf)){
            Console.WriteLine("Paciente não cadastrado!");
            return;
        }

        Console.Write("Digite o CRM do médico: ");
        crm = Console.ReadLine()!;

        if(!ExisteMedico(cpf, crm)){
            Console.WriteLine("Médico não cadastrado!");
            return;
        }

        int index = atendimentos.FindIndex(a => a.Paciente.CPF == cpf && a.Responsavel.CRM == crm);

        if (index == -1){
            Console.WriteLine("Atendimento não encontrado!");
            return;
        }

        if (atendimentos[index].DataFim != DateTime.MinValue){
            Console.WriteLine("Atendimento já finalizado!");
            return;
        }

        Console.Write("Digite o titulo do Exame: ");
        nomeExame = Console.ReadLine()!;

        Console.Write("Digite a descrição do Exame: ");
        descricao = Console.ReadLine()!;

        Console.Write("Digite o local do Exame: ");
        local = Console.ReadLine()!;

        try{
            Console.Write("Digite o valor do Exame: ");
            valor = float.Parse(Console.ReadLine()!);
        }catch (Exception){
            Console.WriteLine("Valor inválido!");
            return;
        }
        
        Console.Write("Digite o resultado do exame: ");
        resultado = Console.ReadLine()!;


        Exame exame = new Exame(nomeExame, valor, descricao, local);
        atendimentos[index].AdicionarExame(exame, resultado);
        Console.WriteLine("Exame adicionado com sucesso!");
    }
    

    public void ListarAtendimentos(){
        ListarAtendimentos(atendimentos);
    }
    public void ListarAtendimentos(List<Atendimento> listaAtendimentos){
        // Exibindo os atendimentos
        foreach (var atendimento in listaAtendimentos){
            Console.WriteLine($"Data de Início: {atendimento.DataInicio}");
            Console.WriteLine($"Suspeita: {atendimento.Suspeita}");
            Console.WriteLine($"Médico Responsável: {atendimento.Responsavel.Nome}");
            Console.WriteLine($"Paciente: {atendimento.Paciente.Nome}");
            Console.WriteLine($"Valor Total: {atendimento.ValorTotal}");

            if (atendimento.Diagnostico == "") {
                Console.WriteLine($"Data de Fim: Não finalizado");
                Console.WriteLine($"Diagnóstico: Não concluído");
            } else {
                Console.WriteLine($"Data de Fim: {atendimento.DataFim}");
                Console.WriteLine($"Diagnóstico: {atendimento.Diagnostico}");
            }
            Console.WriteLine(" - Exames: ");

            if (atendimento.Exames.Count == 0){
                Console.WriteLine("\tNenhum exame cadastrado");
                continue;
            } else {
                foreach ((Exame exame, string resultado) in atendimento.Exames){
                    Console.WriteLine("\t+ " + exame.Nome);
                    Console.WriteLine("\t\t- Resultado: " + resultado);
                }
            }
            Console.WriteLine("\n");
        }
    }
    public void AdicionarAtendimento(){
        DateTime dataInicio;
        Console.WriteLine("-------- Cadastro de Atendimento --------");

        try{
            Console.Write("Informe a data de início do atendimento: ");
            dataInicio = DateTime.Parse(Console.ReadLine()!);
        }catch (Exception){
            Console.WriteLine("Data de início inválida.");
            return;
        }

        Console.Write("Informe a suspeita do atendimento: ");
        string suspeita = Console.ReadLine()!;

        Console.Write("Informe o CRM do médico responsável: ");
        string crmMedico = Console.ReadLine()!;

        if(!ExisteMedico(crmMedico)){
            Console.WriteLine("Médico não cadastrado!");
            return;
        }

        Console.Write("Informe o CPF do paciente: ");
        string cpfPaciente = Console.ReadLine()!;

        if(!ExistePaciente(cpfPaciente)){
            Console.WriteLine("Paciente não cadastrado!");
            return;
        }
    
        Medico medicoResponsavel = medicos.Find(m => m.CRM == crmMedico)!;
        Paciente paciente = pacientes.Find(p => p.CPF == cpfPaciente)!;
      
        Atendimento novoAtendimento = new Atendimento(dataInicio, suspeita, medicoResponsavel, paciente);
        atendimentos.Add(novoAtendimento);

        Console.WriteLine("Atendimento adicionado com sucesso.");
    }

    public void FinalizarAtendimento(){
            Console.WriteLine("-------- Finalizar Atendimento por Nome do Paciente --------");

            Console.Write("Informe o nome do paciente para finalizar o atendimento: ");
            string nomePaciente = Console.ReadLine()!;

            Atendimento atendimentoFinalizar = atendimentos.FirstOrDefault(a => a.Paciente.Nome.Equals(nomePaciente, StringComparison.OrdinalIgnoreCase))!;

            if (atendimentoFinalizar == null){
                Console.WriteLine($"Atendimento para o paciente {nomePaciente} não encontrado. Não é possível finalizar.");
                return;
            }

            if (atendimentoFinalizar.DataFim != DateTime.MinValue){
                Console.WriteLine("Atendimento já finalizado anteriormente.");
                return;
            }

            Console.Write("Informe o diagnóstico para o atendimento: ");
            string diagnostico = Console.ReadLine()!;
          
            atendimentoFinalizar.FinalizarAtendimento(diagnostico);

            Console.WriteLine("Atendimento finalizado com sucesso.");
        }   

       public void EditarAtendimento()
        {
            Console.WriteLine("-------- Edição de Atendimento por Nome do Paciente --------");
   
            Console.Write("Informe o nome do paciente para editar o atendimento: ");
            string nomePaciente = Console.ReadLine()!;

            Atendimento atendimentoEditar = atendimentos.FirstOrDefault(a => a.Paciente.Nome.Equals(nomePaciente, StringComparison.OrdinalIgnoreCase))!;

            if (atendimentoEditar == null)
            {
                Console.WriteLine($"Atendimento para o paciente {nomePaciente} não encontrado. Não é possível editar.");
                return;
            }

            Console.Write("Informe a nova data de início do atendimento: ");
            DateTime novaDataInicio = DateTime.Parse(Console.ReadLine()!);

            Console.Write("Informe a nova suspeita do atendimento: ");
            string novaSuspeita = Console.ReadLine()!;

            atendimentoEditar.DataInicio = novaDataInicio;
            atendimentoEditar.Suspeita = novaSuspeita;

            Console.WriteLine("Atendimento editado com sucesso.");
        }


    #region  Relatorio de Atendimentos
    public void AtendimentosEmAberto(){
        Console.WriteLine("--------Relatório Atendimentos em Aberto--------");

        List<Atendimento> atendimentosEmAberto = atendimentos.FindAll(a => a.DataFim == DateTime.MinValue);
        if (atendimentosEmAberto.Count() == 0){
            Console.WriteLine("Nenhum atendimento aberto encontrado");
            return;
        }else{
            atendimentosEmAberto = atendimentosEmAberto.OrderByDescending(a => a.DataInicio).ToList();
            ListarAtendimentos(atendimentosEmAberto);
        }
    }

    public void MedicosPorAtendimento(){
        Console.WriteLine("--------Relatório Médicos por Atendimento--------");

        var result = from medico in medicos
                        join atendimento in atendimentos on medico equals atendimento.Responsavel
                        where atendimento.DataFim != DateTime.MinValue
                        group atendimento by medico into grupo
                        orderby grupo.Count() descending
                        select new
                        {
                            Medico = grupo.Key,
                            QuantidadeAtendimentosFinalizados = grupo.Count()
                        };

        if (result.Count() == 0){
            Console.WriteLine("Nenhum médico encontrado");
            return;
        }

        foreach (var item in result){
            Console.WriteLine("Nome: " + item.Medico.Nome);
            Console.WriteLine(" - Quantidade de Atendimentos: " + item.QuantidadeAtendimentosFinalizados);
        }
    }

    public void AtendimentosPorPalavra(){
        string palavra;

        Console.Write("Digite a palavra: ");
        palavra = Console.ReadLine()!;
        palavra = palavra.ToLower();

        Console.WriteLine($"\n--------Relatório Atendimentos com '{palavra}'--------");

        List<Atendimento> atendimentosPalavra = atendimentos.FindAll(a => a.Suspeita.Contains(palavra) || a.Diagnostico.Contains(palavra));
        if (atendimentosPalavra.Count == 0){
            Console.WriteLine("Nenhum atendimento encontrado");
            return;
        }

        for (int i = 0; i < atendimentosPalavra.Count; i++){
            Console.WriteLine($"Atendimento {i+1}");
            Console.WriteLine(" - Data de Início: " + atendimentosPalavra[i].DataInicio.ToLongDateString());
            Console.WriteLine(" - Médico Responsável: " + atendimentosPalavra[i].Responsavel.Nome);
            Console.WriteLine(" - Paciente: " + atendimentosPalavra[i].Paciente.Nome);
            Console.WriteLine(" - Suspeita: " + atendimentosPalavra[i].Suspeita);
            Console.WriteLine(" - Valor Total: " + atendimentosPalavra[i].ValorTotal);
            Console.WriteLine(" - Exames: ");

            if (atendimentosPalavra[i].Exames.Count == 0){
                Console.WriteLine("\tNenhum exame cadastrado");
                continue;
            }else{
                foreach ((Exame exame, string resultado) in atendimentosPalavra[i].Exames){
                    Console.WriteLine("\t+ " + exame.Nome);
                    Console.WriteLine("\t\t- Resultado: " + resultado);
                }
            }
        }
    }

    public void ExamesMaisUtilizados(){
        Console.WriteLine("--------Relatório Exames Mais Utilizados--------");

        var result = atendimentos.SelectMany(atendimento => atendimento.Exames)
            .GroupBy(exame => exame.Item1.Nome)
            .OrderByDescending(grupo => grupo.Count())
            .Take(10)
            .Select(grupo => new
            {
                Exame = grupo.Key,
                Quantidade = grupo.Count()
            });

        if (result.Count() == 0){
            Console.WriteLine("Nenhum exame encontrado");
            return;
        }

        foreach (var item in result){
            Console.WriteLine("Nome: " + item.Exame);
            Console.WriteLine(" - Quantidade de Atendimentos: " + item.Quantidade);
        }
    }
    #endregion

    # region Plano
    public void AssociaPlano(){
        Console.WriteLine("--------Associação de Plano--------");
        System.Console.WriteLine("Digite o CPF do paciente: ");
        string cpf = Console.ReadLine()!;

        if(!ExistePaciente(cpf)){
            Console.WriteLine("Paciente não cadastrado!");
            return;
        }

        System.Console.WriteLine("Digite o nome do plano: ");
        string nomePlano = Console.ReadLine()!;

        var plano = planos.Find(p => p.Titulo == nomePlano)!;

        if (plano == null){
            Console.WriteLine("Plano não encontrado!");
            return;
        }else{
            int index = pacientes.FindIndex(p => p.CPF == cpf)!;
            pacientes[index].AdicionarPlano(plano);
            Console.WriteLine("Plano associado com sucesso!");
        }
    }

    # endregion

    # region Pagamento

    public void AdicionarPagamento(){
        int tipo;
        Console.WriteLine("--------Adicionar Pagamento--------");
        Console.Write("Digite o CPF do paciente: ");
        string cpf = Console.ReadLine()!;

        if(!ExistePaciente(cpf)){
            Console.WriteLine("Paciente não cadastrado!");
            return;
        }

        int index = pacientes.FindIndex(p => p.CPF == cpf)!;

        var valor = pacientes[index].Plano.ValorMes;

        Console.WriteLine("1. Cartão de Credito");
        Console.WriteLine("2. Boleto");
        Console.WriteLine("3. Dinheiro");

        Console.Write("Digite o tipo de pagamento: ");
        try{
            tipo = int.Parse(Console.ReadLine()!);

            if (tipo < 1 || tipo > 3){
                Console.WriteLine("Tipo de pagamento inválido!");
                throw new Exception();
            }
        }catch (Exception){
            Console.WriteLine("Tipo de pagamento inválido!");
            return;
        }

        Console.Write("Digite o desconto: ");
        double desconto;
        try{
            desconto = double.Parse(Console.ReadLine()!);
        }catch (Exception){
            Console.WriteLine("Desconto inválido!");
            desconto = 0;
        }
        

        Pagamento pagamento;
        if (tipo == 1)
            pagamento = new Pagamento("cartao", valor, $"Pagamento {pacientes[index].Pagamentos.Count}", desconto);
        else if (tipo == 2)
            pagamento = new Pagamento("boleto", valor, $"Pagamento {pacientes[index].Pagamentos.Count}", desconto);
        else
            pagamento = new Pagamento("dinheiro", valor, $"Pagamento {pacientes[index].Pagamentos.Count}", desconto);
        
        pacientes[index].AdicionarPagamento(pagamento);


    }

    # endregion

#endregion
}
