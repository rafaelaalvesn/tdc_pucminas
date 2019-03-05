using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDC_PUCMINAS_2019
{
    /// <summary>
    /// Ganho de Informação de classificação
    /// </summary>
    class GanhoDeInformacao 
    {
       public struct Atributos
        {
          public string Nome;
          public double Valor;
        }

        public double CalculaEntropia(string tipoEntropia, int numAtributos)
        {
           
            double atributosPos, atributosNeg;
            int qntVariacoesAtributo = 0;
            double[] somatorioLogs;
            double total = 0;
            double resultado;

            if (tipoEntropia == "entropiaClasse")
            {
                Console.WriteLine("\n     1: Cálculo da Entropia da Classe: ");
                qntVariacoesAtributo = 1;

                Console.Write("\nQuantidade de saídas Positivas: ");
                Console.ForegroundColor = ConsoleColor.Green;
                atributosPos = int.Parse(Console.ReadLine());
                Console.ResetColor();

                Console.Write("Quantidade de saídas Negativas: ");
                Console.ForegroundColor = ConsoleColor.Red;
                atributosNeg = int.Parse(Console.ReadLine());
                Console.ResetColor();

                resultado = FormulaLog(atributosPos / numAtributos, atributosNeg / numAtributos);
                total = resultado;

                Console.Write("\nA entropia da Classe é: {0:n3}", total+"\n");
            }

            else if (tipoEntropia == "entropiaAtributo")
            {
                Console.WriteLine("\n\n     2: Cálculo da Entropia dos Atributos: \n");

              
                Console.Write("Quantidades de variações de respostas para o atributo: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                qntVariacoesAtributo = int.Parse(Console.ReadLine());
                Console.ResetColor();

                somatorioLogs = new double[qntVariacoesAtributo];

                for (int i = 0; i < qntVariacoesAtributo; i++)
                {
                   
                    Console.Write("\nQuantidade de saídas Positivas para o " + (i + 1) + "ª variação do atributo: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    atributosPos = int.Parse(Console.ReadLine());
                    Console.ResetColor();


                    Console.Write("Quantidade de saídas Negativas para o " + (i + 1) + "ª variação do atributo: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    atributosNeg = int.Parse(Console.ReadLine());
                    Console.ResetColor();

                    
                    double totalRespAtributoAtual = atributosPos + atributosNeg;

                    resultado = ((totalRespAtributoAtual / numAtributos) *
                    FormulaLog(atributosPos / totalRespAtributoAtual, atributosNeg / totalRespAtributoAtual));

                    somatorioLogs[i] = resultado;
                    total += somatorioLogs[i];

                     //PreencheListaDeAtributos(nomeAtributo, total);              
                }
            }
            return total;
        }



            public  List<Atributos> CalculaGanho()
        {

            Atributos atr = new Atributos();
            List<Atributos> listaAtributos = new List<Atributos>();

            double maiorValor = 0;
            string maiorValNome = "";

            Console.ResetColor();
            string nomeAtributo;
            double ganhoDeInfo;
            List<Atributos> ganhosAtributos = new List<Atributos>();
            
            Console.Write("Quantidade totais de instâncias: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int totalAtributos = int.Parse(Console.ReadLine());
            Console.ResetColor();

            double entropiaDaClasse = CalculaEntropia("entropiaClasse", totalAtributos);
            bool calculaGanho = true;


            do {

                Console.Write("\nNome do atributo: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                nomeAtributo = Console.ReadLine().ToUpper();
                Console.ResetColor();

                double entropiaAtributo = CalculaEntropia("entropiaAtributo", totalAtributos);
                ganhoDeInfo = entropiaDaClasse - entropiaAtributo;

                Console.WriteLine("\nA entropia do atributo é: {0:n3} ", entropiaAtributo);

                Console.WriteLine("\nO ganho de informação para o atributo "+nomeAtributo.ToUpper()+" é: {0:n3} ", ganhoDeInfo);
               
                Console.Write("\nCalcular o valor de outro atributo? (S/N): ");
                string resposta = Console.ReadLine().ToUpper();
                if (resposta == "S")
                {
                    calculaGanho = true;
                } else
                {
                    calculaGanho = false;
                }

                atr.Nome = nomeAtributo;
                atr.Valor = ganhoDeInfo;
                listaAtributos.Add(atr);

                for (var i = 0; i < listaAtributos.Count; i++)
                {
                    if (listaAtributos[i].Valor > maiorValor)
                    {

                        maiorValor = listaAtributos[i].Valor;
                        maiorValNome = listaAtributos[i].Nome;
                    }

                }



            } while (calculaGanho == true);
     

            Console.WriteLine("Maior valor: " + maiorValNome + " - {0:n3}" , maiorValor);
            Console.ReadKey();

            return listaAtributos;
        }


        /// <summary>
        /// Lembretes de cálculos para resolução a mão:
        /// Quando um dos valores é igual a 0 ou 1, significa que houve 100% de uma resposta
        /// e 0% de outra, ou seja, o nível de confusão das respostas = 0.
        /// O "formulaLog" será multiplicado pelo valor da propoção da quantidade de respostas
        /// e o número total de atributos.Se "formulaLog" = 0, a multiplicação será tb igual a 0
        /// logo, não é necessário calcular.
        /// </summary>
        /// <param name="vSim"></param>
        /// <param name="vNao"></param>
        /// <returns></returns>
        public double FormulaLog(double vSim, double vNao)
        {
            double formulaLog;

            if (vSim != 0 && vNao != 0)
            {
                formulaLog = (-1 * vSim * (Math.Log(vSim, 2)) +
                   (-1 * vNao * (Math.Log(vNao, 2))));
            }
            else formulaLog = 0;
            return formulaLog;
        }
    }
}

