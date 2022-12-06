using AcompanhamentoFisico.BLL;
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
		public DadosPessoais BuscaPorCPF(long CPF)
		{
			DadosPessoais dados = new DadosPessoais();

			ClienteBLL bll = new ClienteBLL();
			dados = bll.retornaDadosPessoaisDoCliente(CPF);

			return dados;
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
