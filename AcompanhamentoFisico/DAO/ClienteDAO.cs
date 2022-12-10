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




		public EnderecoClienteDTO retornaEndereco(long CPF)
		{
			EnderecoClienteDTO enderecoDTO = new EnderecoClienteDTO();
			EnderecoCliente endereco = new EnderecoCliente();

			string sql = "select endereco.rua,endereco.bairro, endereco.estado, endereco.numero from dbo.EnderecoCliente endereco inner join dbo.DadosPessoais dadosPessoais on endereco.idCliente = dadosPessoais.id where CPF =" + CPF;

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
					endereco.cidade = reader[2].ToString();
					endereco.estado = reader[3].ToString();
					endereco.numero = Convert.ToInt32(reader[4]);

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
	}
}
