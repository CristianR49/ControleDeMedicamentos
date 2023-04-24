using ControleDeMedicamentos.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Fornecedores
{
    internal class Fornecedor : Entidade
    {
        public string nome;
        public string telefone;
        public string endereco;
        public string cnpj;
        public string email;

        public Fornecedor(string nome, string cnpj, string telefone, string endereco, string email)
        {
            this.nome = nome;
            this.cnpj = cnpj;
            this.telefone = telefone;
            this.endereco = endereco;
            this.email = email;
        }

        ArrayList erros = new ArrayList();
        public ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome))
                erros.Add("Insira o nome");

            if (string.IsNullOrEmpty(telefone))
                erros.Add("Insira o telefone");

            if (string.IsNullOrEmpty(endereco))
                erros.Add("Insira o endereço");

            if (string.IsNullOrEmpty(cnpj))
                erros.Add("Insira o CNPJ");

            if (string.IsNullOrEmpty(email))
                erros.Add("Insira o email");

            return erros;
        }

    }
}
