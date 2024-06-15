using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontologicManagment.views
{
    internal class CadastroConsulta : MenuTemplate
    {
        public CadastroConsulta() : base(
            "Agenda",
            "Agendar consulta",
            "Cancelar agendamento",
            "Listar agenda",
            "Voltar p/ menu principal"
            )
        {
        }
    }
}
