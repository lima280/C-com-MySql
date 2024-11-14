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
    public partial class frmAlunos : Form
    {
        public frmAlunos()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        Conexao bd = new Conexao();

        private void ExibirDados()
        {
            string query = "select * from tblalunos order by nome;";
            dtgAlunos.DataSource = bd.ExecutarConsulta(query);

        }

        private void frmAlunos_Load(object sender, EventArgs e)
        {
            ExibirDados();
        }

        Aluno dadosAluno = new Aluno();

        private void entradaDados()
        {
            char unidade = ' ';
            if (rdbBarroca.Checked)
            {
                unidade = 'B';
            }
            else if (rdbFloresta.Checked)
            {
                unidade = 'F';
            }

            //operador ternario (if em uma linha)
            int serie = rdb1Serie.Checked ? 1 : rdb2Serie.Checked ? 2 : rdb3Serie.Checked ? 3 : 0;

            dadosAluno.SetNome(txtNome.Text);
            dadosAluno.SetIdade(int.Parse(txtIdade.Text));
            dadosAluno.SetTurma(char.Parse(cmbTurma.Text));
            dadosAluno.SetUnidade(unidade);
            dadosAluno.SetSerie(serie);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            entradaDados();
            dadosAluno.InserirAluno();
            MessageBox.Show("Dados inseridos com suesso");
            ExibirDados();
            LimparDados();
        }

        private void LimparDados()
        {
            txtNome.Clear();
            txtIdade.Clear();
            txtID.Clear();
            rdb1Serie.Checked = false;
            rdb2Serie.Checked = false;
            rdb3Serie.Checked = false;
            rdbBarroca.Checked = false;
            rdbFloresta.Checked = false;
            cmbTurma.Text = "";

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            dadosAluno.SetId(int.Parse(txtID.Text));
            entradaDados();
            dadosAluno.AlterarAluno();
            MessageBox.Show("Dados alterados com sucesso");
            ExibirDados();
            LimparDados();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            dadosAluno.SetId(int.Parse(txtID.Text));
            dadosAluno.ExcluirAluno();
            MessageBox.Show("Dados deletados com sucesso");
            ExibirDados();
            LimparDados();
        }

        private void dtgAlunos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dtgAlunos.Rows[e.RowIndex].Cells["id"].Value.ToString();
            txtNome.Text = dtgAlunos.Rows[e.RowIndex].Cells["nome"].Value.ToString();
            txtIdade.Text = dtgAlunos.Rows[e.RowIndex].Cells["idade"].Value.ToString();
            cmbTurma.Text = dtgAlunos.Rows[e.RowIndex].Cells["turma"].Value.ToString();

            if (dtgAlunos.Rows[e.RowIndex].Cells["serie"].Value.ToString() == "1")
                rdb1Serie.Checked = true;
            else if (dtgAlunos.Rows[e.RowIndex].Cells["serie"].Value.ToString() == "2")
                rdb2Serie.Checked = true;
            else if (dtgAlunos.Rows[e.RowIndex].Cells["serie"].Value.ToString() == "3")
                rdb3Serie.Checked = true;

            if (dtgAlunos.Rows[e.RowIndex].Cells["unidade"].Value.ToString() == "B")
                rdbBarroca.Checked = true;
            else if (dtgAlunos.Rows[e.RowIndex].Cells["unidade"].Value.ToString() == "F")
                rdbFloresta.Checked = true;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparDados();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
