using beeOSferaWeb.Apis;
using beeOSferaWeb.Apis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace beeOSferaWeb.Pages.Login
{
    public class EnviarCorreoModel : PageModel
    {
        private RecuperarPass correo = new RecuperarPass();
        private string rutaBase = ("http://localhost:9095/api/");

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var correo = "";
            correo = Request.Form["correo"];
            string urll = "/Login/RestablecerClave/";
            string urldomain = "https://localhost:44392";

            Api_Usuarios Api = new Api_Usuarios();
            string token = Api.enviarCorreo(rutaBase, correo, urll, urldomain);

            if (token != null)
            {
                return new RedirectResult(url: "/", permanent: true, preserveMethod: true);
            }
            else
            {
                TempData["Mensaje"] = "Datos incorrectos.";
                return null;
            }
        }
    }
}