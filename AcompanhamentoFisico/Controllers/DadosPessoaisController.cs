using AcompanhamentoFisico.BLL;
using AcompanhamentoFisico.DAO;
using AcompanhamentoFisico.DTO;
using AcompanhamentoFisico.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcompanhamentoFisico.Controllers
{
	[Route("api/DadosPessoais")]
	[ApiController]
	public class DadosPessoaisController : ControllerBase
	{
		ClienteDAO dao = new ClienteDAO();
		ClienteBLL bll = new ClienteBLL();

		[HttpGet("{CPF}")]
		public CadastroPessoalDTO BuscaPorCPF(long CPF)
		{
			
			CadastroPessoalDTO cadastroPessoal = new CadastroPessoalDTO();

			cadastroPessoal = bll.retornaDadosPessoaisDoCliente(CPF);

			return cadastroPessoal;
		}


		// POST api/<ClienteController>
		[HttpPost]
		public String Post(CadastroPessoalDTO cadastroPessoal)
		{
			String retorno = bll.insereDadosPessoaisDoCliente(cadastroPessoal);

			return retorno;

		}

		// PUT api/<ClienteController>/5
		[HttpPut]
		public String Put(CadastroPessoalDTO cadastroPessoal)
		{
			String retorno = bll.alteraDadosPessoais(cadastroPessoal);

			return retorno;
		}

		// DELETE api/<ClienteController>/5
		[HttpDelete("{CPF}")]
		public String Delete(long CPF)
		{

			String retorno = bll.deletaDadosPessoais(CPF);

			return retorno;
		}
	}
}
