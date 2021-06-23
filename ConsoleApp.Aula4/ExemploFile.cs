using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp.Aula4
{
    public class ExemploFile
    {
        public ExemploFile()
        {
            
        }

        public async Task ExemploFileAsync()
        {
            var texto = "uma string com um texto de teste simples!";

            //Grava um byt[] em um arquivo de modo simples
            //Sobre escreve o arquivo se já existir
            File.WriteAllBytes("teste.txt", Encoding.UTF8.GetBytes(texto));

            //Lê os dados do arquivo gravado
            var textolido = Encoding.UTF8.GetString(File.ReadAllBytes("teste.txt"));

            Console.WriteLine($"Os texto gravado é igual ao lido = {texto.Length == textolido.Length}");

            //Escreve uma string em um arquivo de forma assíncrona
            //utilizando por dentro FileStream com WriteAsync()
            await File.WriteAllTextAsync("teste.txt", texto);

            //Le todo texto de um arquivo de forma assíncrona
            //e converte em string. Utilizando FileStream com ReadAsync()
            textolido = await File.ReadAllTextAsync("teste.txt");

        }
    }
}
