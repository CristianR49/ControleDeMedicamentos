using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.Fornecedores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Funcionarios
{
    internal class RepositorioFuncionario : Repositorio
    {
        public void InserirItem(Funcionario funcionario)
        {
            contadorDeId++;
            funcionario.id = contadorDeId;
            listaDeItens.Add(funcionario);
        }

        internal bool VerificarSeHaFuncionario()
        {
            if (listaDeItens.Count == 0)
                return false;
            return true;
        }
        public Funcionario PegarFuncionarioPorId(int IdFuncionario)
        {
            ArrayList listaDeItens = SelecionarTodos();
            foreach (Funcionario f in listaDeItens)
            {
                if (f.id == IdFuncionario)
                {
                    return f;
                }
            }
            return null;
        }
        public void AtualizarFuncionario(int idASerEditado, Funcionario funcionario)
        {
            listaDeItens[PegarIndiceDoIdEscolhido(idASerEditado)] = funcionario;
        }
        private int PegarIndiceDoIdEscolhido(int idDoItem)
        {
            int i = 0;
            foreach (Funcionario f in listaDeItens)
            {
                if (f.id == idDoItem)
                    return i;
                i++;
            }
            return -1;
        }
        public void ExcluirItem(int idASerExcluido)
        {
            listaDeItens.RemoveAt(PegarIndiceDoIdEscolhido(idASerExcluido));
        }
        public void CadastrarFuncionarioAutomaticamente()
        {
            Funcionario funcionario = new Funcionario("Jão","123.456","Joao","9777-3215","Rua Caminhão","555123");
            funcionario.id = 1;
            listaDeItens.Add(funcionario);
            
            return;
        }
    }
}
