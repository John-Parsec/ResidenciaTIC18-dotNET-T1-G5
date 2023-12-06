using AvaliacaoEquipe;
using System.Globalization;

 class Program {
      static void Main(string[] args){
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR"); // Definição da cultura
            Consultorio consultorio = new Consultorio();     
            Interface.App(consultorio);
      }
}