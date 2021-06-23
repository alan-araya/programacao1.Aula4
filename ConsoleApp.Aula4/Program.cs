using System;
using System.Threading.Tasks;

namespace ConsoleApp.Aula4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Olá Turma!");
            Console.WriteLine("AULA 4 - Threads e Tasks!");

            //ExemploThread1 exemploThread1 = new ExemploThread1();

            //ExemploThread2 exemploThread2 = new ExemploThread2();

            //ExemploThread3 exemploThread3 = new ExemploThread3();

            ////ExemploThread4 exemploThread4 = new ExemploThread4();// lancará um exception


            //ExemploTask1 exemploTask1 = new ExemploTask1();

            //ExemploTask2 exemploTask2 = new ExemploTask2();

            //ExemploTask3 exemploTask3 = new ExemploTask3();

            //ExemploTask4 exemploTask4 = new ExemploTask4();

            //ExemploTask5 exemploTask5 = new ExemploTask5();

            //ExemploAsync1 exemploAsync1 = new ExemploAsync1();

            ExemploStreams1 exemploStreams1 = new ExemploStreams1();

            ExemploStreams2 exemploStreams2 = new ExemploStreams2();
            await exemploStreams2.TesteFileAsync();
        }
    }
}
