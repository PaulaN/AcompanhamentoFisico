using AcompanhamentoFisico.Model;

namespace AcompanhamentoFisico.DTO
{
	public class ProfissionaisDTO
	{
		public long CPFdoCliente { get; set; }
		public NutricionistaDTO nutricionista { get; set; }

		public PersonalTrainerDTO personal { get; set; }

	}
}
