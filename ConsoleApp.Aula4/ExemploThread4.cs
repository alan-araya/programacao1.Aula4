using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp.Aula4
{
    public class ExemploThread4
    {
        public ExemploThread4()
        {
            Console.WriteLine("Exemplo 4 - exceptions:");

            try
            {
                Exemplo5Exception();
            }
            catch (Exception ex)
            {
            }
        }

        public void Exemplo5Exception()
        {
            try
            {
                var t5 = new Thread(() =>
                {
                    DividePorZero(100);
                });
                t5.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("execption tratada!");
            }
        }

        public int DividePorZero(int valor)
        {
            return valor / 0;
        }
    }
}
