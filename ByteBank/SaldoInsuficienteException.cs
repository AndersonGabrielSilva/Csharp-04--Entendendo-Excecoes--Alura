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
    public class SaldoInsuficienteException:OperacaoFinanceiraException
    {
        public double Saldo { get; }
        public double ValorSaque { get; }
                
        public SaldoInsuficienteException()
        {
            
        }            
      
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

        /*Por mais que não é preciso criar este construtorfaz parte de uma boa pratica*/
        public SaldoInsuficienteException(string mensagembox, Exception exception)
        {

        }

    }
}
