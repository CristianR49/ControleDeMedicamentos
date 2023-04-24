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
    internal class Requisicao : Entidade
    {
        public Funcionario funcionario;
        public Medicamento medicamento;
        public Paciente paciente;
        public string data;
        public int qntMedicamento;
        

        public Requisicao(Funcionario funcionario, Medicamento medicamento, Paciente paciente, string data, int qntMedicamento)
        {
            this.funcionario = funcionario;
            this.medicamento = medicamento;
            this.paciente = paciente;
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
