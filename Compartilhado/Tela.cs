using ControleDeMedicamentos.Medicamentos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Compartilhado
{
    internal class Tela
    {

        public void ApresentarCabecalho(string titulo, string subtitulo)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(titulo);
            Console.WriteLine();
            Console.WriteLine(subtitulo);
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
        }
        public void ApresentarCabecalhoSimples(string titulo)
        {
            Console.WriteLine();
            Console.WriteLine(titulo);
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
        }
        public void ApresentarMensagem(string mensagem, ConsoleColor cor, bool apertarEnter)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            if (apertarEnter == true)
            {
                Console.ReadLine();
            }
        }
        public bool ApresentarErros(bool infoInvalida, ArrayList erros)
        {
            if (erros.Count > 0)
            {
                infoInvalida = true;
                foreach (string erro in erros)
                    ApresentarMensagem(erro, ConsoleColor.Red, false);
                Console.ReadLine();
            }

            return infoInvalida;
        }
    }
}
