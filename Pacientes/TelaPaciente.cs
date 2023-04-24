using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.Pacientes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Pacientes
{
    internal class TelaPaciente : Tela
    {
        public RepositorioPaciente repositorioPaciente = null;

        public void CadastrarPaciente()
        {
            ApresentarCabecalho("Cadastro de Pacientes", "Cadastrar Paciente");
            Paciente paciente;
            paciente = InformarNovoPaciente();
            repositorioPaciente.InserirItem(paciente);
            ApresentarMensagem("Paciente cadastrado com sucesso", ConsoleColor.Green, true);
        }
        public void VisualizarPacientes()
        {
            ApresentarCabecalho("Cadastro de Pacientes", "Visualizar Paciente");
            if (repositorioPaciente.VerificarSeHaPaciente() == false)
            {
                ApresentarMensagem("Não há pacientes registrados", ConsoleColor.Red, true);
                return;
            }
            MostrarPacientes();
            Console.ReadLine();
        }

        public void MostrarPacientes()
        {
            ArrayList listaDeItens = repositorioPaciente.SelecionarTodos();
            Console.WriteLine("Pacientes cadastrados:");
            Console.WriteLine($"{"Id",-2}| {"Nome",-20}| {"CPF",-20}| {"Cartão SUS",-20}| {"telefone", -20}| {"Endereço"}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            foreach (Paciente p in listaDeItens)
            {
                Console.WriteLine($"{p.id,-2}| {p.nome,-20}| {p.cpf,-20}| {p.cartaoSus,-20}| {p.telefone, -20}| {p.endereco}");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
        }

        public void EditarPaciente()
        {
            ApresentarCabecalho("Cadastro de Pacientes", "Editar Paciente");
            if (repositorioPaciente.VerificarSeHaPaciente() == false)
            {
                ApresentarMensagem("Não há pacientes registrados", ConsoleColor.Red, true);
                return;
            }
            MostrarPacientes();
            int idASerEditado = InputarId();

            Paciente paciente = InformarNovoPaciente();
            paciente.id = idASerEditado;

            repositorioPaciente.AtualizarPaciente(idASerEditado, paciente);
            ApresentarMensagem("Paciente editado com sucesso!", ConsoleColor.Green, true);
        }
        public void ExcluirPaciente()
        {
            ApresentarCabecalho("Cadastro de Pacientes", "Excluir Paciente");
            if (repositorioPaciente.VerificarSeHaPaciente() == false)
            {
                ApresentarMensagem("Não há pacientes registrados", ConsoleColor.Red, true);
                return;
            }
            MostrarPacientes();
            int idASerExcluido = InputarId();

            repositorioPaciente.ExcluirItem(idASerExcluido);
            repositorioPaciente.ResetarIdSeAListaForApagada();
            ApresentarMensagem("Paciente excluído com sucesso!", ConsoleColor.Green, true);

        }

        internal Paciente InformarNovoPaciente()
        {

            Console.WriteLine("Digite o nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o CPF");
            string cpf = Console.ReadLine();
            Console.WriteLine("Digite o número do cartão SUS");
            string cartaoSus = Console.ReadLine();
            Console.WriteLine("Digite o telefone");
            string telefone = Console.ReadLine();
            Console.WriteLine("Digite o endereço");
            string endereco = Console.ReadLine();

            Paciente paciente = new Paciente(nome, cpf, cartaoSus, telefone, endereco);

            return paciente;
        }
        public int InputarId()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                string idDigitado;
                bool letraNoMeio;
                do
                {
                    Console.Write("Digite o Id do Paciente");
                    idDigitado = Console.ReadLine();
                    letraNoMeio = repositorioPaciente.VerificarSeTemLetraNoMeio(idDigitado);
                    if (string.IsNullOrEmpty(idDigitado) || letraNoMeio)
                        ApresentarMensagem("Digite um número", ConsoleColor.Red, false);

                } while (string.IsNullOrEmpty(idDigitado) || letraNoMeio);

                idSelecionado = Convert.ToInt32(idDigitado);

                idInvalido = repositorioPaciente.PegarPacientePorId(idSelecionado) == null;

                if (idInvalido)
                    ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red, false);

            } while (idInvalido);

            return idSelecionado;
        }
        public string MostrarMenuPaciente()
        {
            string opcaoMenuPaciente;
            Console.Clear();
            ApresentarCabecalho("Cadastro de Paciente", "Menu");
            Console.WriteLine("(1) Cadastrar um novo Paciente");
            Console.WriteLine("(2) Visualizar Pacientes cadastrados");
            Console.WriteLine("(3) Editar um Paciente");
            Console.WriteLine("(4) Excluir um Paciente");
            Console.WriteLine("(5) Voltar ao menu principal");
            opcaoMenuPaciente = Console.ReadLine();
            return opcaoMenuPaciente;
        }
    }
}
