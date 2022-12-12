using AcompanhamentoFisico.DAO;
using AcompanhamentoFisico.DTO;
using AcompanhamentoFisico.Model;

namespace AcompanhamentoFisico.BLL
{
	public class ClienteBLL
	{
		ClienteDAO dao = new ClienteDAO();
		String retorno = "";
		int retornoDadosPessoais = 0;
		int retornoEndereco = 0;

		public CadastroPessoalDTO retornaDadosPessoaisDoCliente(long CPF)
		{
			

			
			CadastroPessoalDTO cadastroPessoal = new CadastroPessoalDTO();

			cadastroPessoal.dadosPessoais = dao.retornaDadosPessoais(CPF);
			cadastroPessoal.endereco = dao.retornaEndereco(CPF);


			return cadastroPessoal;
		}

		public String insereDadosPessoaisDoCliente(CadastroPessoalDTO cadastroPessoal)
		{
			 retorno = "";
			retornoDadosPessoais = 0;
			retornoEndereco = 0;

			retornoDadosPessoais =	dao.insereDadosPessoais(cadastroPessoal.dadosPessoais);

			 retornoEndereco = dao.insereEndereco(cadastroPessoal.endereco,cadastroPessoal.dadosPessoais.CPF);

			if (retornoDadosPessoais == 1 && retornoEndereco == 1)
			{
				retorno = "Cadastro realizado com sucesso";
			}
			else if (retornoDadosPessoais == 0)
			{
				retorno = "Não foi possível cadastrar dados pessoais";
			}
			else if (retornoEndereco == 0)
			{
				retorno = "Não foi possível cadastrar endereço";
			}

			return retorno;
		}

		public String alteraDadosPessoais(CadastroPessoalDTO cadastroPessoal)
		{
			retorno = "";
			retornoDadosPessoais = 0;
			retornoEndereco = 0;

			retornoEndereco = dao.alteraEndereco(cadastroPessoal.endereco, cadastroPessoal.dadosPessoais.CPF);
			retornoDadosPessoais = dao.alteraDadosPessoais(cadastroPessoal.dadosPessoais);

			if (retornoDadosPessoais == 1 && retornoEndereco == 1)
			{
				retorno = "Alteração realizada com sucesso";
			}
			else if (retornoDadosPessoais == 0)
			{
				retorno = "Não foi possível alterar dados pessoais";
			}
			else if (retornoEndereco == 0)
			{
				retorno = "Não foi possível alterar endereço";
			}



			return retorno;
		}

		public String deletaDadosPessoais(long CPF)
		{
			retorno = "";
			retornoDadosPessoais = 0;
			retornoEndereco = 0;

			retornoEndereco = dao.deletaEndereco(CPF);
			retornoDadosPessoais = dao.deletaDadosPessoais(CPF);

			if (retornoDadosPessoais == 1 && retornoEndereco == 1)
			{
				retorno = "Dados deletados com sucesso";
			}
			else if (retornoDadosPessoais == 0)
			{
				retorno = "Não foi possível deletar dados pessoais";
			}
			else if (retornoEndereco == 0)
			{
				retorno = "Não foi possível deletar endereço";
			}



			return retorno;
		}


	}
}
