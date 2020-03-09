using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    /*Ao criar uma exceção é sempre bom lembrar de seguira as convençoes como por exemplo
     ao final do nome sempre colocar o nome Exception.
     Para criar uma Exception é simples. Fazemosela herdartodas as caracteristicas da classe
     Exception.*/
    public class SaldoInsuficienteException:Exception
    {
        public double Saldo { get; }
        public double ValorSaque { get; }
        
        /*Criamos uma sobrecarga para serpossivel receber os parametrosdeste exceção
         o construtor abaixo que não há parametros é sempre criado por convenção. */
        public SaldoInsuficienteException()
        {
            
        }
            
        /*Retorna uma mensagem de erro quandoo Saldo é insuficiente. A palavra reservada
         "this", faz menção argumentos da propria classe. é pareceda coma palavrareservada "base", com a diferença
         que a"base" fazmenção a classe BASE ou seja a classe Pai*/

        public SaldoInsuficienteException(double saldo, double valorSaque) 
            : this("Tentadiva de saque no valor de " + valorSaque + " em uma conta com o saldo de " + saldo )
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }

        public SaldoInsuficienteException(string menssage) : base(menssage)
        {
            /**/
        }

    }
}
