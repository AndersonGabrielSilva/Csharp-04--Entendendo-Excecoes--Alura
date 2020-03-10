using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestaInnerExecption(); 
            try
            {
                CarregarContas();
            }
            catch (Exception)
            {
                Console.WriteLine("EXECEÇÃO CAPTURADA PELO MAIN");
            }

            Console.ReadLine();
        }

        private static void CarregarContas()
        {
            /*Para ultitizar o "using" a classe LeitorDeArquivo necessita implementar a interface IDisposable */
            using (LeitorDeArquivo leitor = new LeitorDeArquivo("texte.txt"))
            {

                //IDisposable
                leitor.LerProximaLinha();
            }

            //--------------------------------------------------------------------------------------------------

            //LeitorDeArquivo leitor = null;
            //try
            //{
            //    leitor = new LeitorDeArquivo("contas.txt");
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();

            //}
            //catch (IOException ex)
            //{
            //    Console.WriteLine("Excecão do tipo IOException, capturada e tratada!");
            //    Console.WriteLine(ex.Message);
            //}
            //finally/*Seráexecultado sempre, mesmo secairdo bloco "try" ou "catch"*/
            //{
            //    if (leitor != null) 
            //    { 
            //        leitor.Fechar();
            //    }                
            //}
        }

        private static void TestaInnerExecption()
        {
            try
            {
                ContaCorrente conta = new ContaCorrente(1612, 58479);
                ContaCorrente conta2 = new ContaCorrente(1612, 14985);

                conta.Depositar(200);

                //conta.Sacar(10000);                

                conta.Transferir(10000, conta2);


            }
            catch (ArgumentException ex)
            {

                Console.WriteLine("Argumento com Problema " + ex.ParamName);
                Console.WriteLine("Ocorreu um erro do tipo ArgumentException");
                Console.WriteLine(ex.Message);
            }
            catch (SaldoInsuficienteException ex)
            {
                /*Neste momento é possivel acessaro estado da aplicação no momento da exceção */
                Console.WriteLine(ex.StackTrace);

                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exceção do tipo saldo insuficiente");
                Console.WriteLine("Valor do saldo: " + ex.Saldo);
                Console.WriteLine("Valor do saque: " + ex.ValorSaque);

            }
            catch (OperacaoFinanceiraException ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Informaçoes da INNER EXCPTION (exceção interna)");
                Console.WriteLine("Pego pela exceção Operação Financeira Exception");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Informaçoes da INNER EXCPTION (exceção interna)");

                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.InnerException.StackTrace);
            }
        }
    }
}
