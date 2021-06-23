using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp.Aula4
{
    public class ExemploThread1
    {
        public ExemploThread1()
        {
            //Inicializa uma Thread que irá executar o método Worker1
            Thread t1 = new Thread(Worker1);
            //A Thread somente começa a executar a partir do "start"
            t1.Start();

            //escreve em loop na main Thread a palavra "main"
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("main");
            }
        }

        public void Worker1()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("w1");
            }
        }
    }
}
