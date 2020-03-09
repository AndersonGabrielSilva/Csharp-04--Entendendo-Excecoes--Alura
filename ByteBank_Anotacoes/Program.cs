using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ContaCorrente conta = new ContaCorrente(1612, 58479);
                ContaCorrente conta2 = new ContaCorrente(1612, 14985);

                conta.Depositar(200);     
                
                conta.Sacar(100);                

                conta.Transferir(5000,conta2);
                

            }
            catch(ArgumentException ex)
            {

                Console.WriteLine("Argumento com Problema " + ex.ParamName);
                Console.WriteLine("Ocorreu um erro do tipo ArgumentException");
                Console.WriteLine(ex.Message);
            }
            catch (SaldoInsuficienteException ex)
            {
                /*Neste momento é possivel acessaro estado da aplicação no momento da exceção */
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exceção do tipo saldo insuficiente");
                Console.WriteLine("Valor do saldo: " + ex.Saldo);
                Console.WriteLine("Valor do saque: " + ex.ValorSaque);

                Console.WriteLine(ex.StackTrace);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           //onsole.WriteLine(conta.Agencia);
           //onsole.WriteLine(conta.Numero);
           //onsole.WriteLine(ContaCorrente.TaxaDeOperacao);

            

            Console.ReadLine();
        }
    }
}
