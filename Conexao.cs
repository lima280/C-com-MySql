using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProjetoEscola
{
    internal class Conexao
    {
        MySqlConnection conn;

        private void Conectar()
        {
            string dadosConexao = "Persist security info = false; server = localhost; database = dbescola; user = root; pwd=;";
            conn = new MySqlConnection(dadosConexao);
            conn.Open();
        }

        public DataTable ExecutarConsulta(string sql)
        {
            Conectar();
            MySqlDataAdapter dados = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();

            dados.Fill(dt);
            conn.Close();
            return dt;
        }

        public void ExecutarComando(string sql)
        {
            Conectar();
            MySqlCommand comado = new MySqlCommand(sql, conn);
            comado.ExecuteNonQuery();
            conn.Close();
        }


    }
}
