using beeOSferaWeb.Apis;
using beeOSferaWeb.Apis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Data;

namespace beeOSferaWeb.Pages.Portal.Residencial
{
    public class ActualizarResidencialModel : PageModel
    {

        public string rutaBase = "http://localhost:9095/api/";
        public DataTable Tipos_viviendas { get; set; }

        public DataTable Obtener_tipos_condominios { get; set; }

        public DataTable Obtener_tipos_zonas { get; set; }

        public DataTable Propiedades { get; set; }
        public DataTable Propiedadesid { get; set; }

        private string idVivienda = string.Empty;
        public async Task<IActionResult> OnGet(string id)
        {

            ViewData["id"] = id;
            string identificador = id;

            // Hacer algo con el valor obtenido

            var quierofumar = new Api_Propiedades();
            string propiedad = quierofumar.ObtenerPropiedadID(rutaBase, identificador);

            // Deserializar a objeto anónimo con la propiedad "response"
            var anonObject = new { response = new List<Vivienda>() };
            var rresultt = JsonConvert.DeserializeAnonymousType(propiedad, anonObject);

            // Acceder al valor de la propiedad "response"
            List<Vivienda> viviendas = rresultt.response;

            // Serializar a nuevo JSON sin la clave "response"
            string nuevoJson = JsonConvert.SerializeObject(viviendas);





            var api = new Api_Propiedades();
            string tipoViviendas = api.ObtenerTipoViviendas(rutaBase);

            var result = JsonConvert.DeserializeAnonymousType(tipoViviendas, new { Tipos_viviendas = new List<object>() });

            string popi = JsonConvert.SerializeObject(result.Tipos_viviendas);


            if (nuevoJson != null)
            {
                if (!string.IsNullOrEmpty(popi))
                {
                    //Obtener condominios//

                    var apii = new Api_Propiedades();
                    string Condominios = api.ObtenerCondominios(rutaBase);
                    var resultt = JsonConvert.DeserializeAnonymousType(Condominios, new { Obtener_tipos_condominios = new List<object>() });
                    string popii = JsonConvert.SerializeObject(resultt.Obtener_tipos_condominios);


                    //Obtener zonas//

                    var apiii = new Api_Propiedades();
                    string Zonas = api.ObtenerZonas(rutaBase);
                    var resulttt = JsonConvert.DeserializeAnonymousType(Zonas, new { Obtener_tipos_zonas = new List<object>() });
                    string popiii = JsonConvert.SerializeObject(resulttt.Obtener_tipos_zonas);


                    //Regresa la tabla Tipo de viviendas//
                    Tipos_viviendas = (DataTable)JsonConvert.DeserializeObject(popi, typeof(DataTable));

                    //Regresa la tabla de Condominios//
                    Obtener_tipos_condominios = (DataTable)JsonConvert.DeserializeObject(popii, typeof(DataTable));

                    //Regresa la tabla Zonas//
                    Obtener_tipos_zonas = (DataTable)JsonConvert.DeserializeObject(popiii, typeof(DataTable));

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


        [HttpPost]
        public IActionResult OnPost()
        {

            //Tipo//
            var idVivienda = "";
            idVivienda = Request.Form["idVivienda"];

            var IdTipoVivienda = "";
            IdTipoVivienda = Request.Form["IdTipoVivienda"];

            //Ubicación//
            var calle = "";
            calle = Request.Form["calle"];

            var IdCondominio = "";
            IdCondominio = Request.Form["IdCondominio"];

            var numExt = "";
            numExt = Request.Form["numExt"];

            var numInt = "";
            numInt = Request.Form["numInt"];

            var superficie = "";
            superficie = Request.Form["superficie"];

            var IdZona = "";
            IdZona = Request.Form["IdZona"];



            //Identidad//
            var identificador = "";
            identificador = Request.Form["identificador"];

            var descripcion = "";
            descripcion = Request.Form["descripcion"];


            //Datos Financieros//
            var referenciaPago = "";
            referenciaPago = Request.Form["referenciaPago"];


            //Configuración para visitantes//
            var aceptarVisitas = "";
            aceptarVisitas = Request.Form["aceptarVisitas"];

            var solicitarAutorizacionIngresoVisitantes = "";
            solicitarAutorizacionIngresoVisitantes = Request.Form["solicitarAutorizacionIngresoVisitantes"];

            //Registro//

            var registradaPor = "";
            registradaPor = Request.Form["registradaPor"];


            numInt = string.IsNullOrEmpty(numInt) ? "0" : numInt;
            superficie = string.IsNullOrEmpty(superficie) ? "0" : superficie;
            descripcion = string.IsNullOrEmpty(descripcion) ? "0" : descripcion;
            referenciaPago = string.IsNullOrEmpty(referenciaPago) ? "0" : referenciaPago;


            var api = new Api_Propiedades();
            string resp = api.UpdatePropiedadstring(rutaBase, int.Parse(idVivienda), int.Parse(IdTipoVivienda), calle, int.Parse(IdCondominio), int.Parse(numExt), numInt, int.Parse(superficie), int.Parse(IdZona), identificador, descripcion, referenciaPago, aceptarVisitas, solicitarAutorizacionIngresoVisitantes, int.Parse(registradaPor));
            if (resp != null)
            {
                return Page();
            }
            else
            {
                return new RedirectResult(url: "/Portal/Propiedades");
            }
        }

    }
}