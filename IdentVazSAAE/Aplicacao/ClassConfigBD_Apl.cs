using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IdentificaVazSAAE.Persistência;
using IdentificaVazSAAE.Domínio;

namespace IdentificaVazSAAE.Aplicação
{
    public class ClassConfigBD_Apl
    {
		public ClassConfigBD_Dom configBD = new ClassConfigBD_Dom();
		public ClassConfigBD_Per Bd = new ClassConfigBD_Per();
		public SqlConnection connection = new SqlConnection();
		public string erro;
		public bool vf;

		/// <summary>
		/// Lista todos os servidores da rede
		/// </summary>
		/// <returns> DataTable com todos os servidores.</returns>
		public DataTable pegaServidores()
		{
			return Bd.Servidores();
		}

		/// <summary>
		/// Lista todos os banco de dados
		/// </summary>
		/// <returns> DataTable com todos os banco de dados.</returns>
		public DataTable pegaBDs()
		{
			return Bd.Bds();
		}

		/// <summary>
		/// Conecta o banco de dados
		/// </summary>
		/// <param name="BD"> Dados do banco de dados</param>
		/// <returns> True para conexão realizada com sucesso e False para conexão não realizada.</returns>
		public bool Conectar(ClassConfigBD_Dom BD)
		{
			if (!Bd.Conectar(BD))
			{
				erro = Bd.erro;
				return false;
			}
			else
			{
				connection = Bd.sqlConnection;
				return true;
			}	
		}
	}
}
