using AcompanhamentoFisico.BLL;
using AcompanhamentoFisico.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcompanhamentoFisico.Controllers
{
	[Route("api/Profissionais")]
	[ApiController]
	public class ProfissionaisController : ControllerBase
	{
		ProfissionaisBLL bll = new ProfissionaisBLL();

		
		[HttpGet("{CPF}")]
		public string Get(int id)
		{
			return "value";
		}

		
		[HttpPost]
		public String Post(ProfissionaisDTO profissionaisDTO)
		{
		  String retorno=bll.insereProfissionais(profissionaisDTO);

			return retorno;
		}

		
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
