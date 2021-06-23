using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp.Aula4
{
    public class ExemploThread3
    {
        public bool done = false;
        Stack<int> pilhaCompatilhada = new Stack<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

        public ExemploThread3()
        {
            Console.WriteLine("Inicio exemplo 3 - t4");
            Console.WriteLine("ID da main Thread: " + Thread.CurrentThread.ManagedThreadId.ToString());

            //declara t4 com uma Lambda Function
            var t4 = new Thread(() =>
            {
                ConsomePilha();
                Console.WriteLine("t4 terminou!");
            });
            t4.Name = "Thread t4";
            t4.Start();

            //Sleep na main Thread
            Thread.Sleep(100);

            //Executa o consumo da pilha na main Thread
            ConsomePilha();
            
            //aguarda t4 finalizar
            t4.Join();
        }

        public void ConsomePilha()
        {
            if (!done)
            {
                while(pilhaCompatilhada.Count > 0)
                {
                    Console.Write(pilhaCompatilhada.Pop());
                }
                done = true;
                Console.WriteLine("Acabei! Na Thread: " + Thread.CurrentThread.Name ?? "main Thread");
            }
            else
            {
                Console.WriteLine("pilha vazia....");
            }
        }

        //output no console:
        //Inicio exemplo 3 - t4
        //ID da main Thread: 1
        //109876543210Acabei! Na Thread: Thread t4
        //t4 terminou!
        //pilha vazia....
    }
}
