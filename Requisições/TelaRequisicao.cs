using ControleDeMedicamentos.Compartilhado;
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
    internal class TelaRequisicao : Tela
    {

        public RepositorioRequisicao repositorioRequisicao;
        public RepositorioPaciente repositorioPaciente;
        public RepositorioMedicamento repositorioMedicamento;
        public RepositorioFuncionario repositorioFuncionario;

        public TelaMedicamento telaMedicamento;
        public TelaPaciente telaPaciente;
        public TelaFuncionario telaFuncionario;
        public void CadastrarRequisicao()
        {
            ApresentarCabecalho("Cadastro de Requisições", "Cadastrar Requisição");
            if (repositorioPaciente.VerificarSeHaPaciente() == false)
            {
                ApresentarMensagem("Não há pacientes registrados", ConsoleColor.Red, true);
                return;
            }
            if (repositorioMedicamento.VerificarSeHaMedicamento() == false)
            {
                ApresentarMensagem("Não há medicamentos registrados", ConsoleColor.Red, true);
                return;
            }
            if (repositorioFuncionario.VerificarSeHaFuncionario() == false)
            {
                ApresentarMensagem("Não há funcionarios registrados", ConsoleColor.Red, true);
                return;
            }

            Requisicao requisicao;
            requisicao = InformarNovaRequisicao();
            if(requisicao == null)
            {
                return;
            }
            repositorioRequisicao.InserirItem(requisicao);
            ApresentarMensagem("Requisição cadastrada com sucesso", ConsoleColor.Green, true);
        }
        public void VisualizarRequisicoes()
        {
            ApresentarCabecalho("Cadastro de Requisições", "Visualizar Requisição");
            if (repositorioRequisicao.VerificarSeHaRequisicao() == false)
            {
                ApresentarMensagem("Não há requisições registradas", ConsoleColor.Red, true);
                return;
            }
            MostrarRequisicoes();
            Console.ReadLine();
        }

        private void MostrarRequisicoes()
        {
            ArrayList listaDeItens = repositorioRequisicao.SelecionarTodos();
            Console.WriteLine("Requisições cadastradas:");
            Console.WriteLine($"{"Id",-2}| {"Paciente",-20}| {"Medicamento",-20}| {"Funcionario",-20}| {"Data",-10}| {"Quantidade de medicamentos retirados"}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
            foreach (Requisicao r in listaDeItens)
            {
                Console.WriteLine($"{r.id,-2}| {r.paciente.nome,-20}| {r.medicamento.nome,-20}| {r.funcionario.nome,-20}| {r.data,-20}| {r.qntMedicamento,-20}");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
        }

        public void EditarRequisicao()
        {
            ApresentarCabecalho("Cadastro de Requisições", "Editar Requisição");
            if (repositorioRequisicao.VerificarSeHaRequisicao() == false)
            {
                ApresentarMensagem("Não há requisições registradas", ConsoleColor.Red, true);
                return;
            }
            if (repositorioPaciente.VerificarSeHaPaciente() == false)
            {
                ApresentarMensagem("Não há pacientes registrados", ConsoleColor.Red, true);
                return;
            }
            if (repositorioMedicamento.VerificarSeHaMedicamento() == false)
            {
                ApresentarMensagem("Não há medicamentos registrados", ConsoleColor.Red, true);
                return;
            }
            if (repositorioFuncionario.VerificarSeHaFuncionario() == false)
            {
                ApresentarMensagem("Não há funcionarios registrados", ConsoleColor.Red, true);
                return;
            }
            MostrarRequisicoes();
            int idASerEditado = InputarId();

            Requisicao requisicao = InformarNovaRequisicao();
            if(requisicao == null)
            {
                return;
            }
            requisicao.id = idASerEditado;

            repositorioRequisicao.AtualizarRequisicao(idASerEditado, requisicao);
            ApresentarMensagem("Requisição editada com sucesso!", ConsoleColor.Green, true);
        }
        public void ExcluirRequisicao()
        {
            ApresentarCabecalho("Cadastro de Requisições", "Excluir Requisição");
            if (repositorioRequisicao.VerificarSeHaRequisicao() == false)
            {
                ApresentarMensagem("Não há requisições registradas", ConsoleColor.Red, true);
                return;
            }
            MostrarRequisicoes();
            int idASerExcluido = InputarId();

            repositorioRequisicao.ExcluirItem(idASerExcluido);
            repositorioRequisicao.ResetarIdSeAListaForApagada();
            ApresentarMensagem("Requisição excluída com sucesso!", ConsoleColor.Green, true);

        }

        internal Requisicao InformarNovaRequisicao()
        {
            Console.WriteLine("Escolha um Paciente");
            telaPaciente.MostrarPacientes();
            int idEscolhido = telaPaciente.InputarId();
            Paciente paciente = repositorioPaciente.PegarPacientePorId(idEscolhido);

            Console.WriteLine("Escolha um Medicamento");
            telaMedicamento.MostrarMedicamentos();
            int idMedicamentoEscolhido = telaMedicamento.InputarId();
            Medicamento medicamento = repositorioMedicamento.PegarMedicamentoPorId(idEscolhido);
            if(medicamento.quantidade <= 0)
            {
                ApresentarMensagem("Não há estoque desse medicamento",ConsoleColor.Red,true);
                return null;
            }
            Console.WriteLine("Escolha um Funcionario");
            telaFuncionario.MostrarFuncionarios();
            idEscolhido = telaFuncionario.InputarId();
            Funcionario funcionario = repositorioFuncionario.PegarFuncionarioPorId(idEscolhido);


            Console.WriteLine("Digite a data");
            string data = Console.ReadLine();
            Console.WriteLine("Digite a quantidade de medicamentos a ser retirados");
            int qntMedicamento = Convert.ToInt32(Console.ReadLine());
            repositorioMedicamento.ReduzirQuantidadeDeMedicamento(idMedicamentoEscolhido, qntMedicamento);
            repositorioMedicamento.IncremetarQuantidadeDeRequisicoesNoMedicamento(idMedicamentoEscolhido);

            Requisicao requisicao = new Requisicao(funcionario, medicamento, paciente, data, qntMedicamento);

            return requisicao;
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
                    Console.Write("Digite o Id da Requisição");
                    idDigitado = Console.ReadLine();
                    letraNoMeio = repositorioRequisicao.VerificarSeTemLetraNoMeio(idDigitado);
                    if (string.IsNullOrEmpty(idDigitado) || letraNoMeio)
                        ApresentarMensagem("Digite um número", ConsoleColor.Red, false);

                } while (string.IsNullOrEmpty(idDigitado) || letraNoMeio);

                idSelecionado = Convert.ToInt32(idDigitado);

                idInvalido = repositorioRequisicao.PegarRequisicaoPorId(idSelecionado) == null;

                if (idInvalido)
                    ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red, false);

            } while (idInvalido);

            return idSelecionado;
        }
        public string MostrarMenuRequisicao()
        {
            string opcaoMenuRequisicao;
            Console.Clear();
            ApresentarCabecalho("Cadastro de Requisição", "Menu");
            Console.WriteLine("(1) Cadastrar uma nova Requisição");
            Console.WriteLine("(2) Visualizar Requisições cadastrados");
            Console.WriteLine("(3) Editar uma Requisição");
            Console.WriteLine("(4) Excluir uma Requisição");
            Console.WriteLine("(5) Voltar ao menu principal");
            opcaoMenuRequisicao = Console.ReadLine();
            return opcaoMenuRequisicao;
        }

    }
}
