using OdontologicManagment.views;

namespace OdontologicManagment.controllers
{
    public class MenuController
    {
        public MenuController() { }

        public int InicializaMenuPrincipal()
        {
            var menu = new MenuPrincipal();
            var resposta = menu.InitMenu();
            return resposta;

        }
    }
}
