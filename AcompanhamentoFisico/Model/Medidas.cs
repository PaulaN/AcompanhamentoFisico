namespace AcompanhamentoFisico.Model
{
	public class Medidas
	{

		public int idMedidas {get; set;}

		public decimal pesoInicial {get; set;}

		public decimal altura {get; set;}

		public decimal IMC {get; set;}

		public decimal pesoAtual {get; set;}

		public decimal pesoObjetivo { get; set; }

		public decimal cmCinturaInicial {get; set;}

		public decimal cmPernaInicial	{get; set;}

		public decimal cmGluteoInicial {get; set;}

		public decimal cmBracoInicial {get; set;}

		public decimal cmPeitoralInicial { get; set; }

		public decimal cmCinturaAtual { get; set; }

		public decimal cmPernaAtual {get; set;}

		public decimal cmGluteoAtual { get; set; }

		public decimal cmBracoAtual { get; set; }

		public decimal cmPeitoralAtual { get; set; }

		public decimal cmCinturaObjetivo { get; set; }

		public decimal cmPernaObjetivo { get; set; }

		public decimal cmGluteoObjetivo { get; set; }

		public decimal cmBracoObjetivo { get; set; }

		public decimal cmPeitoralObjetivo { get; set; }

		public int idCliente { get; set; }
	

	}
}
