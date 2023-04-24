using ControleDeMedicamentos.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Funcionarios
{
    internal class Funcionario : Entidade
    {

        public string nome;
        public string cpf;
        public string telefone;
        public string endereco;
        public string login;
        public string senha;

        public Funcionario(string nome, string cpf, string login, string telefone, string endereco, string senha)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.login = login;
            this.telefone = telefone;
            this.endereco = endereco;
            this.senha = senha;
        }

        ArrayList erros = new ArrayList();
        public ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome))
                erros.Add("Insira o nome");

            if (string.IsNullOrEmpty(cpf))
                erros.Add("Insira o CPF");

            if (string.IsNullOrEmpty(telefone))
                erros.Add("Insira o telefone");

            if (string.IsNullOrEmpty(endereco))
                erros.Add("Insira o endereço");

            if (string.IsNullOrEmpty(login))
                erros.Add("Insira o login");

            if (string.IsNullOrEmpty(senha))
                erros.Add("Insira a senha");

            return erros;
        }
    }
}
