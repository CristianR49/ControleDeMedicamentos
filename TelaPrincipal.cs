using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.Medicamentos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos
{
    internal class TelaPrincipal : Tela
    {
        public string MostrarMenuPrincipal()
        {
            string opcaoMenuPrincipal;
            Console.Clear();
            ApresentarCabecalho("Controle de medicamentos", "Menu Principal");
            Console.WriteLine("(1) Menu cadastro de Medicamentos");
            Console.WriteLine("(2) Menu cadastro de Pacientes");
            Console.WriteLine("(3) Menu cadastro de Funcionários");
            Console.WriteLine("(4) Menu cadastro de Fornecedores");
            Console.WriteLine("(5) Menu cadastro de Requisições");
            Console.WriteLine("(6) Menu cadastro de Aquisições");
            Console.WriteLine("(7) Sair");
            opcaoMenuPrincipal = Console.ReadLine();
            return opcaoMenuPrincipal;
        }
    }
}
