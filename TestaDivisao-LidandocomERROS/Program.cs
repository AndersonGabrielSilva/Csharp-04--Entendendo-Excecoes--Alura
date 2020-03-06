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
            /*No "try" eu digo para o compilador, tente execultar este bloco de codigo aqui
             * caso caia em alguma exceção faça isto e assim acaba caindo no "catch"*/
            try
            {
                int resultado = Dividir(10, divisor);
                Console.WriteLine("Resultado da divisão de 10 por " + divisor + " é " + resultado);
            }

            /*O que ocorre no "catch"?
             * Caso o bloco "try" não for execultado com sucesso, o compilador retorna o erro
             * aonde este erro sera tradado no catch.
             * No C# os erros são tratados como objetos, que são nada mais do que aquela mensagem 
             * que aparece no bloco de exeção EX: System.ByZero.Exception....
             * No "catch" eu recebo este erro, ou melhor este objeto que o compilador me retornou
             * e informo qual o tipo de tratamento eu devo dar a este erro
             */
            catch (DivideByZeroException erro)
            {
                Console.WriteLine(erro.Message);//Mensagem do Objeto
                Console.WriteLine(erro.StackTrace);//Stack = Pilha / Trace = Rastro / Contem o rastro do erro
               // Console.WriteLine(erro. );
                Console.WriteLine("Não é possivel fazer uma divisão por zero!");

            }           
                                                               
        }

        private static int Dividir(int numero, int divisor)
        {
            //Reproduzindo a Exeção de quando o objeto é nulo
            ContaCorrente conta = null;
            Console.WriteLine(conta.Saldo);
            return numero / divisor;
        }
    }
}
