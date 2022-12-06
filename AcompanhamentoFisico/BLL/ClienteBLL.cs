using AcompanhamentoFisico.DAO;
using AcompanhamentoFisico.Model;

namespace AcompanhamentoFisico.BLL
{
	public class ClienteBLL
	{
		public DadosPessoais retornaDadosPessoaisDoCliente(long CPF)
		{
			DadosPessoais dadosPessoais = new DadosPessoais();

			ClienteDAO dao = new ClienteDAO();

			dadosPessoais = dao.retornaDadosPessoais(CPF);

			return dadosPessoais;
		}
	}
}
