using beeOSferaWeb.Apis;
using beeOSferaWeb.Apis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Data;

namespace beeOSferaWeb.Pages.Portal.Residencial
{
    public class ResidencialModel : PageModel
    {
        private string rutaBase = "http://localhost:9095/api/";
        public DataTable Propiedades { get; set; }
        public DataTable Propiedadesid { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var api = new Api_Propiedades();
            string propiedades = api.ObtenerPropiedades(rutaBase);

            var result = JsonConvert.DeserializeAnonymousType(propiedades, new { viviendas = new List<object>() });

            string popi = JsonConvert.SerializeObject(result.viviendas);

            if (!string.IsNullOrEmpty(popi))
            {
                Propiedades = (DataTable)JsonConvert.DeserializeObject(popi, typeof(DataTable));

                return Page();
            }
            else
            {
                TempData["Mensaje"] = "Datos incorrectos.";
                return null;
            }
        }

        public async Task<IActionResult> OnPostEliminar(string eliminarid)
        {
            if (eliminarid != null)
            {
                var apii = new Api_Propiedades();
                string delete = apii.DeletePropiedadID(rutaBase, eliminarid);

                var api = new Api_Propiedades();
                string propiedades = api.ObtenerPropiedades(rutaBase);

                var result = JsonConvert.DeserializeAnonymousType(propiedades, new { viviendas = new List<object>() });

                string popi = JsonConvert.SerializeObject(result.viviendas);

                if (!string.IsNullOrEmpty(popi))
                {
                    Propiedades = (DataTable)JsonConvert.DeserializeObject(popi, typeof(DataTable));

                    return Page();
                }
                else
                {
                    TempData["Mensaje"] = "Datos incorrectos.";
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public IActionResult OnPostConsultar(string identificador, string idVivienda)
        {
            // Hacer algo con el valor obtenido
            if (!string.IsNullOrEmpty(identificador))
            {
                var api = new Api_Propiedades();
                string propiedad = api.ObtenerPropiedadID(rutaBase, identificador);

                // Deserializar a objeto anónimo con la propiedad "response"
                var anonObject = new { response = new List<Vivienda>() };
                var result = JsonConvert.DeserializeAnonymousType(propiedad, anonObject);

                // Acceder al valor de la propiedad "response"
                List<Vivienda> viviendas = result.response;

                // Serializar a nuevo JSON sin la clave "response"
                string nuevoJson = JsonConvert.SerializeObject(viviendas);

                if (nuevoJson != null)
                {
                    var apii = new Api_Propiedades();
                    string propiedades = apii.ObtenerPropiedades(rutaBase);

                    var resultt = JsonConvert.DeserializeAnonymousType(propiedades, new { viviendas = new List<object>() });

                    string popi = JsonConvert.SerializeObject(resultt.viviendas);

                    if (!string.IsNullOrEmpty(popi))
                    {
                        Propiedades = (DataTable)JsonConvert.DeserializeObject(popi, typeof(DataTable));
                        Propiedadesid = (DataTable)JsonConvert.DeserializeObject(nuevoJson, typeof(DataTable));
                        return Page();
                    }
                    else
                    {
                        TempData["Mensaje"] = "Datos incorrectos.";
                        return null;
                    }
                }
                else
                {
                    TempData["Mensaje"] = "Datos incorrectos.";
                    return null;
                }
            }
            else
            {
                if (idVivienda != null)
                {
                    string urll = "/Portal/ActualizarResidencial/";
                    string urldomain = "https://localhost:44392";

                    string url = urldomain + urll + "?id=" + idVivienda;

                    return new RedirectResult(url);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}