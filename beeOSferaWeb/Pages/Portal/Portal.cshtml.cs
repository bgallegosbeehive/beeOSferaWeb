using beeOSferaWeb.Apis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

namespace beeOSferaWeb.Pages.Portal
{
    public class PortalModel : PageModel
    {
        private string rutaBase = ("http://localhost:9095/api/");

        public async Task<IActionResult> OnGetAsync()
        {
            if (TempData.TryGetValue("MyToken", out object myToken))
            {
                var token = myToken as string;
                // Usa el token en la función

                Api_Usuarios api = new Api_Usuarios();
                string respuesta = api.validate_token(rutaBase, token);
                if (respuesta != null)
                {
                    return Page();
                }
                else
                {
                    return new RedirectResult(url: "/Login/Login");
                }
            }
            else
            {
                return new RedirectResult(url: "/Login/Login");
            }



        }
    }
}