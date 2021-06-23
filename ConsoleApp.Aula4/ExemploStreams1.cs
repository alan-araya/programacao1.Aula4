using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp.Aula4
{
    public class ExemploStreams1
    {
        public ExemploStreams1()
        {
            string texto = "um texto para teste das streams!";
            //converte o texto em um array de bytes (byte[])
            byte[] textoBytes = Encoding.UTF8.GetBytes(texto);

            //cria uma Stream para Read/Write 
            var fileStream = new FileStream("arquivoTeste.txt", FileMode.Create);

            //escreve todo o conteúdo do texto (em bye[]) na stream
            fileStream.Write(textoBytes, 0, textoBytes.Length);

            //cria um novo array com metade do tamnho do anterior
            byte[] textoMetade = new byte[textoBytes.Length / 2];

            fileStream.Flush();
            fileStream.Position = 0;

            //lê parte do texto escrito
            fileStream.Read(textoMetade, 0, textoMetade.Length);

            fileStream.Close();
            fileStream.Dispose();

            //escreve o texto pela metade
            Console.WriteLine(Encoding.UTF8.GetString(textoMetade));
            //Output no console: um texto para te

        }
    }
}
