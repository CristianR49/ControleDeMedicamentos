using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.Fornecedores;
using ControleDeMedicamentos.Funcionarios;
using ControleDeMedicamentos.Medicamentos;
using ControleDeMedicamentos.Pacientes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Requisições
{
    internal class RepositorioRequisicao : Repositorio
    {

        public void InserirItem(Requisicao requisicao)
        {
            contadorDeId++;
            requisicao.id = contadorDeId;
            listaDeItens.Add(requisicao);
        }

        internal bool VerificarSeHaRequisicao()
        {
            if (listaDeItens.Count == 0)
                return false;
            return true;
        }
        public Requisicao PegarRequisicaoPorId(int IdRequisicao)
        {
            ArrayList listaDeItens = SelecionarTodos();
            foreach (Requisicao r in listaDeItens)
            {
                if (r.id == IdRequisicao)
                {
                    return r;
                }
            }
            return null;
        }
        public void AtualizarRequisicao(int idASerEditado, Requisicao requisicao)
        {
            listaDeItens[PegarIndiceDoIdEscolhido(idASerEditado)] = requisicao;
        }
        private int PegarIndiceDoIdEscolhido(int idDoItem)
        {
            int i = 0;
            foreach (Requisicao r in listaDeItens)
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
        public void CadastrarRequisicaoAutomaticamente()
        {
            Paciente paciente = new Paciente("Ronaldo", "950.445", "88-609", "9654-3214", "Rua Almirante");
            Funcionario funcionario = new Funcionario("Jão", "123.456", "Joao", "9777-3215", "Rua Caminhão", "555123");
            Fornecedor fornecedor = new Fornecedor("Carinha", "888-500", "4444-3215", "Rua Avião", "cara.@gmail");
            Medicamento medicamento = new Medicamento("Benzetil", "Medicamento para febre", 20, 10, fornecedor);
            Requisicao requisicao = new Requisicao(funcionario, medicamento, paciente, "20/03", 20);
            requisicao.id = 1;
            listaDeItens.Add(requisicao);
            return;
        }
    }
}
