using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.Fornecedores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Medicamentos
{
    internal class Medicamento : Entidade
    {
        public string nome;
        public string descricao;
        public int quantidade;
        public int quantidadeLimite;
        public int qntRetiradas;
        public Fornecedor fornecedor;


        public Medicamento(string nome, string descricao, int quantidade, int quantidadeLimite, Fornecedor fornecedor)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.quantidade = quantidade;
            this.quantidadeLimite = quantidadeLimite;
            this.fornecedor = fornecedor;
        }

        ArrayList erros = new ArrayList();
        public ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome))
                erros.Add("Insira o nome");

            if (string.IsNullOrEmpty(descricao))
                erros.Add("Insira a descrição");

            if (string.IsNullOrEmpty(Convert.ToString(quantidade)))
                erros.Add("Insira a quantidade");

            if (string.IsNullOrEmpty(Convert.ToString(quantidadeLimite)))
                erros.Add("Insira a quantidade limite que indica a falta de medicamentos");

            return erros;
        }
    }
}
