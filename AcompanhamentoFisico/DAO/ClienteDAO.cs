using AcompanhamentoFisico.Model;
using System.Data;
using System.Data.SqlClient;

namespace AcompanhamentoFisico.DAO
{
	public class ClienteDAO
	{
		String conexao = @"Server=DESKTOP-3TCGI8D;Database=projeto;Trusted_Connection=True;";
		public DadosPessoais retornaDadosPessoais(long CPF)
		{
			DadosPessoais dadosPessoais = new DadosPessoais();

			string sql = "select * from dbo.DadosPessoais where CPF=" + CPF ;

			SqlConnection con = new SqlConnection(conexao);
			SqlCommand cmd = new SqlCommand(sql, con);
			cmd.CommandType = CommandType.Text;
			SqlDataReader reader;
			con.Open();

			try
			{
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					dadosPessoais.Id = Convert.ToInt32(reader[0]);
					dadosPessoais.nome = reader[1].ToString();
					dadosPessoais.idade = Convert.ToInt32(reader[2]);
					dadosPessoais.sexo = Convert.ToChar(reader[3]);
					dadosPessoais.CPF = Convert.ToInt64(reader[4]);
				
				}
				else
				{
				}


			}
			catch (Exception ex)
			{

			}
			finally
			{
				con.Close();
			}


			return dadosPessoais;
		}
	}
}
