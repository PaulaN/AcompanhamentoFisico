using AcompanhamentoFisico.DTO;
using AcompanhamentoFisico.Model;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AcompanhamentoFisico.DAO
{
	public class ClienteDAO
	{
		String conexao = @"Server=DESKTOP-3TCGI8D;Database=projeto;Trusted_Connection=True;";

		#region Dados Pessoais
		public DadosPessoaisDTO retornaDadosPessoais(long CPF)
		{
			DadosPessoaisDTO dadosPessoaisDTO = new DadosPessoaisDTO();
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

					var configuration = new MapperConfiguration(cfg =>
					{
						cfg.CreateMap<DadosPessoais, DadosPessoaisDTO>();
					});
					var mapper = configuration.CreateMapper();
					dadosPessoaisDTO = mapper.Map<DadosPessoaisDTO>(dadosPessoais);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);

			}
			finally
			{
				con.Close();
			}

			return dadosPessoaisDTO;
		}

		public int insereDadosPessoais(DadosPessoaisDTO dadosPessoaisDTO)
		{

			String retorno = "";
			string sql = "INSERT INTO dbo.DadosPessoais (nome, idade,sexo, CPF) VALUES (" + "'" + dadosPessoaisDTO.nome + "'" + "," + dadosPessoaisDTO.idade  + "," + "'" + dadosPessoaisDTO.sexo + "'" + "," + dadosPessoaisDTO.CPF + ")";
			SqlConnection con = new SqlConnection(conexao);
			SqlCommand cmd = new SqlCommand(sql, con);
			cmd.CommandType = CommandType.Text;
			SqlDataReader reader;
			con.Open();

			int i = cmd.ExecuteNonQuery();
		
			return i;
		}

		public int alteraDadosPessoais(DadosPessoaisDTO dadosPessoaisDTO)
		{

			String retorno = "";
			string sql = "UPDATE dbo.DadosPessoais SET  nome="+ "'" + dadosPessoaisDTO.nome+"'"+ ","+"idade="+dadosPessoaisDTO.idade+","+"sexo="+ "'" +dadosPessoaisDTO.sexo+"'" + "," +"CPF="+dadosPessoaisDTO.CPF+ " where CPF="+ dadosPessoaisDTO.CPF;
			SqlConnection con = new SqlConnection(conexao);
			SqlCommand cmd = new SqlCommand(sql, con);
			cmd.CommandType = CommandType.Text;
			SqlDataReader reader;
			con.Open();

			int i = cmd.ExecuteNonQuery();

			return i;
		}

		public int deletaDadosPessoais(long CPF)
		{
			String retorno = "";
			string sql = "delete from dbo.DadosPessoais where CPF = " + CPF;

			SqlConnection con = new SqlConnection(conexao);
			SqlCommand cmd = new SqlCommand(sql, con);
			cmd.CommandType = CommandType.Text;

			con.Open();

			int i = cmd.ExecuteNonQuery();
			return i;

		}

		#endregion


		#region Endereco
		public EnderecoClienteDTO retornaEndereco(long CPF)
		{
			EnderecoClienteDTO enderecoDTO = new EnderecoClienteDTO();
			EnderecoCliente endereco = new EnderecoCliente();

			string sql = "select endereco.rua,endereco.bairro, endereco.estado, endereco.numero, endereco.cidade from dbo.EnderecoCliente endereco inner join dbo.DadosPessoais dadosPessoais on endereco.idCliente = dadosPessoais.id where CPF =" + CPF;

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

					endereco.rua = reader[0].ToString();
					endereco.bairro = reader[1].ToString();
					endereco.estado = reader[2].ToString();
					endereco.numero = Convert.ToInt32(reader[3]);
					endereco.cidade = reader[4].ToString();

					var configuration = new MapperConfiguration(cfg =>
					{
						cfg.CreateMap<EnderecoCliente, EnderecoClienteDTO>();
					});
					var mapper = configuration.CreateMapper();
					enderecoDTO = mapper.Map<EnderecoClienteDTO>(endereco);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);

			}
			finally
			{
				con.Close();
			}

			return enderecoDTO;
		}

		public int insereEndereco(EnderecoClienteDTO endereco,long CPF)
		{

			String retorno = "";
			string sql = "INSERT INTO dbo.EnderecoCliente (rua,bairro,cidade,estado,numero,idCliente) VALUES (" + "'" + endereco.rua + "'" + "," +"'" + endereco.bairro + "'" + "," +"'"+endereco.cidade+"'"+","+ "'" + endereco.estado+"'"+","+ endereco.numero + ","+ "(select id from dbo.DadosPessoais where CPF="+CPF+")"+" )";
			SqlConnection con = new SqlConnection(conexao);
			SqlCommand cmd = new SqlCommand(sql, con);
			cmd.CommandType = CommandType.Text;
			SqlDataReader reader;
			con.Open();

			int i = cmd.ExecuteNonQuery();
		
			return i;
		}

		public int alteraEndereco(EnderecoClienteDTO endereco,long CPF)
		{

			String retorno = "";
			string sql = "update dbo.EnderecoCliente set rua="+ "'" + endereco.rua + "'" + ","+ "bairro=" +"'" + endereco.bairro + "'" + "," + "cidade=" +"'" + endereco.cidade + "'" + "," +"estado=" + "'" + endereco.estado + "'" + "," +"numero="+ endereco.numero + "where idCliente = (select id from dbo.DadosPessoais where CPF=" + CPF +");";
			SqlConnection con = new SqlConnection(conexao);
			SqlCommand cmd = new SqlCommand(sql, con);
			cmd.CommandType = CommandType.Text;
			SqlDataReader reader;
			con.Open();

			int i = cmd.ExecuteNonQuery();

			return i;
		}

		public int deletaEndereco(long CPF)
		{
			String retorno = "";
			string sql = "delete from dbo.EnderecoCliente where  idCliente = (select id from dbo.DadosPessoais where CPF=" + CPF +");";

			SqlConnection con = new SqlConnection(conexao);
			SqlCommand cmd = new SqlCommand(sql, con);
			cmd.CommandType = CommandType.Text;

			con.Open();

			int i = cmd.ExecuteNonQuery();
			return i;

		}

		#endregion

	}
}
