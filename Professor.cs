using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoEscola
{
    internal class Professor
    {
        private int id;
        private string nome, telefone, cpf, diciplina, escolaridade;
        private DateTime dtadmissao;
        private char turno;

        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetId()
        {
            return this.id;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public string GetNome()
        {
            return this.nome;
        }

        public void SetTelefone(string telefone)
        {
            this.telefone = telefone;
        }

        public string GetTelefone()
        {
            return this.telefone;
        }

        public void SetCpf(string cpf)
        {
            this.cpf = cpf;
        }

        public string GetCpf()
        {
            return this.cpf;
        }

        public void SetDiciplina(string diciplina)
        {
            this.diciplina = diciplina;
        }

        public string GetDiciplina()
        {
            return this.diciplina;
        }

        public void SetEscolaridade(string escolaridade)
        {
            this.escolaridade = escolaridade;
        }

        public string GetEscolaridade()
        {
            return this.escolaridade;
        }

        public void SetTurno(char turno)
        {
            this.turno = turno;
        }

        public int GetTurno()
        {
            return this.turno;
        }

        public void SetDtadmissao(DateTime dtadmissao)
        {
            this.dtadmissao = dtadmissao;
        }

        public DateTime GetDtadmissao()
        {
            return this.dtadmissao;
        }

        Conexao bd = new Conexao();

        public void InserirProfessor()
        {
            string inserir = $"insert into tblProfessores values(null, '{this.nome}', '{this.dtadmissao.ToString("yyyy/MM/dd")}', '{this.cpf}', '{this.telefone}', '{this.diciplina}', '{this.turno}', '{this.escolaridade}');";
            bd.ExecutarComando(inserir);
        }

        public void AlterarProfessor()
        {
            string alterar = $"update tblProfessores set nome = '{this.nome}', dtAdmissao = '{this.dtadmissao.ToString("yyyy/MM/dd")}', cpf = '{this.cpf}', telefone = '{this.telefone}', disciplina = '{this.diciplina}', turno = '{this.turno}', escolaridade = '{this.escolaridade}' WHERE id = '{this.id}';";
            bd.ExecutarComando(alterar);
        }

        public void ExcluirProfessor()
        {
            string deletar = $"delete from tblProfessores where id = '{this.id}';";
            bd.ExecutarComando(deletar);
        }

        public DataTable ListarProfessor()
        {
            string query = "select * from tblProfessores order by nome;";
            return bd.ExecutarConsulta(query);
        }
    }
}
