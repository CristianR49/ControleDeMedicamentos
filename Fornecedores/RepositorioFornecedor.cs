using ControleDeMedicamentos.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Fornecedores
{
    internal class RepositorioFornecedor : Repositorio
    {
        public void InserirItem(Fornecedor fornecedor)
        {
            contadorDeId++;
            fornecedor.id = contadorDeId;
            listaDeItens.Add(fornecedor);
        }

        internal bool VerificarSeHaFornecedor()
        {
            if (listaDeItens.Count == 0)
                return false;
            return true;
        }
        public Fornecedor PegarFornecedorPorId(int IdFornecedor)
        {
            ArrayList listaDeItens = SelecionarTodos();
            foreach (Fornecedor f in listaDeItens)
            {
                if (f.id == IdFornecedor)
                {
                    return f;
                }
            }
            return null;
        }
        public void AtualizarFornecedor(int idASerEditado, Fornecedor fornecedor)
        {
            listaDeItens[PegarIndiceDoIdEscolhido(idASerEditado)] = fornecedor;
        }
        private int PegarIndiceDoIdEscolhido(int idDoItem)
        {
            int i = 0;
            foreach (Fornecedor f in listaDeItens)
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
        public void CadastrarFornecedorAutomaticamente()
        {
            Fornecedor fornecedor = new Fornecedor("Carinha", "888-500", "4444-3215", "Rua Avião", "cara.@gmail");
            fornecedor.id = 1;
            listaDeItens.Add(fornecedor);
            return;
        }
    }
}
