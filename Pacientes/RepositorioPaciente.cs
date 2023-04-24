using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.Fornecedores;
using ControleDeMedicamentos.Medicamentos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Pacientes
{
    internal class RepositorioPaciente : Repositorio
    {
        public void InserirItem(Paciente paciente)
        {
            contadorDeId++;
            paciente.id = contadorDeId;
            listaDeItens.Add(paciente);
        }

        internal bool VerificarSeHaPaciente()
        {
            if (listaDeItens.Count == 0)
                return false;
            return true;
        }
        public Paciente PegarPacientePorId(int IdPaciente)
        {
            ArrayList listaDeItens = SelecionarTodos();
            foreach (Paciente p in listaDeItens)
            {
                if (p.id == IdPaciente)
                {
                    return p;
                }
            }
            return null;
        }
        public void AtualizarPaciente(int idASerEditado, Paciente paciente)
        {
            listaDeItens[PegarIndiceDoIdEscolhido(idASerEditado)] = paciente;
        }
        private int PegarIndiceDoIdEscolhido(int idDoItem)
        {
            int i = 0;
            foreach (Paciente p in listaDeItens)
            {
                if (p.id == idDoItem)
                    return i;
                i++;
            }
            return -1;
        }
        public void ExcluirItem(int idASerExcluido)
        {
            listaDeItens.RemoveAt(PegarIndiceDoIdEscolhido(idASerExcluido));
        }
        public void CadastrarPacienteAutomaticamente()
        {
            Paciente paciente = new Paciente("Ronaldo", "950.445", "88-609", "9654-3214", "Rua Almirante");
            paciente.id = 1;
            listaDeItens.Add(paciente);
            return;
        }
    }
}
