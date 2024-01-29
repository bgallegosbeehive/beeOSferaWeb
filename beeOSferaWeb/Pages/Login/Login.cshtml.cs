using beeOSferaWeb.Apis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace beeOSferaWeb.Pages.Login
{
    public class LoginModel : PageModel
    {
        private Api_Usuarios token = new Api_Usuarios();
        private string rutaBase = ("http://localhost:9095/api/");

        public void OnGet()
        {
            TempData.Remove("Mensaje");
        }

        //Metodo que se ejecuta al enviar los datos del formulario//

        public IActionResult OnPost()
        {
            var usuario = "";
            usuario = Request.Form["usuario"];

            var clave = "";
            clave = Request.Form["password"];

            Api_Usuarios Api = new Api_Usuarios();
            string token = Api.obtenerToken(rutaBase, usuario, clave);

            if (token != null)
            {
                string urll = "/Portal/";
                string urldomain = "https://localhost:44392";

                string url = urldomain + urll;

                TempData["MyToken"] = token;
                return new RedirectResult(url);


            }
            else
            {
                TempData["Mensaje"] = "Datos incorrectos.";
                return null;

            }
        }
    }
}