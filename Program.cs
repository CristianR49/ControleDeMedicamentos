using ControleDeMedicamentos.Aquisições;
using ControleDeMedicamentos.Fornecedores;
using ControleDeMedicamentos.Funcionarios;
using ControleDeMedicamentos.Medicamentos;
using ControleDeMedicamentos.Requisições;
using ControleDeMedicamentos.Pacientes;

namespace ControleDeMedicamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //perguntar sobre fazer override de algo como o cadastrar?
            //testar o /t que da tab,,., para deixar info do lado

            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente();
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();
            RepositorioRequisicao repositorioRequisicao = new RepositorioRequisicao();
            RepositorioAquisicao repositorioAquisicao = new RepositorioAquisicao();

            TelaMedicamento telaMedicamento = new TelaMedicamento();
            TelaPaciente telaPaciente = new TelaPaciente();
            TelaFuncionario telaFuncionario = new TelaFuncionario();
            TelaFornecedor telaFornecedor = new TelaFornecedor();
            TelaRequisicao telaRequisicao = new TelaRequisicao();
            TelaAquisicao telaAquisicao = new TelaAquisicao();

            telaMedicamento.repositorioMedicamento = repositorioMedicamento;
            telaMedicamento.repositorioFornecedor = repositorioFornecedor;
            telaMedicamento.telaFornecedor = telaFornecedor;
            telaPaciente.repositorioPaciente = repositorioPaciente;
            telaFuncionario.repositorioFuncionario = repositorioFuncionario;
            telaFornecedor.repositorioFornecedor = repositorioFornecedor;
            telaRequisicao.repositorioFuncionario = repositorioFuncionario;
            telaRequisicao.repositorioPaciente = repositorioPaciente;
            telaRequisicao.repositorioRequisicao = repositorioRequisicao;
            telaRequisicao.repositorioMedicamento = repositorioMedicamento;
            telaRequisicao.telaFuncionario = telaFuncionario;
            telaRequisicao.telaMedicamento = telaMedicamento;
            telaRequisicao.telaPaciente = telaPaciente;
            telaAquisicao.telaFornecedor = telaFornecedor;
            telaAquisicao.telaMedicamento = telaMedicamento;
            telaAquisicao.telaFuncionario = telaFuncionario;
            telaAquisicao.repositorioFornecedor = repositorioFornecedor;
            telaAquisicao.repositorioFuncionario = repositorioFuncionario;
            telaAquisicao.repositorioAquisicao = repositorioAquisicao;
            telaAquisicao.repositorioMedicamento = repositorioMedicamento;
            TelaPrincipal telaPrincipal = new TelaPrincipal();

            repositorioFornecedor.CadastrarFornecedorAutomaticamente();
            repositorioFuncionario.CadastrarFuncionarioAutomaticamente();
            repositorioMedicamento.CadastrarMedicamentoAutomaticamente();
            repositorioPaciente.CadastrarPacienteAutomaticamente();
            repositorioRequisicao.CadastrarRequisicaoAutomaticamente();
            repositorioAquisicao.CadastrarAquisicaoAutomaticamente();

            while (true)
            {
                string opcaoMenuPrincipal = telaPrincipal.MostrarMenuPrincipal();

                while (opcaoMenuPrincipal == "1")
                {
                    string opcaoMenuMedicamento = telaMedicamento.MostrarMenuMedicamento();
                    if (opcaoMenuMedicamento == "1")
                    {
                        telaMedicamento.CadastrarMedicamento();
                    }
                    if (opcaoMenuMedicamento == "2")
                    {
                        telaMedicamento.VisualizarMedicamentos();
                    }
                    if (opcaoMenuMedicamento == "3")
                    {
                        telaMedicamento.EditarMedicamento();
                    }
                    if (opcaoMenuMedicamento == "4")
                    {
                        telaMedicamento.ExcluirMedicamento();
                    }
                    if (opcaoMenuMedicamento == "5")
                    {
                        telaMedicamento.MostrarMedicamentosEmFalta();
                    }
                    if (opcaoMenuMedicamento == "6")
                    {
                        telaMedicamento.MostrarMedicamentosMaisRetirados();
                    }
                    if (opcaoMenuMedicamento == "7")
                    {
                        break;
                    }
                }
                while (opcaoMenuPrincipal == "2")
                {
                    string opcaoMenuPaciente = telaPaciente.MostrarMenuPaciente();
                    if (opcaoMenuPaciente == "1")
                    {
                        telaPaciente.CadastrarPaciente();
                    }
                    if (opcaoMenuPaciente == "2")
                    {
                        telaPaciente.VisualizarPacientes();
                    }
                    if (opcaoMenuPaciente == "3")
                    {
                        telaPaciente.EditarPaciente();
                    }
                    if (opcaoMenuPaciente == "4")
                    {
                        telaPaciente.ExcluirPaciente();
                    }
                    if (opcaoMenuPaciente == "5")
                    {
                        break;
                    }
                }
                while (opcaoMenuPrincipal == "3")
                {
                    string opcaoMenuFuncionario = telaFuncionario.MostrarMenuFuncionario();
                    if (opcaoMenuFuncionario == "1")
                    {
                        telaFuncionario.CadastrarFuncionario();
                    }
                    if (opcaoMenuFuncionario == "2")
                    {
                        telaFuncionario.VisualizarFuncionarios();
                    }
                    if (opcaoMenuFuncionario == "3")
                    {
                        telaFuncionario.EditarFuncionario();
                    }
                    if (opcaoMenuFuncionario == "4")
                    {
                        telaFuncionario.ExcluirFuncionario();
                    }
                    if (opcaoMenuFuncionario == "5")
                    {
                        break;
                    }
                }
                while (opcaoMenuPrincipal == "4")
                {
                    string opcaoMenuFornecedor = telaFornecedor.MostrarMenuFornecedor();
                    if (opcaoMenuFornecedor == "1")
                    {
                        telaFornecedor.CadastrarFornecedor();
                    }
                    if (opcaoMenuFornecedor == "2")
                    {
                        telaFornecedor.VisualizarFornecedores();
                    }
                    if (opcaoMenuFornecedor == "3")
                    {
                        telaFornecedor.EditarFornecedor();
                    }
                    if (opcaoMenuFornecedor == "4")
                    {
                        telaFornecedor.ExcluirFornecedor();
                    }
                    if (opcaoMenuFornecedor == "5")
                    {
                        break;
                    }
                }
                while (opcaoMenuPrincipal == "5")
                {
                    string opcaoMenuRequisicao = telaRequisicao.MostrarMenuRequisicao();
                    if (opcaoMenuRequisicao == "1")
                    {
                        telaRequisicao.CadastrarRequisicao();
                    }
                    if (opcaoMenuRequisicao == "2")
                    {
                        telaRequisicao.VisualizarRequisicoes();
                    }
                    if (opcaoMenuRequisicao == "3")
                    {
                        telaRequisicao.EditarRequisicao();
                    }
                    if (opcaoMenuRequisicao == "4")
                    {
                        telaRequisicao.ExcluirRequisicao();
                    }
                    if (opcaoMenuRequisicao == "5")
                    {
                        break;
                    }
                }
                while (opcaoMenuPrincipal == "6")
                {
                    string opcaoMenuAquisicao = telaAquisicao.MostrarMenuAquisicao();
                    if (opcaoMenuAquisicao == "1")
                    {
                        telaAquisicao.CadastrarAquisicao();
                    }
                    if (opcaoMenuAquisicao == "2")
                    {
                        telaAquisicao.VisualizarAquisicoes();
                    }
                    if (opcaoMenuAquisicao == "3")
                    {
                        telaAquisicao.EditarAquisicao();
                    }
                    if (opcaoMenuAquisicao == "4")
                    {
                        telaAquisicao.ExcluirAquisicao();
                    }
                    if (opcaoMenuAquisicao == "5")
                    {
                        break;
                    }


                    if (opcaoMenuPrincipal == "7")
                    {
                        //cadastrar uma requisição
                        //escolher funcionario
                        //escolher paciente
                        //escolher medicamento
                        //se tem o medicamento
                        //quantidade do medicamento
                        //data
                        /*Atualmente, os pacientes requisitam um medicamento e ao fazer a requisição o funcionário do posto verifica a
    disponibilidade do medicamento no sistema e caso o mesmo esteja disponível o atendente dá baixa no sistema
    (atualiza a quantidade) e entrega o medicamento ao paciente que já esteja cadastrado.*/
                    }
                    if (opcaoMenuPrincipal == "8")
                    {
                        ///visualizar medicamentos que passaram da sua quantidade mínima
                        ///
                        /*O sistema deve permitir a possibilidade dos funcionários visualizar os medicamentos com poucas quantidades no
    estoque. Para o posto de saúde é de suma importância que nunca falte remédio para a comunidade. Para isso,
    quando se chega a uma baixa quantidade do medicamento em estoque o posto de saúde deve fazer a solicitação
    da reposição do mesmo junto a um fornecedor, que também é cadastrado no sistema.*/
                    }
                    /*O sistema deve apresentar os medicamentos mais retirados pela comunidade. E também os medicamentos que
                   estão em falta.*/

                    //sistema de login do funcionário
                }

            }
        }
    }
}