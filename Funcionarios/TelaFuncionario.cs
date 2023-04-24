using ControleDeMedicamentos.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Funcionarios
{
    internal class TelaFuncionario : Tela
    {
        public RepositorioFuncionario repositorioFuncionario = null;

        public void CadastrarFuncionario()
        {
            ApresentarCabecalho("Cadastro de Funcionarios", "Cadastrar Funcionario");
            Funcionario funcionario;
            funcionario = InformarNovoFuncionario();
            repositorioFuncionario.InserirItem(funcionario);
            ApresentarMensagem("Funcionario cadastrado com sucesso", ConsoleColor.Green, true);
        }
        public void VisualizarFuncionarios()
        {
            ApresentarCabecalho("Cadastro de Funcionarios", "Visualizar Funcionario");
            if (repositorioFuncionario.VerificarSeHaFuncionario() == false)
            {
                ApresentarMensagem("Não há funcionarios registrados", ConsoleColor.Red, true);
                return;
            }
            MostrarFuncionarios();
            Console.ReadLine();
        }

        public void MostrarFuncionarios()
        {
            ArrayList listaDeItens = repositorioFuncionario.SelecionarTodos();
            Console.WriteLine("Funcionarios cadastrados:");
            Console.WriteLine($"{"Id",-2}| {"Nome",-20}| {"CPF",-20}| {"telefone",-20}| {"Endereço", -20}| {"Login",-20}| {"Senha",-20}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            foreach (Funcionario f in listaDeItens)
            {
                Console.WriteLine($"{f.id,-2}| {f.nome,-20}| {f.cpf,-20}| {f.telefone,-20}| {f.endereco,-20}| {f.login,-20}| {f.senha,-20}");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
        }

        public void EditarFuncionario()
        {
            ApresentarCabecalho("Cadastro de Funcionarios", "Editar Funcionario");
            if (repositorioFuncionario.VerificarSeHaFuncionario() == false)
            {
                ApresentarMensagem("Não há funcionarios registrados", ConsoleColor.Red, true);
                return;
            }
            MostrarFuncionarios();
            int idASerEditado = InputarId();

            Funcionario funcionario = InformarNovoFuncionario();
            funcionario.id = idASerEditado;

            repositorioFuncionario.AtualizarFuncionario(idASerEditado, funcionario);
            ApresentarMensagem("Funcionario editado com sucesso!", ConsoleColor.Green, true);
        }
        public void ExcluirFuncionario()
        {
            ApresentarCabecalho("Cadastro de Funcionarios", "Excluir Funcionario");
            if (repositorioFuncionario.VerificarSeHaFuncionario() == false)
            {
                ApresentarMensagem("Não há funcionarios registrados", ConsoleColor.Red, true);
                return;
            }
            MostrarFuncionarios();
            int idASerExcluido = InputarId();

            repositorioFuncionario.ExcluirItem(idASerExcluido);
            repositorioFuncionario.ResetarIdSeAListaForApagada();
            ApresentarMensagem("Funcionario excluído com sucesso!", ConsoleColor.Green, true);

        }

        internal Funcionario InformarNovoFuncionario()
        {

            Console.WriteLine("Digite o nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o CPF");
            string cpf = Console.ReadLine();
            Console.WriteLine("Digite o telefone");
            string telefone = Console.ReadLine();
            Console.WriteLine("Digite o endereço");
            string endereco = Console.ReadLine();
            Console.WriteLine("Digite o login");
            string login = Console.ReadLine();
            Console.WriteLine("Digite a senha");
            string senha = Console.ReadLine();

            Funcionario funcionario = new Funcionario(nome, cpf, login, telefone, endereco, senha);

            return funcionario;
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
                    Console.Write("Digite o Id do Funcionario");
                    idDigitado = Console.ReadLine();
                    letraNoMeio = repositorioFuncionario.VerificarSeTemLetraNoMeio(idDigitado);
                    if (string.IsNullOrEmpty(idDigitado) || letraNoMeio)
                        ApresentarMensagem("Digite um número", ConsoleColor.Red, false);

                } while (string.IsNullOrEmpty(idDigitado) || letraNoMeio);

                idSelecionado = Convert.ToInt32(idDigitado);

                idInvalido = repositorioFuncionario.PegarFuncionarioPorId(idSelecionado) == null;

                if (idInvalido)
                    ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red, false);

            } while (idInvalido);

            return idSelecionado;
        }
        public string MostrarMenuFuncionario()
        {
            string opcaoMenuFuncionario;
            Console.Clear();
            ApresentarCabecalho("Cadastro de Funcionario", "Menu");
            Console.WriteLine("(1) Cadastrar um novo Funcionario");
            Console.WriteLine("(2) Visualizar Funcionarios cadastrados");
            Console.WriteLine("(3) Editar um Funcionario");
            Console.WriteLine("(4) Excluir um Funcionario");
            Console.WriteLine("(5) Voltar ao menu principal");
            opcaoMenuFuncionario = Console.ReadLine();
            return opcaoMenuFuncionario;
        }
    }
}
