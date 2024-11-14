using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola
{
    internal class Aluno
    {
        private int id, idade, serie;
        private string nome;
        private char unidade, turma;

        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetId()
        {
            return this.id;
        }

        public void SetIdade(int idade)
        {
            this.idade = idade;
        }

        public int GetIdade()
        {
            return this.idade;
        }

        public void SetSerie(int serie)
        {
            this.serie = serie;
        }

        public int GetSerie()
        {
            return this.serie;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public string GetNome()
        {
            return this.nome;
        }

        public void SetUnidade(char unidade)
        {
            this.unidade = unidade;
        }

        public int GetUnidade()
        {
            return this.unidade;
        }

        public void SetTurma(char turma)
        {
            this.turma = turma;
        }

        public int GetTurma()
        {
            return this.turma;
        }


        //metodos do CRUD
        Conexao bd = new Conexao(); // instacia de classe de conexão

        public void InserirAluno()
        {
            string inserir = $"insert into tblalunos values(null, '{this.nome}', '{this.idade}', '{this.unidade}', '{this.serie}', '{this.turma}');";
            bd.ExecutarComando(inserir);
        }

        public void AlterarAluno()
        {
            string alterar = $"update tblalunos set nome = '{this.nome}', idade = '{this.idade}', unidade = '{this.unidade}', serie = '{this.serie}', turma = '{this.turma}' where id = '{this.id}';";
            bd.ExecutarComando(alterar);
        }

        public void ExcluirAluno()
        {
            string deletar = $"delete from tblalunos where id = '{this.id}';";
            bd.ExecutarComando(deletar);
        }

        public DataTable ListarAlunos()
        {
            string query = "select * from tblalunos orde by nome;";
            return bd.ExecutarConsulta(query);
        }
    }
}
