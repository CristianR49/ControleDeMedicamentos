using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.Fornecedores;
using ControleDeMedicamentos.Funcionarios;
using ControleDeMedicamentos.Medicamentos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Aquisições
{
    internal class Aquisicao : Entidade
    {
        public Fornecedor fornecedor;
        public Medicamento medicamento;
        public Funcionario funcionario;
        public string data;
        public int qntMedicamento;


        public Aquisicao(Fornecedor fornecedor, Medicamento medicamento, Funcionario funcionario, string data, int qntMedicamento)
        {
            this.fornecedor = fornecedor;
            this.medicamento = medicamento;
            this.funcionario = funcionario;
            this.data = data;
            this.qntMedicamento = qntMedicamento;
        }

        ArrayList erros = new ArrayList();
        public ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(data))
                erros.Add("Insira a data");

            if (string.IsNullOrEmpty(Convert.ToString(qntMedicamento)))
                erros.Add("Insira a quantidade de medicamento");

            return erros;
        }
    }
}
