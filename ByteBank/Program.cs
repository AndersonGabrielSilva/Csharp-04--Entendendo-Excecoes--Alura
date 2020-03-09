﻿using System;
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
                
                //conta.Sacar(10000);                

                conta.Transferir(10000,conta2);
                

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
                Console.WriteLine(ex.StackTrace);

                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exceção do tipo saldo insuficiente");
                Console.WriteLine("Valor do saldo: " + ex.Saldo);
                Console.WriteLine("Valor do saque: " + ex.ValorSaque);               

            }
            catch(OperacaoFinanceiraException ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Informaçoes da INNER EXCPTION (exceção interna)");
                Console.WriteLine("Pego pela exceção Operação Financeira Exception");
               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Informaçoes da INNER EXCPTION (exceção interna)");

                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.InnerException.StackTrace);
            }
           

            

            Console.ReadLine();
        }
    }
}
