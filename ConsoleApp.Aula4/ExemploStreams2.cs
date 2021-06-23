using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp.Aula4
{
    public class ExemploStreams2
    {
        public ExemploStreams2()
        {
            
        }

        public async Task TesteFileAsync()
        {
            byte[] textoBytes = GeraTextoLongo();

            var cronometro = new Stopwatch();

            cronometro.Start();
            File.WriteAllBytes("teste1", textoBytes);
            cronometro.Stop();

            Console.WriteLine("TempoTextoLongoSync:" + cronometro.Elapsed.TotalSeconds);

            cronometro.Start();
            await File.WriteAllBytesAsync("teste1", textoBytes);
            cronometro.Stop();

            Console.WriteLine("TempoTextoLongoAsync:" + cronometro.Elapsed.TotalSeconds);
        }

        public byte[] GeraTextoLongo()
        {
            var letras = new char[] {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','Y','Z'};
            var numeros = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

            var random = new Random();
            var builder = new StringBuilder();

            for (int i = 0; i < 10000; i++)
            {
                for (int k = 0; k < 1000; k++)
                {
                    builder.Append(letras[random.Next(0, letras.Length)]);
                    builder.Append(letras[random.Next(0, letras.Length)]);
                    builder.Append(letras[random.Next(0, letras.Length)]);
                }
                builder.Append(numeros[random.Next(0, numeros.Length)]);
                builder.Append(numeros[random.Next(0, numeros.Length)]);
            }

            char[] arrayChar = new char[builder.Length];

            builder.CopyTo(0, arrayChar, 0 , builder.Length);

            return arrayChar.ToArray().Select(c => (byte)c).ToArray();
        }
    }
}
