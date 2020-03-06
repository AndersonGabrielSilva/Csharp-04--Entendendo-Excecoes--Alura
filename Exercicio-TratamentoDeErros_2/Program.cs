using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_TratamentoDeErros_2
{
    class Program
    {
        //EXERCICIO

        /*Para reforçar o tratamento de exceções e como elas são propagadas na CallStack (pilha de chamadas),
         * Camila escreveu o código abaixo:
         * Após a exceção ser lançada em LancaExcecao, qual será a saída no Console?
         * 
         * RESPOSTA
         * 
         * Correta! Uma vez que o bloco catch em M2 trata a exceção, 
         * ela não é propagada para o método M1 ou o método Main.
         * 
         * Quando a Execão é encontrata a execulsão para e o compilador vai transmitindo o erro
         * para cada elemento da pilha até encontrar alguma solução para este erro. Caso encontre
         * ele continua a execulsão apartir da linha aonde o problema foi solucionado
         */

        static void Main(string[] args)
        {
            M1();
            Console.ReadLine();
        }

        static void M1()
        {
            try
            {
                M2();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exceção capturada em M1");
            }
        }

        static void M2()
        {
            try
            {
                LancaExcecao();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exceção capturada em M2");
            }
        }

        static void LancaExcecao()
        {
            int divisor = 0;
            int resultado = 1 / divisor;
        }
    }
}
