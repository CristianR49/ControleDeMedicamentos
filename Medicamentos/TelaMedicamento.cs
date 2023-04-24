using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.Fornecedores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Medicamentos
{
    internal class TelaMedicamento : Tela
    {
        public RepositorioMedicamento repositorioMedicamento;
        public RepositorioFornecedor repositorioFornecedor;
        public TelaFornecedor telaFornecedor;

        public void CadastrarMedicamento()
        {
            ApresentarCabecalho("Cadastro de Medicamentos", "Cadastrar Medicamento");

            if (repositorioFornecedor.VerificarSeHaFornecedor() == false)
            {
                ApresentarMensagem("Não há fornecedor registrado", ConsoleColor.Red, true);
                return;
            }

            Medicamento medicamento;
            medicamento = InformarNovoMedicamento();
            medicamento.qntRetiradas = 0;
            repositorioMedicamento.InserirItem(medicamento);
            ApresentarMensagem("Medicamento cadastrado com sucesso", ConsoleColor.Green, true);
        }
        public void VisualizarMedicamentos()
        {
            ApresentarCabecalho("Cadastro de Medicamentos", "Visualizar Medicamento");
            if (repositorioMedicamento.VerificarSeHaMedicamento() == false)
            {
                ApresentarMensagem("Não há medicamentos registrados", ConsoleColor.Red, true);
                return;
            }
            MostrarMedicamentos();
            Console.ReadLine();
        }

        public void MostrarMedicamentos()
        {
            ArrayList listaDeItens = repositorioMedicamento.SelecionarTodos();
            Console.WriteLine("Medicamentos cadastrados:");
            Console.WriteLine($"{"Id",-2}| {"Nome",-20}| {"Descrição",-35}| {"Quantidade",-15}| {"Fornecedor"}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            foreach (Medicamento m in listaDeItens)
            {
                Console.WriteLine($"{m.id,-2}| {m.nome,-20}| {m.descricao,-35}| {Convert.ToString(m.quantidade),-15}| {m.fornecedor.nome,-2}");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
        }

        public void EditarMedicamento()
        {
            ApresentarCabecalho("Cadastro de Medicamentos", "Editar Medicamento");
            if (repositorioMedicamento.VerificarSeHaMedicamento() == false)
            {
                ApresentarMensagem("Não há medicamentos registrados", ConsoleColor.Red, true);
                return;
            }
            if (repositorioFornecedor.VerificarSeHaFornecedor() == false)
            {
                ApresentarMensagem("Não há fornecedor registrado", ConsoleColor.Red, true);
                return;
            }
            MostrarMedicamentos();
            int idASerEditado = InputarId();

            Medicamento medicamento = InformarNovoMedicamento();
            medicamento.id = idASerEditado;

            repositorioMedicamento.AtualizarMedicamento(idASerEditado, medicamento);
            ApresentarMensagem("Medicamento editado com sucesso!", ConsoleColor.Green, true);
        }
        public void ExcluirMedicamento()
        {
            ApresentarCabecalho("Cadastro de Medicamentos", "Excluir Medicamento");
            if (repositorioMedicamento.VerificarSeHaMedicamento() == false)
            {
                ApresentarMensagem("Não há medicamentos registrados", ConsoleColor.Red, true);
                return;
            }
            MostrarMedicamentos();
            int idASerExcluido = InputarId();

            repositorioMedicamento.ExcluirItem(idASerExcluido);
            repositorioMedicamento.ResetarIdSeAListaForApagada();
            ApresentarMensagem("Medicamento excluído com sucesso!", ConsoleColor.Green, true);

        }

        private Medicamento InformarNovoMedicamento()
        {

            Console.WriteLine("Digite o nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite a descrição");
            string descricao = Console.ReadLine();
            Console.WriteLine("Digite a quantidade disponível");
            int quantidade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a quantidade limite que indica a falta de medicamentos");
            int quantidadeLimite = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Escolha um fornecedor");
            telaFornecedor.MostrarFornecedores();
            int idEscolhido = InputarId();
            Fornecedor fornecedor = repositorioFornecedor.PegarFornecedorPorId(idEscolhido);

            Medicamento medicamento = new Medicamento(nome, descricao, quantidade, quantidadeLimite, fornecedor);

            return medicamento;
        }
        private int InputarId()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                string idDigitado;
                bool letraNoMeio;
                do
                {
                    Console.Write("Digite o Id do Medicamento");
                    idDigitado = Console.ReadLine();
                    letraNoMeio = repositorioMedicamento.VerificarSeTemLetraNoMeio(idDigitado);
                    if (string.IsNullOrEmpty(idDigitado) || letraNoMeio)
                        ApresentarMensagem("Digite um número", ConsoleColor.Red, false);

                } while (string.IsNullOrEmpty(idDigitado) || letraNoMeio);

                idSelecionado = Convert.ToInt32(idDigitado);

                idInvalido = repositorioMedicamento.PegarMedicamentoPorId(idSelecionado) == null;

                if (idInvalido)
                    ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red, false);

            } while (idInvalido);

            return idSelecionado;
        }
        public void MostrarMedicamentosEmFalta()
        {
            Console.Clear();
            ApresentarCabecalhoSimples("Medicamentos em falta:");
            if (repositorioMedicamento.VerificarSeHaMedicamento() == false)
            {
                ApresentarMensagem("Não há medicamentos registrados", ConsoleColor.Red, true);
                return;
            }
            ArrayList listaDeItens = repositorioMedicamento.SelecionarTodos();
            Console.WriteLine($"{"Nome",-20}| Quantidade");
            foreach (Medicamento m in listaDeItens)
            {
                if (m.quantidade < m.quantidadeLimite)
                Console.WriteLine($"{m.nome, -20}| {m.quantidade}");
            }
            Console.ReadLine();
        }
        public void MostrarMedicamentosMaisRetirados()
        {
            Console.Clear();
            ApresentarCabecalhoSimples("Medicamentos mais retirados pela comunidade:");
            if (repositorioMedicamento.VerificarSeHaMedicamento() == false)
            {
                ApresentarMensagem("Não há medicamentos registrados", ConsoleColor.Red, true);
                return;
            }
            ArrayList listaDeItens = repositorioMedicamento.SelecionarTodos();
            ArrayList listaRetirados = new ArrayList();
            foreach (Medicamento m in listaDeItens)
            {
                listaRetirados.Add(m);
            }
            listaRetirados.Sort(new ComparadorQntRetiradas());
            listaRetirados.Reverse();
            Console.WriteLine($"{"Nome", -20}| Quantidade de retiradas");
            foreach (Medicamento m in listaRetirados)
            {
                Console.WriteLine($"{m.nome,-20}| {m.qntRetiradas}");
            }
            Console.ReadLine();
        }
        public string MostrarMenuMedicamento()
        {
            string opcaoMenuMedicamento;
            Console.Clear();
            ApresentarCabecalho("Cadastro de Medicamento", "Menu");
            Console.WriteLine("(1) Cadastrar um novo medicamento");
            Console.WriteLine("(2) Visualizar Medicamentos cadastrados");
            Console.WriteLine("(3) Editar um Medicamento");
            Console.WriteLine("(4) Excluir um Medicamento");
            Console.WriteLine("(5) Mostrar medicamentos em falta");
            Console.WriteLine("(6) Mostrar os medicamentos mais retirados pela comunidade");
            Console.WriteLine("(7) Voltar ao menu principal");
            opcaoMenuMedicamento = Console.ReadLine();
            return opcaoMenuMedicamento;
        }
    }
    
}
