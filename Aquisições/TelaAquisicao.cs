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
    internal class TelaAquisicao : Tela
    {
        public RepositorioAquisicao repositorioAquisicao;
        public RepositorioFuncionario repositorioFuncionario;
        public RepositorioMedicamento repositorioMedicamento;
        public RepositorioFornecedor repositorioFornecedor;

        public TelaMedicamento telaMedicamento;
        public TelaFuncionario telaFuncionario;
        public TelaFornecedor telaFornecedor;
        public void CadastrarAquisicao()
        {
            ApresentarCabecalho("Cadastro de Aquisições", "Cadastrar Aquisição");
            if (repositorioFornecedor.VerificarSeHaFornecedor() == false)
            {
                ApresentarMensagem("Não há fornecedores registrados", ConsoleColor.Red, true);
                return;
            }
            if (repositorioFuncionario.VerificarSeHaFuncionario() == false)
            {
                ApresentarMensagem("Não há funcionarios registrados", ConsoleColor.Red, true);
                return;
            }
            if (repositorioMedicamento.VerificarSeHaMedicamento() == false)
            {
                ApresentarMensagem("Não há medicamentos registrados", ConsoleColor.Red, true);
                return;
            }

            Aquisicao aquisicao;
            aquisicao = InformarNovaAquisicao();
            repositorioAquisicao.InserirItem(aquisicao);
            ApresentarMensagem("Aquisição cadastrada com sucesso", ConsoleColor.Green, true);
        }
        public void VisualizarAquisicoes()
        {
            ApresentarCabecalho("Cadastro de Aquisições", "Visualizar Aquisição");
            if (repositorioAquisicao.VerificarSeHaAquisicao() == false)
            {
                ApresentarMensagem("Não há aquisições registradas", ConsoleColor.Red, true);
                return;
            }
            MostrarAquisicoes();
            Console.ReadLine();
        }

        private void MostrarAquisicoes()
        {
            ArrayList listaDeItens = repositorioAquisicao.SelecionarTodos();
            Console.WriteLine("Aquisições cadastradas:");
            Console.WriteLine($"{"Id",-2}| {"Funcionário",-20}| {"Medicamento",-20}| {"Fornecedor",-20}| {"Data",-10}| {"Quantidade de medicamento"}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            foreach (Aquisicao r in listaDeItens)
            {
                Console.WriteLine($"{r.id,-2}| {r.funcionario.nome,-20}| {r.medicamento.nome,-20}| {r.fornecedor.nome,-20}| {r.data,-20}| {r.qntMedicamento,-20}");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
        }

        public void EditarAquisicao()
        {
            ApresentarCabecalho("Cadastro de Aquisições", "Editar Aquisição");
            if (repositorioAquisicao.VerificarSeHaAquisicao() == false)
            {
                ApresentarMensagem("Não há aquisições registradas", ConsoleColor.Red, true);
                return;
            }
            if (repositorioFornecedor.VerificarSeHaFornecedor() == false)
            {
                ApresentarMensagem("Não há fornecedores registrados", ConsoleColor.Red, true);
                return;
            }
            if (repositorioFuncionario.VerificarSeHaFuncionario() == false)
            {
                ApresentarMensagem("Não há funcionarios registrados", ConsoleColor.Red, true);
                return;
            }
            if (repositorioMedicamento.VerificarSeHaMedicamento() == false)
            {
                ApresentarMensagem("Não há medicamentos registrados", ConsoleColor.Red, true);
                return;
            }
            MostrarAquisicoes();
            int idASerEditado = InputarId();

            Aquisicao aquisicao = InformarNovaAquisicao();
            aquisicao.id = idASerEditado;

            repositorioAquisicao.AtualizarAquisicao(idASerEditado, aquisicao);
            ApresentarMensagem("Aquisição editada com sucesso!", ConsoleColor.Green, true);
        }
        public void ExcluirAquisicao()
        {
            ApresentarCabecalho("Cadastro de Aquisições", "Excluir Aquisição");
            if (repositorioAquisicao.VerificarSeHaAquisicao() == false)
            {
                ApresentarMensagem("Não há aquisições registradas", ConsoleColor.Red, true);
                return;
            }
            MostrarAquisicoes();
            int idASerExcluido = InputarId();

            repositorioAquisicao.ExcluirItem(idASerExcluido);
            repositorioAquisicao.ResetarIdSeAListaForApagada();
            ApresentarMensagem("Aquisição excluída com sucesso!", ConsoleColor.Green, true);

        }

        internal Aquisicao InformarNovaAquisicao()
        {

            Console.WriteLine("Escolha um Fornecedor");
            telaFornecedor.MostrarFornecedores();
            int idEscolhido = telaFornecedor.InputarId();
            Fornecedor fornecedor = repositorioFornecedor.PegarFornecedorPorId(idEscolhido);
            Console.WriteLine("Escolha um Medicamento");
            telaMedicamento.MostrarMedicamentos();
            int idMedicamentoEscolhido = telaMedicamento.InputarId();
            Medicamento medicamento = repositorioMedicamento.PegarMedicamentoPorId(idEscolhido);
            Console.WriteLine("Escolha um Funcionário");
            telaFuncionario.MostrarFuncionarios();
            idEscolhido = telaFuncionario.InputarId();
            Funcionario funcionario = repositorioFuncionario.PegarFuncionarioPorId(idEscolhido);
            Console.WriteLine("Digite a data");
            string data = Console.ReadLine();
            Console.WriteLine("Digite a quantidade de medicamento");
            int qntMedicamento = Convert.ToInt32(Console.ReadLine());

            repositorioMedicamento.AumentarQuantidadeDeMedicamento(idMedicamentoEscolhido, qntMedicamento);

            Aquisicao aquisicao = new Aquisicao(fornecedor, medicamento, funcionario, data, qntMedicamento);

            return aquisicao;
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
                    Console.Write("Digite o Id da Aquisição");
                    idDigitado = Console.ReadLine();
                    letraNoMeio = repositorioAquisicao.VerificarSeTemLetraNoMeio(idDigitado);
                    if (string.IsNullOrEmpty(idDigitado) || letraNoMeio)
                        ApresentarMensagem("Digite um número", ConsoleColor.Red, false);

                } while (string.IsNullOrEmpty(idDigitado) || letraNoMeio);

                idSelecionado = Convert.ToInt32(idDigitado);

                idInvalido = repositorioAquisicao.PegarAquisicaoPorId(idSelecionado) == null;

                if (idInvalido)
                    ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red, false);

            } while (idInvalido);

            return idSelecionado;
        }
        public string MostrarMenuAquisicao()
        {
            string opcaoMenuAquisicao;
            Console.Clear();
            ApresentarCabecalho("Cadastro de Aquisição", "Menu");
            Console.WriteLine("(1) Cadastrar uma nova Aquisição");
            Console.WriteLine("(2) Visualizar Aquisições cadastrados");
            Console.WriteLine("(3) Editar uma Aquisição");
            Console.WriteLine("(4) Excluir uma Aquisição");
            Console.WriteLine("(5) Voltar ao menu principal");
            opcaoMenuAquisicao = Console.ReadLine();
            return opcaoMenuAquisicao;
        }
    }
}
