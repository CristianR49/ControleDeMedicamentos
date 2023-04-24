using ControleDeMedicamentos.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Pacientes
{
    internal class Paciente : Entidade
    {
        public string nome;
        public string cpf;
        public string cartaoSus;
        public string telefone;
        public string endereco;
        
        public Paciente(string nome, string cpf, string cartaoSus, string telefone, string endereco)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.cartaoSus = cartaoSus;
            this.telefone = telefone;
            this.endereco = endereco;
        }

        ArrayList erros = new ArrayList();
        public ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome))
                erros.Add("Insira o nome");

            if (string.IsNullOrEmpty(cpf))
                erros.Add("Insira a descrição");

            if (string.IsNullOrEmpty(cartaoSus))
                erros.Add("Insira o cartão SUS");

            if (string.IsNullOrEmpty(telefone))
                erros.Add("Insira o telefone");
            if (string.IsNullOrEmpty(endereco))
                erros.Add("Insira o endereço");

            return erros;
        }
    }
}
