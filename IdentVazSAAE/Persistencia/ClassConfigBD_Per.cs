using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

using IdentificaVazSAAE.Domínio;

namespace IdentificaVazSAAE.Persistência
{
    public class ClassConfigBD_Per
    {
		public SqlConnection sqlConnection = new SqlConnection();
		public SqlDataAdapter adaptador;
		public SqlCommand comando;
		public DataTable bds;
		public string erro;

		/// <summary>
		/// Retorna em um DataTable os nomes dos servidores disponíveis
		/// </summary>
		/// <returns>Nome dos servidores</returns>
		public DataTable Servidores()
		{
			return SqlDataSourceEnumerator.Instance.GetDataSources();
		}

		/// <summary>
		/// Retorna em um DataTable os bancos de dados anexados ao servidor informado
		/// </summary>
		/// <returns>Bancos de dados anexados</returns>
		public DataTable Bds()
		{
			try
			{
				adaptador = new SqlDataAdapter();
				comando = new SqlCommand();
				bds = new DataTable();
				erro = "";

				comando.Connection = sqlConnection;
				adaptador.SelectCommand = comando;

				comando.CommandText = "SELECT name FROM master..sysdatabases WHERE name not in('master', 'model', 'msdb', 'tempdb', 'reportserver', 'reportservertempdb')ORDER BY name";
				sqlConnection.Open();
				adaptador.SelectCommand.ExecuteNonQuery();
				adaptador.Fill(bds);
			}
			catch (Exception error)
			{
				erro = error.Message;
			}
			finally
			{
				sqlConnection.Close();
			}

			return bds;
		}

		/// <summary>
		/// Define a conexão com autenticação WINDOWS
		/// </summary>
		/// <param name="configurarBD"></param>
		/// <returns>Conexão ok</returns>
		public bool Conectar(ClassConfigBD_Dom configurarBD)
		{
			try
			{
				erro = "";
				sqlConnection = new SqlConnection();

				if (configurarBD.Autenticação == "Windows")
					sqlConnection.ConnectionString = "Server=" + configurarBD.Servidor + "\\" + configurarBD.Instância + ";Database=" + configurarBD.Bd + ";Trusted_Connection=True";
				else
					sqlConnection.ConnectionString = "Server=" + configurarBD.Servidor + "\\" + configurarBD.Instância + ";Database=" + configurarBD.Bd + ";User Id=" + configurarBD.Usuário + ";Password=" + configurarBD.Senha;

				sqlConnection.Open();
				return true;
			}
			catch (Exception error)
			{
				erro = error.Message;
				return false;
			}
			finally
			{
				sqlConnection.Close();
			}
		}
	}
}
