using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.Fornecedores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Medicamentos
{
    internal class RepositorioMedicamento : Repositorio
    {
        
        public void InserirItem(Medicamento medicamento)
        {
            contadorDeId++;
            medicamento.id = contadorDeId;
            listaDeItens.Add(medicamento);
        }

        public bool VerificarSeHaMedicamento()
        {
            if (listaDeItens.Count == 0)
            return false;
            return true;
        }
        public Medicamento PegarMedicamentoPorId(int IdMedicamento)
        {
            foreach (Medicamento m in listaDeItens)
            {
                if (m.id == IdMedicamento)
                {
                    return m;
                }
            }
            return null;
        }
        public void AtualizarMedicamento(int idASerEditado, Medicamento medicamento)
        {
            listaDeItens[PegarIndiceDoIdEscolhido(idASerEditado)] = medicamento;
        }
        private int PegarIndiceDoIdEscolhido(int idDoItem)
        {
            int i = 0;
            foreach (Medicamento m in listaDeItens)
            {
                if (m.id == idDoItem)
                    return i;
                i++;
            }
            return -1;
        }
        public void ExcluirItem(int idASerExcluido)
        {
            listaDeItens.RemoveAt(PegarIndiceDoIdEscolhido(idASerExcluido));
        }

        public void CadastrarMedicamentoAutomaticamente()
        {
            Fornecedor fornecedor = new Fornecedor("Carinha", "888-500", "4444-3215", "Rua Avião", "cara.@gmail");
            Medicamento medicamento = new Medicamento("Benzetil", "Medicamento para febre", 7, 10, fornecedor);
            medicamento.id = 1;
            medicamento.qntRetiradas = 7;
            listaDeItens.Add(medicamento);

            Fornecedor fornecedor2 = new Fornecedor("Carinha", "888-500", "4444-3215", "Rua Avião", "cara.@gmail");
            Medicamento medicamento2 = new Medicamento("Alprazolan", "Medicamento para azia", 5, 10, fornecedor);
            medicamento2.id = 2;
            medicamento2.qntRetiradas = 5;
            listaDeItens.Add(medicamento2);

            Fornecedor fornecedor3 = new Fornecedor("Carinha", "888-500", "4444-3215", "Rua Avião", "cara.@gmail");
            Medicamento medicamento3 = new Medicamento("Beneditozan", "Medicamento para Risada", 20, 10, fornecedor);
            medicamento3.id = 3;
            medicamento3.qntRetiradas = 9;
            listaDeItens.Add(medicamento3);
            contadorDeId = 3;
        }

        public void ReduzirQuantidadeDeMedicamento(int idEscolhido, int qntMedicamento)
        {
            PegarMedicamentoPorId(idEscolhido).quantidade -= qntMedicamento;
        }
        public void IncremetarQuantidadeDeRequisicoesNoMedicamento(int idEscolhido)
        {
            PegarMedicamentoPorId(idEscolhido).qntRetiradas++;
        }

        public void AumentarQuantidadeDeMedicamento(int idMedicamentoEscolhido, int qntMedicamento)
        {
            PegarMedicamentoPorId(idMedicamentoEscolhido).quantidade += qntMedicamento;
        }
    }
}
