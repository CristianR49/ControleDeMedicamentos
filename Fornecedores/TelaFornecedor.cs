using ControleDeMedicamentos.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Fornecedores
{
    internal class TelaFornecedor : Tela
    {

        public RepositorioFornecedor repositorioFornecedor = null;

        public void CadastrarFornecedor()
        {
            ApresentarCabecalho("Cadastro de Fornecedores", "Cadastrar Fornecedor");
            Fornecedor fornecedor;
            fornecedor = InformarNovoFornecedor();
            repositorioFornecedor.InserirItem(fornecedor);
            ApresentarMensagem("Fornecedor cadastrado com sucesso", ConsoleColor.Green, true);
        }
        public void VisualizarFornecedores()
        {
            ApresentarCabecalho("Cadastro de Fornecedores", "Visualizar Fornecedor");
            if (repositorioFornecedor.VerificarSeHaFornecedor() == false)
            {
                ApresentarMensagem("Não há fornecedores registrados", ConsoleColor.Red, true);
                return;
            }
            MostrarFornecedores();
            Console.ReadLine();
        }

        public void MostrarFornecedores()
        {
            ArrayList listaDeItens = repositorioFornecedor.SelecionarTodos();
            Console.WriteLine("Fornecedores cadastrados:");
            Console.WriteLine($"{"Id",-2}| {"Nome",-20}| {"telefone",-20}| {"Endereço",-20}| {"CNPJ",-20}| {"Email",-20}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            foreach (Fornecedor f in listaDeItens)
            {
                Console.WriteLine($"{f.id,-2}| {f.nome,-20}| {f.telefone,-20}| {f.endereco,-20}| {f.cnpj,-20}| {f.email,-20}");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
        }

        public void EditarFornecedor()
        {
            ApresentarCabecalho("Cadastro de Fornecedores", "Editar Fornecedor");
            if (repositorioFornecedor.VerificarSeHaFornecedor() == false)
            {
                ApresentarMensagem("Não há fornecedores registrados", ConsoleColor.Red, true);
                return;
            }
            MostrarFornecedores();
            int idASerEditado = InputarId();

            Fornecedor fornecedor = InformarNovoFornecedor();
            fornecedor.id = idASerEditado;

            repositorioFornecedor.AtualizarFornecedor(idASerEditado, fornecedor);
            ApresentarMensagem("Fornecedor editado com sucesso!", ConsoleColor.Green, true);
        }
        public void ExcluirFornecedor()
        {
            ApresentarCabecalho("Cadastro de Fornecedores", "Excluir Fornecedor");
            if (repositorioFornecedor.VerificarSeHaFornecedor() == false)
            {
                ApresentarMensagem("Não há fornecedores registrados", ConsoleColor.Red, true);
                return;
            }
            MostrarFornecedores();
            int idASerExcluido = InputarId();

            repositorioFornecedor.ExcluirItem(idASerExcluido);
            repositorioFornecedor.ResetarIdSeAListaForApagada();
            ApresentarMensagem("Fornecedor excluído com sucesso!", ConsoleColor.Green, true);

        }

        internal Fornecedor InformarNovoFornecedor()
        {

            Console.WriteLine("Digite o nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o CPF");
            string cpf = Console.ReadLine();
            Console.WriteLine("Digite o telefone");
            string telefone = Console.ReadLine();
            Console.WriteLine("Digite o endereço");
            string endereco = Console.ReadLine();
            Console.WriteLine("Digite o cnpj");
            string cnpj = Console.ReadLine();
            Console.WriteLine("Digite a email");
            string email = Console.ReadLine();

            Fornecedor fornecedor = new Fornecedor(nome, cnpj, telefone, endereco, email);

            return fornecedor;
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
                    Console.Write("Digite o Id do Fornecedor");
                    idDigitado = Console.ReadLine();
                    letraNoMeio = repositorioFornecedor.VerificarSeTemLetraNoMeio(idDigitado);
                    if (string.IsNullOrEmpty(idDigitado) || letraNoMeio)
                        ApresentarMensagem("Digite um número", ConsoleColor.Red, false);

                } while (string.IsNullOrEmpty(idDigitado) || letraNoMeio);

                idSelecionado = Convert.ToInt32(idDigitado);

                idInvalido = repositorioFornecedor.PegarFornecedorPorId(idSelecionado) == null;

                if (idInvalido)
                    ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red, false);

            } while (idInvalido);

            return idSelecionado;
        }
        public string MostrarMenuFornecedor()
        {
            string opcaoMenuFornecedor;
            Console.Clear();
            ApresentarCabecalho("Cadastro de Fornecedor", "Menu");
            Console.WriteLine("(1) Cadastrar um novo Fornecedor");
            Console.WriteLine("(2) Visualizar Fornecedores cadastrados");
            Console.WriteLine("(3) Editar um Fornecedor");
            Console.WriteLine("(4) Excluir um Fornecedor");
            Console.WriteLine("(5) Voltar ao menu principal");
            opcaoMenuFornecedor = Console.ReadLine();
            return opcaoMenuFornecedor;
        }
    }
}
