using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDC_PUCMINAS_2019
{
    class Program
    {
            
       
        public static void Main(string[] args)
        {
            ImprimeCabecalho();
            int contTecladas = 0;
            ImprimeOpcoesMenu(0);
            ConsoleKeyInfo tecla;
            tecla = Console.ReadKey(true);

            while (tecla.Key != ConsoleKey.Enter)
            {
               

                if (tecla.Key == ConsoleKey.DownArrow)
                {
                    contTecladas++;                                                       
                    ImprimeOpcoesMenu(contTecladas);
                }

                if (tecla.Key == ConsoleKey.UpArrow)
                {
                    contTecladas--;                                                                         
                    ImprimeOpcoesMenu(contTecladas);
                }

                tecla = Console.ReadKey(true);
                
                if (contTecladas > ListaMenu().Count)
                {
                    contTecladas = ListaMenu().Count;
                }

                if (contTecladas < 0)
                {
                    contTecladas = -1;
                }

            }

            if (tecla.Key == ConsoleKey.Enter)
            {
              
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Você selecionou: ");
                Console.Clear();

                switch (contTecladas)
                {

                    case 0:                                       
                        Console.WriteLine(ListaMenu()[0]);
                        Console.WriteLine("__________________________\n ");
                        GanhoDeInformacao novoGanho = new GanhoDeInformacao();
                        novoGanho.CalculaGanho();
                        

                       Console.ReadKey();
                        return;
                       
                }
               
            }
        }


        public static List<string> ListaMenu()
        {
            List<string> opcoesdoMenu = new List<string>();
            opcoesdoMenu.Add("Cálculo do ganho de informação - Classificação");
            opcoesdoMenu.Add("op2");
            opcoesdoMenu.Add("op3");
            opcoesdoMenu.Add("op4");

            return opcoesdoMenu;
        }

        public static void ImprimeCabecalho()
        {
            Console.WriteLine("********************************************");
            Console.WriteLine("*        Rafaela Alves do Nascimento       *");
            Console.WriteLine("*            PUC MINAS 2019                *");
            Console.WriteLine("********************************************");

            Console.WriteLine("\n\nEscolha o que que deseja calcular:     ");
        }
        public static void ImprimeOpcoesMenu(int posDoIndicador)
        {
            Console.Clear();
            ImprimeCabecalho();
            List <string> menu  = ListaMenu();

            for (int i = 0; i < menu.Count; i++)
            {
                if (i == posDoIndicador)
                   {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" > " + (i + 1) + " - " + menu[i]);
                    Console.ResetColor();
                }
                else { 
                Console.WriteLine("     "+(i + 1) + " - " + menu[i]);
                }

              
            }
          
        }
    }
}
