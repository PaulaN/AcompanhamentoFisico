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

		[HttpGet("{CPF}")]
		public CadastroPessoalDTO BuscaPorCPF(long CPF)
		{
			ClienteDAO dao = new ClienteDAO();
			ClienteBLL bll = new ClienteBLL();
			CadastroPessoalDTO cadastroPessoal = new CadastroPessoalDTO();

			cadastroPessoal = bll.retornaDadosPessoaisDoCliente(CPF);

			return cadastroPessoal;
		}


		// POST api/<ClienteController>
		[HttpPost]
		public void Post()
		{

		}

		// PUT api/<ClienteController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<ClienteController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
