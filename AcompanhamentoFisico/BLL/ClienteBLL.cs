using AcompanhamentoFisico.DAO;
using AcompanhamentoFisico.DTO;
using AcompanhamentoFisico.Model;

namespace AcompanhamentoFisico.BLL
{
	public class ClienteBLL
	{
		public CadastroPessoalDTO retornaDadosPessoaisDoCliente(long CPF)
		{
			

			ClienteDAO dao = new ClienteDAO();
			CadastroPessoalDTO cadastroPessoal = new CadastroPessoalDTO();

			cadastroPessoal.dadosPessoais = dao.retornaDadosPessoais(CPF);
			cadastroPessoal.endereco = dao.retornaEndereco(CPF);


			return cadastroPessoal;
		}
	}
}
