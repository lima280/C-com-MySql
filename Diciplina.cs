using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola
{
    class Diciplina
    {
        private int id;
        private double cargaHoraria;
        private string nome;

        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetId()
        {
            return this.id;
        }

        public void SetCargaHoraria(double cargaHoraria)
        {
            this.cargaHoraria = cargaHoraria;
        }

        public double GetCargaHoraria()
        {
            return this.cargaHoraria;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public string GetNome()
        {
            return this.nome;
        }

        Conexao bd = new Conexao();

        public void InserirDisciplina()
        {
            string inserir = $"insert into tblDisciplinas values(null, '{this.nome}', '{this.cargaHoraria}');";
            bd.ExecutarComando(inserir);
        }

        public void AlterarDisciplina()
        {
            string alterar = $"update tblDisciplinas set nome = '{this.nome}', cargaH = '{this.cargaHoraria}' WHERE id = '{this.id}';";
            bd.ExecutarComando(alterar);
        }

        public void ExcluirDisciplina()
        {
            string deletar = $"delete from tblDisciplinas where id = '{this.id}';";
            bd.ExecutarComando(deletar);
        }

        public DataTable ListarDisciplina()
        {
            string query = "select * from tblDisciplinas order by nome;";
            return bd.ExecutarConsulta(query);
        }
    }
}
