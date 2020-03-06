using ByteBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestaDivisao_LidandocomERROS
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Metodo();
            }
            catch (NullReferenceException error)
            {
                Console.WriteLine(error.Message);
                Console.WriteLine(error.StackTrace);
                Console.WriteLine("Aconteceu um erro");
            }
             

            Console.ReadLine();
        }
        //Teste com a cadeia de chamada:
        //Metodo -> TestaDivisao -> Dividir
        private static void Metodo()
        {
            TestaDivisao(0);
            //TestaDivisao(2);
        }

        private static void TestaDivisao(int divisor)
        {
            int resultado = Dividir(10, divisor);
            Console.WriteLine("Resultado da divisão de 10 por " + divisor + " é " + resultado);
        }

        private static int Dividir(int numero, int divisor)
        {
            //Reproduzindo a Exeção de quando o objeto é nulo
            ContaCorrente conta = null;
            //Console.WriteLine(conta.Saldo);
            return numero / divisor;
        }
    }
}
