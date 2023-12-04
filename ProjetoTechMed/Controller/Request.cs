using System;
using System.Collections;
class Request{
    static public App app =  new App();

#region Gerenciar Requisições do Usuario
    public static void InserirPaciente(){
        app.AdicionarPaciente();
    }
    public static void ListarPacientes(){

        app.ListaDePacientes();
    }
    public static void RemoverPaciente(){
        //implementar
    }

    public static void InserirMedico(){
        app.AdicionarMedico();
    }
    
#endregion
}