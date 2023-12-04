using System;

 class Program {
    static void Main(string[] args)
    {
          Interface.App();
    }
}

// using System;
// using System.Globalization;
// using System.Reflection.Emit;

// CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

// App app = new App();
// int opc = -1;

// do{
//     Console.WriteLine("--------Menu--------");
//     Console.WriteLine("1 - Cadastrar Médico");
//     Console.WriteLine("2 - Cadastrar Paciente");
//     Console.WriteLine("3 - Adicionar Sintoma");
//     Console.WriteLine("4 - Relatorio pacientes por idade");
//     Console.WriteLine("5 - Relatorio medicos por idade");
//     Console.WriteLine("6 - Relatorio pacientes por sexo");
//     Console.WriteLine("7 - Relatorio pacientes por ordem alfabética");
//     Console.WriteLine("8 - Relatorio pacientes por sintoma");
//     Console.WriteLine("9 - Relatorio Aniversariantes do mês");
//     Console.WriteLine("0 - Sair");

//     do{
//         try{
//             Console.Write("Digite a opção: ");
//             opc = int.Parse(Console.ReadLine()!);
//         }catch (Exception e){
//             Console.WriteLine("Opção inválida");
//             opc = -1;
//         }
//     }while(opc < 0 || opc > 9);

//     Console.WriteLine();
//     switch(opc){
//         case 1:
//             app.AdicionarMedico();
//             break;
//         case 2:
//             app.AdicionarPaciente();
//             break;
//         case 3:
//             app.AdicionarSintoma();
//             break;
//         case 4:
//             app.RelatorioPacientesEntre();
//             break;
//         case 5:
//             app.RelatorioMedicosEntre();
//             break;
//         case 6:
//             app.RelatorioPacienteSexo();
//             break;
//         case 7:
//             app.RelatorioPacientesAlfabetico();
//             break;
//         case 8:
//             app.RelatorioPacienteSintoma();
//             break;
//         case 9:
//             app.AniversariantesDoMes();
//             break;
//         case 0:
//             Console.WriteLine("Saindo...");
//             break;
//         default:
//             Console.WriteLine("Opção inválida");
//             break;
//     }
//     Console.ReadLine();

// }while(opc != 0);
