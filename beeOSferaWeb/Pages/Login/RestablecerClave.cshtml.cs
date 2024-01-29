using beeOSferaWeb.Apis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace beeOSferaWeb.Pages.Login
{
    public class RestablecerClaveModel : PageModel
    {
        private string rutaBase = ("http://localhost:9095/api/");
        private string token = string.Empty;

        public IActionResult OnGet(String token)
        {
            ViewData["token"] = token;

            Api_Usuarios api_validar = new Api_Usuarios();
            string respuesta = api_validar.Validar_Token(token, rutaBase);

            if (respuesta != null)
            {
                return null;
            }
            else
            {
                return new RedirectResult(url: "/Login/Login", permanent: true, preserveMethod: true);
            }
        }

        public RedirectResult OnPost(String token)
        {
            ViewData["token"] = token;

            var clave1 = "";
            clave1 = Request.Form["clave1"];
            var clave2 = "";
            clave2 = Request.Form["clave2"];

            Api_Usuarios api_actualizar = new Api_Usuarios();
            bool respuesta = api_actualizar.enviarClave(rutaBase, clave1, clave2, token);

            if (respuesta)
            {
                return new RedirectResult(url: "/Portal", permanent: true, preserveMethod: true);
            }
            else
            {
                return null;
            }
        }
    }
}

//return new RedirectResult(url: "/Login/RestablecerClave", permanent: true, preserveMethod: true);

//// Obtener la URL completa de la solicitud actual