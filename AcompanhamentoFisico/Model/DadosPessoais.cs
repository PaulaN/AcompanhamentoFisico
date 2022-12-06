using System.Runtime.CompilerServices;

namespace AcompanhamentoFisico.Model
{
	public class DadosPessoais
	{
		public int Id { get; set; }
		public String nome {get;set;}
		public int idade {get;set;}
		public char sexo {get;set;}
		public decimal peso {get;set;}
        public decimal altura { get; set; }
		public int CPF {get; set;}

		public int IdProfissionais { get; set; }

		public int IdMedidas { get; set; }

	}
}
