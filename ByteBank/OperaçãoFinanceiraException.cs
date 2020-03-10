using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class OperacaoFinanceiraException : Exception
    {
        public OperacaoFinanceiraException()
        {

        }

        //Neste construtor, alteramos a mensagem de erro de acordocom a nossa necessidade no momento da exceção
        public OperacaoFinanceiraException(string mensagem) : base(mensagem)
        {

        }

        //Neste construtor é adicionado um parametro de Exceção, que será a INNER EXCEPTION (Exceção interna) 
        public OperacaoFinanceiraException(string mensagem, Exception excecaoInterna) : base (mensagem,excecaoInterna)
        {

        }

    }
}
