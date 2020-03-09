// using _05_ByteBank;

using System;

namespace ByteBank
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }

        public static double TaxaDeOperacao { get; set; }
       

        public static int TotalDeContasCriadas { get; private set; }

        private readonly int _agencia;
        private readonly int _numero;
        public int ContadorSaquesNaoPermtidos { get; private set; }
        public int ContadorTransferenciasNãoPermitidas { get; set; }
        public int Agencia{ get; }
        public int Numero{ get; }
            

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        public ContaCorrente(int numeroAgencia, int numeroConta)
        {
            Agencia = numeroAgencia;
            Numero = numeroConta;
            if (numeroAgencia <= 0)
            {

                ArgumentException excecao = new ArgumentException("A Agencia  deve ser maiores que 0 no Argumento " + nameof(numeroAgencia));
                throw excecao;                 
            }
            if (numeroConta <= 0)
            {
                ArgumentException excecao = new ArgumentException("O Numero deve ser maior que 0 no Argumento " + nameof(numeroConta));
                throw excecao;
            }
            TotalDeContasCriadas++;

            TaxaDeOperacao = 30 / TotalDeContasCriadas;

        }


        public void Sacar(double valor)
        {                        
            if (valor < 0)
            {
                ContadorSaquesNaoPermtidos++;
                throw new ArgumentException("Valor Invalido para o saque.", nameof(valor));
            }
                     
            if (_saldo < valor)
            {
                throw new SaldoInsuficienteException(Saldo,valor);
            }

            _saldo -= valor;
           
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public void Transferir(double valor, ContaCorrente contaDestino)            
        {
            
            if (valor < 0)
            {                                
                throw new ArgumentException("Valor Invalido para a transferencia. ", nameof(valor));
            }
            
            try
            {
            Sacar(valor);
            }

            catch(SaldoInsuficienteException ex )
            {
                ContadorTransferenciasNãoPermitidas++;

                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }
            
            contaDestino.Depositar(valor);
           
        }
    }
}
