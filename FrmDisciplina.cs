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
    public partial class FrmDisciplina : Form
    {
        public FrmDisciplina()
        {
            InitializeComponent();
        }

        Conexao bd = new Conexao();



        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlDados_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ExibirDados()
        {
            string query = "select * from tblDisciplinas order by nome;";
            dtgDisciplina.DataSource = bd.ExecutarConsulta(query);

        }
        private void FrmDisciplina_Load(object sender, EventArgs e)
        {
            ExibirDados();
        }

        Diciplina dadosDiciplina = new Diciplina();

        private void EntradaDados()
        {
            dadosDiciplina.SetNome(txtNome.Text);
            dadosDiciplina.SetCargaHoraria(double.Parse(txtCargaHoraria.Text));
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            EntradaDados();
            dadosDiciplina.InserirDisciplina();
            MessageBox.Show("Dados inseridos com suesso");
            ExibirDados();
            LimparDados();
        }

        private void LimparDados()
        {
            txtNome.Clear();
            txtCargaHoraria.Clear();
            txtID.Clear();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            dadosDiciplina.SetId(int.Parse(txtID.Text));
            EntradaDados();
            dadosDiciplina.AlterarDisciplina();
            MessageBox.Show("Dados alterados com sucesso");
            ExibirDados();
            LimparDados();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            dadosDiciplina.SetId(int.Parse(txtID.Text));
            dadosDiciplina.ExcluirDisciplina();
            MessageBox.Show("Dados deletados com sucesso");
            ExibirDados();
            LimparDados();
        }

        private void dtgDisciplina_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dtgDisciplina.Rows[e.RowIndex].Cells["id"].Value.ToString();
            txtNome.Text = dtgDisciplina.Rows[e.RowIndex].Cells["nome"].Value.ToString();
            txtCargaHoraria.Text = dtgDisciplina.Rows[e.RowIndex].Cells["cargaH"].Value.ToString();
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
