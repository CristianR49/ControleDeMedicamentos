using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.Fornecedores;
using ControleDeMedicamentos.Funcionarios;
using ControleDeMedicamentos.Medicamentos;
using ControleDeMedicamentos.Aquisições;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Aquisições
{
    internal class RepositorioAquisicao : Repositorio
    {
        public void InserirItem(Aquisicao aquisicao)
        {
            contadorDeId++;
            aquisicao.id = contadorDeId;
            listaDeItens.Add(aquisicao);
        }

        internal bool VerificarSeHaAquisicao()
        {
            if (listaDeItens.Count == 0)
                return false;
            return true;
        }
        public Aquisicao PegarAquisicaoPorId(int IdAquisicao)
        {
            ArrayList listaDeItens = SelecionarTodos();
            foreach (Aquisicao r in listaDeItens)
            {
                if (r.id == IdAquisicao)
                {
                    return r;
                }
            }
            return null;
        }
        public void AtualizarAquisicao(int idASerEditado, Aquisicao aquisicao)
        {
            listaDeItens[PegarIndiceDoIdEscolhido(idASerEditado)] = aquisicao;
        }
        private int PegarIndiceDoIdEscolhido(int idDoItem)
        {
            int i = 0;
            foreach (Aquisicao r in listaDeItens)
            {
                if (r.id == idDoItem)
                    return i;
                i++;
            }
            return -1;
        }
        public void ExcluirItem(int idASerExcluido)
        {
            listaDeItens.RemoveAt(PegarIndiceDoIdEscolhido(idASerExcluido));
        }
        public void CadastrarAquisicaoAutomaticamente()
        {
            Funcionario funcionario = new Funcionario("Jão", "123.456", "Joao", "9777-3215", "Rua Caminhão", "555123");
            Fornecedor fornecedor = new Fornecedor("Carinha", "888-500", "4444-3215", "Rua Avião", "cara.@gmail");
            Medicamento medicamento = new Medicamento("Benzetil", "Medicamento para febre", 20, 10, fornecedor);
            Aquisicao aquisicao = new Aquisicao(fornecedor, medicamento, funcionario, "25/03", 20);
            aquisicao.id = 1;
            listaDeItens.Add(aquisicao);
            return;
        }
    }
}
