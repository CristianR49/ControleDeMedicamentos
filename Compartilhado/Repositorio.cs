using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Compartilhado
{
    internal class Repositorio
    {
        public Tela tela = new Tela();
        public ArrayList listaDeItens = new ArrayList();
        public int contadorDeId = 1;
        public ArrayList SelecionarTodos()
        {
            return listaDeItens;
        }
        public bool VerificarSeTemLetraNoMeio(string texto)
        {
            bool letraNoMeio = false;
            foreach (char caractere in texto)
            {
                if (caractere < 48 || caractere > 57)
                    letraNoMeio = true;
            }

            return letraNoMeio;
        }
        public void ResetarIdSeAListaForApagada()
        {
            if (listaDeItens.Count == 0)
            {
                contadorDeId = 0;
            }
        }
        public bool ApresentarErros(bool infoInvalida, ArrayList erros)
        {
            if (erros.Count > 0)
            {
                infoInvalida = true;
                foreach (string erro in erros)
                    tela.ApresentarMensagem(erro, ConsoleColor.Red, false);
                Console.ReadLine();
            }

            return infoInvalida;
        }
    }
}
