using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_TratamentoDeErros
{
    class Program
    {
        //EXERCICIO

        /*Uma forma muito mais limpa de tratar exceções é com o uso dos blocos try/catch,
         * em oposição a retornar códigos de erro/sucesso em todos os seus métodos.*/

        //Verifique o código abaixo:

        //*Note que o Metodo_1 possui um bloco try/catch. Qual será a saída na console após a chamada do Metodo_1?

        /*RESPOSTA 
         * Correta! Na divisão numero / divisor haverá uma exceção que irá encerrar abruptamente o Metodo_3 e o 
         * Metodo_2, até chegar no Metodo_1 com o bloco catch tratando as exceções do tipo DivideByZeroException.
         
         * Quando o compilador iniciar a execução do Main e encontra o Metodo_1 ele começa a executar o mesmo
         * e irá printar M1: Inicio
         * e logo aopos irá começar a execução do Metodo_2 e printa M2:Inicio
         * e logo apos irá começao a execução do metodo_3 e já printa na tela M3: Inicio
         * ao encontrar o erro DivideByZeroException (Imposivel difidir por zero) a execucao é 
         *encerrada no mesmo instante e automaticamente ele começa a transmitir este erro
         * para a pilha que vai voltando item por item até chegar no Metodo_1 que encontra aonde
         * este erro é tratado. Executa o tratamento e volta a execultar apartir da linha que o tratamento foi tratado
         * neste exemplo no metodo_1.
         * logo apos encerrar este trataemento printa M1: Fim         
         */

        static void Main(string[] args)
        {
            Console.WriteLine("\t\t----EXERCICIO----");
            Metodo_1();
            Console.ReadLine();
        }
        private static void Metodo_1()
        {
            Console.WriteLine("M1: Início");

            try
            {
                Metodo_2();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("catch(DivideByZeroException)");
            }
            Console.WriteLine("M1: Fim");
        }

        private static void Metodo_2()
        {
            Console.WriteLine("M2: Início");
            Metodo_3();
            Console.WriteLine("M2: Fim");
        }

        private static void Metodo_3()
        {
            Console.WriteLine("M3: Início");

            int numero = 10;
            int divisor = 0;
            int resultado = numero / divisor;

            Console.WriteLine("M3: Fim");
        }
    }
}
