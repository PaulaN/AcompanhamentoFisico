using AcompanhamentoFisico.DAO;
using AcompanhamentoFisico.DTO;

namespace AcompanhamentoFisico.BLL
{
	public class ProfissionaisBLL
	{
		ProfissionaisDAO dao = new ProfissionaisDAO();
		String retorno = "";
		public String insereProfissionais(ProfissionaisDTO profissionaisDTO)
		{
			dao.InsereNutricionista(profissionaisDTO.nutricionista);
			dao.InserePersonal(profissionaisDTO.personal);

			return retorno;
		}



	}
}
