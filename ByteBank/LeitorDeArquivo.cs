﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class LeitorDeArquivo : IDisposable
    {
        public string Arquivo { get; }

        public LeitorDeArquivo(string arquivo)
        {
            Arquivo = arquivo;
             
               // throw new FileNotFoundException();//Esta excecão deriva de uma exceção IOException
            
            
            Console.WriteLine("Abrindo arquivo: " + arquivo);
        }

        public string LerProximaLinha()//
        {
            Console.WriteLine("Lendo linha...");

            //
           // throw new IOException();
            return "Linha do arquivo";
        }      

       public void Dispose()// É o metodo que libera os recursos, ou seja neste caso ele fecha o arquivo
        {
            Console.WriteLine("Fechando arquivo.");
        }
    }
}
