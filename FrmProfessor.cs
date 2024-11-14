using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoEscola
{
    public partial class FrmProfessor : Form
    {
        public FrmProfessor()
        {
            InitializeComponent();
        }

        private void ExibirDados()
        {
            string query = "select * from tblProfessores order by nome;";
            dtgProfessor.DataSource = bd.ExecutarConsulta(query);

        }
        private void FrmProfessor_Load(object sender, EventArgs e)
        {
            ExibirDados();
            CarregarDiciplinas();
        }

        Conexao bd = new Conexao();
        Professor dadosProfessor = new Professor();

        private void EntradaDados()
        {
            char unidade = ' ';
            if (rdbManha.Checked)
            {
                unidade = 'M';
            }
            else if (rdbTarde.Checked)
            {
                unidade = 'T';
            }
            else if (rdbNoite.Checked)
            {
                unidade = 'N';
            }


            dadosProfessor.SetNome(txtNome.Text);
            dadosProfessor.SetCpf(txtCPF.Text);
            dadosProfessor.SetTelefone(txtTelefone.Text);
            dadosProfessor.SetDiciplina(cmbDisciplina.Text);
            dadosProfessor.SetEscolaridade(cmbEscolaridade.Text);
            dadosProfessor.SetTurno(unidade);
            dadosProfessor.SetDtadmissao(dtpDataAdm.Value);
        }

        private void dtpDataAdm_ValueChanged(object sender, EventArgs e)
        {

        }
        
        private void LimparDados()
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtID.Clear();
            txtTelefone.Clear();
            rdbManha.Checked = false;
            rdbNoite.Checked = false;
            rdbTarde.Checked = false;
            cmbDisciplina.Text = "";
            cmbEscolaridade.Text = "";
            dtpDataAdm.Value = DateTime.Now;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            EntradaDados();
            dadosProfessor.InserirProfessor();
            MessageBox.Show("Dados inseridos com suesso");
            ExibirDados();
            LimparDados();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            dadosProfessor.SetId(int.Parse(txtID.Text));
            EntradaDados();
            dadosProfessor.AlterarProfessor();
            MessageBox.Show("Dados alterados com sucesso");
            ExibirDados();
            LimparDados();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            dadosProfessor.SetId(int.Parse(txtID.Text));
            dadosProfessor.ExcluirProfessor();
            MessageBox.Show("Dados deletados com sucesso");
            ExibirDados();
            LimparDados();
        }

        private void dtgProfessor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dtgProfessor.Rows[e.RowIndex].Cells["id"].Value.ToString();
            txtNome.Text = dtgProfessor.Rows[e.RowIndex].Cells["nome"].Value.ToString();
            txtCPF.Text = dtgProfessor.Rows[e.RowIndex].Cells["cpf"].Value.ToString();
            txtTelefone.Text = dtgProfessor.Rows[e.RowIndex].Cells["telefone"].Value.ToString();
            cmbDisciplina.Text = dtgProfessor.Rows[e.RowIndex].Cells["disciplina"].Value.ToString();
            cmbEscolaridade.Text = dtgProfessor.Rows[e.RowIndex].Cells["escolaridade"].Value.ToString();

            dtpDataAdm.Text = dtgProfessor.Rows[e.RowIndex].Cells["dtadmissao"].Value.ToString();


            if (dtgProfessor.Rows[e.RowIndex].Cells["turno"].Value.ToString() == "M")
                rdbManha.Checked = true;
            else if (dtgProfessor.Rows[e.RowIndex].Cells["turno"].Value.ToString() == "N")
                rdbNoite.Checked = true;
            else if (dtgProfessor.Rows[e.RowIndex].Cells["turno"].Value.ToString() == "T")
                rdbTarde.Checked = true;
            

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparDados();
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        Diciplina dadosDiciplina = new Diciplina();
        private void CarregarDiciplinas()
        {
            cmbDisciplina.DataSource = dadosDiciplina.ListarDisciplina();
            cmbDisciplina.DisplayMember = "nome";
        }
    }
}
