using System.Runtime.CompilerServices;

namespace AcompanhamentoFisico.Model
{
	public class DadosPessoais
	{
		public int Id { get; set; }
		public String nome {get;set;}
		public char sexo {get;set;}
		public long CPF {get; set;}

		public String dataNascimento { get; set; }
		public int IdProfissionais { get; set; }

		public int IdMedidas { get; set; }

	}
}
