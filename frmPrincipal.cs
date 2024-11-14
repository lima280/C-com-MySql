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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void mnuAlunos_Click(object sender, EventArgs e)
        {
            frmAlunos telaAlunos = new frmAlunos();
            telaAlunos.ShowDialog();
        }

        private void pROFESSORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProfessor telaAlunos = new FrmProfessor();
            telaAlunos.ShowDialog();
        }

        private void dICIPLINAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDisciplina telaAlunos = new FrmDisciplina();
            telaAlunos.ShowDialog();
        }
    }
}
