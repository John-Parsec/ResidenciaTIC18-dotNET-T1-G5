namespace Utils;

public class Util
{
    public static void limparTela(){
        Console.Clear();
    }
    public static void pausa(){
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    public static void Logo(){
        Console.WriteLine($"    Sistema de Gerenciamento de Consultório Médico 🏥 \n");
    }

    public static void TituloMenu(string titulo){
        Console.WriteLine($"📋 Menu {titulo} \n");
    }
}
