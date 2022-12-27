using AcompanhamentoFisico.Model;
using System.Data.SqlClient;
using System.Data;
using AcompanhamentoFisico.DTO;

namespace AcompanhamentoFisico.DAO
{
	public class ProfissionaisDAO
	{
		String conexao = @"Server=DESKTOP-3TCGI8D;Database=projeto;Trusted_Connection=True;";
		public string InsereNutricionista(NutricionistaDTO nutricionistaDTO)
		{
			String retorno = "";
			string sql = "INSERT INTO dbo.Nutricionista (nome,CRN) VALUES (" + "'" + nutricionistaDTO.nome + "'" + "," + "'" + nutricionistaDTO.CRN + "'" + ")";
			
			SqlConnection con = new SqlConnection(conexao);
			SqlCommand cmd = new SqlCommand(sql, con);
			cmd.CommandType = CommandType.Text;
			SqlDataReader reader;
			con.Open();
			int i = cmd.ExecuteNonQuery();

			return retorno;
		}


		public string InserePersonal(PersonalTrainerDTO personalTrainerDTO)
		{
			String retorno = "";
			string sql = "INSERT INTO dbo.Personaltrainer (nome,CREF) VALUES (" + "'" + personalTrainerDTO.nome + "'" + "," + "'" + personalTrainerDTO.CREF + "'" + ")";

			SqlConnection con = new SqlConnection(conexao);
			SqlCommand cmd = new SqlCommand(sql, con);
			cmd.CommandType = CommandType.Text;
			SqlDataReader reader;
			con.Open();
			int i = cmd.ExecuteNonQuery();

			return retorno;
		}

	}
}
