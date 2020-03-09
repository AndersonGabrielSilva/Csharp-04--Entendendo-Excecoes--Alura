// using _05_ByteBank;

using System;

namespace ByteBank
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }

        public static double TaxaDeOperacao { get; set; }
       

        public static int TotalDeContasCriadas { get; private set; }

        /*A palavra reservada "readonly" é ultilaza para somente leitura
         * impossibiliando que o dado seja alterado durante a execução da aplicação
         * o valor somenteé informado construção do objeto*/
        private readonly int _agencia;
        private readonly int _numero;
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

        //Construtor da Conta Corrente
        public ContaCorrente(int numeroAgencia, int numeroConta)
        {
            /*Com o "throw" podemos retornar uma excecao, porem ele somente pode ser usado
                 para blocos "catch" uma das opçoes é instanciaruma nova insatncia da excecao
                 como o exemplo abaixo. Eu estidou dizendo que estou retornando uma excecão que estou
                 criando agora.

                 EXEMPLO: throw new Excepion(); */

            /*Eu consigo tamem alterar o valor damensagem interna do objeto Excecão
             * simplesmente passando a mensagem para o construtor, desta forma a exceção
             * retorna exatamente a mensagem que eu escolhi*/
            //Exception excecao = new Exception("A Agencia e o Numero devem sermaior que 0");


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

            //Quanto mais contas, ou seja quanto mais for incrementando o Total de Contas Criadas
            //Menor será a taxa desta conta corrente
            TaxaDeOperacao = 30 / TotalDeContasCriadas;

        }


        public void Sacar(double valor)
        {

            /*Caso o valor a ser sacado seja menor que zero. Será pego na condição a baixo 
             * e retorara a execção "ArgumentException" aondeé retornado ao main o tipo da 
             exceção e da variavel que aonde ocorreu aexceção */
            if (valor < 0)
            {
                throw new ArgumentException("Valor Invalido para o saque.", nameof(valor));
            }

            /*Se o valor a ser retirado for maior que o valorcontido na conta, ouseja na variavel "Saque"
             è retornado ao main uma exceção do tipo "SaldoInsuficienteExcption" qu foi criada pelo desenvolvedor
             para tratar este erro.*/
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
            /*Ao tentar sacar um valor menorque zero, irá cair na exceção abaixo aonde é verificado de o valor aser trandferido
             * é menor que 0*/
            if (valor < 0)
            {
                throw new ArgumentException("Valor Invalido para a transferencia. ", nameof(valor));
            }

            /*Caso passou na condiçãoa cima do "IF". o metodo Sacar é iniciado, aonde é debitado o valor
             da conta do cliente */
            Sacar(valor);
            /*Caso o cliente tenha saldo suficiente, o sair do metodo Sacar()
             o Valor será depositado na conta Destino seguindo o metodo abaixo */
            contaDestino.Depositar(valor);
           
        }
    }
}
