using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontologicManagment.views
{
    internal class CadastroCliente : MenuTemplate
    {
        public CadastroCliente() : base(
            "Menu do Cadastro de Pacientes", 
            "Cadastrar novo paciente", 
            "Excluir paciente",
            "Listar pacientes (ordenado por CPF)",
            "Listar pacientes (ordenado por nome)",
            "Voltar p/ menu principal"
            )
        {
        }
    }
}
