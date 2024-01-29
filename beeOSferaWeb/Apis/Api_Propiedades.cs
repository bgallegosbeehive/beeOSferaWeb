using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace beeOSferaWeb.Apis
{
    public class Api_Propiedades : Controller
    {
        public string ObtenerPropiedades(string rutaBase)
        {
            var url = rutaBase + $"propiedades/consultar_propiedades";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                //request.PreAuthenticate = true;
                //request.Headers.Add("Authorization", "Bearer " + token);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Timeout = 5000;
                HttpWebResponse response = null;
                HttpStatusCode statusCode;

                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    //MessageBox.Show(ex.Message);
                    response = (HttpWebResponse)ex.Response;
                }

                if (response != null)
                {
                    statusCode = response.StatusCode;

                    //MessageBox.Show(statusCode .ToString ());
                    if (statusCode == HttpStatusCode.OK)
                    {
                        Stream dataStream = response.GetResponseStream();
                        if (dataStream != null)
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string responseBody = reader.ReadToEnd();

                            return responseBody;
                        }
                    }
                    else
                    {
                        Stream dataStream = response.GetResponseStream();
                        if (dataStream != null)
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string responseBody = reader.ReadToEnd();
                        }
                    }

                    response.Close();
                    response.Dispose();
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public string ObtenerPropiedadID(string rutaBase, string identificador)
        {
            string ID_POPIEDAD = identificador;
            var url = rutaBase + $"propiedades/consultar_propiedades_id/{ID_POPIEDAD:int}";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                //request.PreAuthenticate = true;
                //request.Headers.Add("Authorization", "Bearer " + token);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Timeout = 5000;
                HttpWebResponse response = null;
                HttpStatusCode statusCode;

                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    //MessageBox.Show(ex.Message);
                    response = (HttpWebResponse)ex.Response;
                }

                if (response != null)
                {
                    statusCode = response.StatusCode;

                    //MessageBox.Show(statusCode .ToString ());
                    if (statusCode == HttpStatusCode.OK)
                    {
                        Stream dataStream = response.GetResponseStream();
                        if (dataStream != null)
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string responseBody = reader.ReadToEnd();

                            return responseBody;
                        }
                    }
                    else
                    {
                        Stream dataStream = response.GetResponseStream();
                        if (dataStream != null)
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string responseBody = reader.ReadToEnd();
                        }
                    }

                    response.Close();
                    response.Dispose();
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public string UpdatePropiedadstring (string rutaBase, int idVivienda, int IdTipoVivienda, string calle, int IdCondominio, int numExt, string numInt, int superficie , int IdZona, string identificador, string descripcion, string referenciaPago, string aceptarVisitas, string solicitarAutorizacionIngresoVisitantes, int registradaPor)
        {
            
            var url = rutaBase + $"propiedades/actualizar_propiedad";
            // Especificar la URL del endpoint de la API.

            // Crear una instancia de HttpWebRequest.
            var request = (HttpWebRequest)WebRequest.Create(url);

            // Configurar la solicitud.
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Timeout = 5000;

            // Agregar los datos que deseas enviar en el cuerpo de la solicitud.
            string json = "{\"idVivienda\":\"" + idVivienda + "\"," +
            "\"identificador\":\"" + identificador + "\"," +
            "\"descripcion\":\"" + descripcion + "\"," +
            "\"idCondominio\":\"" + IdCondominio + "\"," +
            "\"calle\":\"" + calle + "\"," +
            "\"numExt\":\"" + numExt + "\"," +
            "\"numInt\":\"" + numInt + "\"," +
            "\"registradaPor\":\"" + registradaPor + "\"," +
            "\"idTipoVivienda\":\"" + IdTipoVivienda + "\"," +
            "\"solicitarAutorizacionIngresoVisitantes\":\"" + solicitarAutorizacionIngresoVisitantes + "\"," +
            "\"aceptarVisitas\":\"" + aceptarVisitas + "\"," +
            "\"referenciaPago\":\"" + referenciaPago + "\"," +
            "\"superficie\":\"" + superficie + "\"," +
            "\"idZona\":\"" + IdZona + "\"}";

            byte[] data = Encoding.UTF8.GetBytes(json);
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            // Enviar la solicitud al servidor y recibir la respuesta.
            HttpWebResponse response = null;
            HttpStatusCode statusCode;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                statusCode = response.StatusCode;
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
                statusCode = response.StatusCode;
            }

            // Leer la respuesta y cerrar la conexión.
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                Console.WriteLine("Response: " + result);
            }
            response.Close();

            // Analizar la respuesta para asegurarte de que la solicitud fue exitosa.
            if (statusCode == HttpStatusCode.OK || statusCode == HttpStatusCode.NoContent)
            {
                Console.WriteLine("La solicitud se ha completado correctamente.");
            }
            else
            {
                Console.WriteLine("Se ha producido un error al intentar llamar al API. El código de estado devuelto es: " + statusCode);
            }
            return null;
        }

        public string DeletePropiedadID(string rutaBase, string eliminarid)
        {
            string ID_POPIEDAD = eliminarid;
            var url = rutaBase + $"propiedades/eliminar_propiedad/{ID_POPIEDAD:int}";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                //request.PreAuthenticate = true;
                //request.Headers.Add("Authorization", "Bearer " + token);
                request.Method = "DELETE";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Timeout = 5000;
                HttpWebResponse response = null;
                HttpStatusCode statusCode;

                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    //MessageBox.Show(ex.Message);
                    response = (HttpWebResponse)ex.Response;
                }

                if (response != null)
                {
                    statusCode = response.StatusCode;

                    //MessageBox.Show(statusCode .ToString ());
                    if (statusCode == HttpStatusCode.OK)
                    {
                        Stream dataStream = response.GetResponseStream();
                        if (dataStream != null)
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string responseBody = reader.ReadToEnd();

                            return responseBody;
                        }
                    }
                    else
                    {
                        Stream dataStream = response.GetResponseStream();
                        if (dataStream != null)
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string responseBody = reader.ReadToEnd();
                        }
                    }

                    response.Close();
                    response.Dispose();
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public string AgregarPropiedadID(string rutaBase, int IdTipoVivienda, string calle, int IdCondominio, int numExt, string numInt, int superficie, int IdZona, string identificador, string descripcion, string referenciaPago, string aceptarVisitas, string solicitarAutorizacionIngresoVisitantes, int registradaPor)
        {
            var url = rutaBase + $"propiedades/agregar_propiedad";
            // Especificar la URL del endpoint de la API.

            // Crear una instancia de HttpWebRequest.
            var request = (HttpWebRequest)WebRequest.Create(url);

            // Configurar la solicitud.
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Timeout = 5000;

            // Agregar los datos que deseas enviar en el cuerpo de la solicitud.
            string json = "{\"identificador\":\"" + identificador + "\"," +
            "\"descripcion\":\"" + descripcion + "\"," +
            "\"idCondominio\":\"" + IdCondominio + "\"," +
            "\"calle\":\"" + calle + "\"," +
            "\"numExt\":\"" + numExt + "\"," +
            "\"numInt\":\"" + numInt + "\"," +
            "\"registradaPor\":\"" + registradaPor + "\"," +
            "\"idTipoVivienda\":\"" + IdTipoVivienda + "\"," +
            "\"solicitarAutorizacionIngresoVisitantes\":\"" + solicitarAutorizacionIngresoVisitantes + "\"," +
            "\"aceptarVisitas\":\"" + aceptarVisitas + "\"," +
            "\"referenciaPago\":\"" + referenciaPago + "\"," +
            "\"superficie\":\"" + superficie + "\"," +
            "\"idZona\":\"" + IdZona + "\"}";

            byte[] data = Encoding.UTF8.GetBytes(json);
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            // Enviar la solicitud al servidor y recibir la respuesta.
            HttpWebResponse response = null;
            HttpStatusCode statusCode;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                statusCode = response.StatusCode;
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
                statusCode = response.StatusCode;
            }

            // Leer la respuesta y cerrar la conexión.
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                Console.WriteLine("Response: " + result);
            }
            response.Close();

            // Analizar la respuesta para asegurarte de que la solicitud fue exitosa.
            if (statusCode == HttpStatusCode.OK || statusCode == HttpStatusCode.NoContent)
            {
                string sap = "1";
                return sap;
            }
            else
            {
                Console.WriteLine("Se ha producido un error al intentar llamar al API. El código de estado devuelto es: " + statusCode);
            }
            return null;
        }

        public string ObtenerTipoViviendas(string rutaBase)
        {
            var url = rutaBase + $"propiedades/Obtener_tipos_viviendas";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                //request.PreAuthenticate = true;
                //request.Headers.Add("Authorization", "Bearer " + token);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Timeout = 5000;
                HttpWebResponse response = null;
                HttpStatusCode statusCode;

                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    //MessageBox.Show(ex.Message);
                    response = (HttpWebResponse)ex.Response;
                }

                if (response != null)
                {
                    statusCode = response.StatusCode;

                    //MessageBox.Show(statusCode .ToString ());
                    if (statusCode == HttpStatusCode.OK)
                    {
                        Stream dataStream = response.GetResponseStream();
                        if (dataStream != null)
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string responseBody = reader.ReadToEnd();

                            return responseBody;
                        }
                    }
                    else
                    {
                        Stream dataStream = response.GetResponseStream();
                        if (dataStream != null)
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string responseBody = reader.ReadToEnd();
                        }
                    }

                    response.Close();
                    response.Dispose();
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public string ObtenerCondominios(string rutaBase)
        {
            var url = rutaBase + $"propiedades/Obtener_condominios";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                //request.PreAuthenticate = true;
                //request.Headers.Add("Authorization", "Bearer " + token);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Timeout = 5000;
                HttpWebResponse response = null;
                HttpStatusCode statusCode;

                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    //MessageBox.Show(ex.Message);
                    response = (HttpWebResponse)ex.Response;
                }

                if (response != null)
                {
                    statusCode = response.StatusCode;

                    //MessageBox.Show(statusCode .ToString ());
                    if (statusCode == HttpStatusCode.OK)
                    {
                        Stream dataStream = response.GetResponseStream();
                        if (dataStream != null)
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string responseBody = reader.ReadToEnd();

                            return responseBody;
                        }
                    }
                    else
                    {
                        Stream dataStream = response.GetResponseStream();
                        if (dataStream != null)
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string responseBody = reader.ReadToEnd();
                        }
                    }

                    response.Close();
                    response.Dispose();
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public string ObtenerZonas(string rutaBase)
        {
            var url = rutaBase + $"propiedades/Obtener_Zonas";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                //request.PreAuthenticate = true;
                //request.Headers.Add("Authorization", "Bearer " + token);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Timeout = 5000;
                HttpWebResponse response = null;
                HttpStatusCode statusCode;

                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    //MessageBox.Show(ex.Message);
                    response = (HttpWebResponse)ex.Response;
                }

                if (response != null)
                {
                    statusCode = response.StatusCode;

                    //MessageBox.Show(statusCode .ToString ());
                    if (statusCode == HttpStatusCode.OK)
                    {
                        Stream dataStream = response.GetResponseStream();
                        if (dataStream != null)
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string responseBody = reader.ReadToEnd();

                            return responseBody;
                        }
                    }
                    else
                    {
                        Stream dataStream = response.GetResponseStream();
                        if (dataStream != null)
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string responseBody = reader.ReadToEnd();
                        }
                    }

                    response.Close();
                    response.Dispose();
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        //public string AgregarImagen(string rutaBase, string titulo, string imagen)
        //{
        //    var url = rutaBase + $"propiedades/actualizar_propiedad";
        //    // Especificar la URL del endpoint de la API.

        //    // Crear una instancia de HttpWebRequest.
        //    var request = (HttpWebRequest)WebRequest.Create(url);

        //    // Configurar la solicitud.
        //    request.Method = "PUT";
        //    request.ContentType = "application/json";
        //    request.Accept = "application/json";
        //    request.Timeout = 5000;

        //    // Agregar los datos que deseas enviar en el cuerpo de la solicitud.
        //    string json = "{\"titulo\":\"" + titulo + "\"," +
        //      "\"imagen\":\"" + imagen + "\"}";

        //    byte[] data = Encoding.UTF8.GetBytes(json);
        //    request.ContentLength = data.Length;

        //    using (var stream = request.GetRequestStream())
        //    {
        //        stream.Write(data, 0, data.Length);
        //    }

        //    // Enviar la solicitud al servidor y recibir la respuesta.
        //    HttpWebResponse response = null;
        //    HttpStatusCode statusCode;

        //    try
        //    {
        //        response = (HttpWebResponse)request.GetResponse();
        //        statusCode = response.StatusCode;
        //    }
        //    catch (WebException ex)
        //    {
        //        response = (HttpWebResponse)ex.Response;
        //        statusCode = response.StatusCode;
        //    }

        //    // Leer la respuesta y cerrar la conexión.
        //    using (var streamReader = new StreamReader(response.GetResponseStream()))
        //    {
        //        string result = streamReader.ReadToEnd();
        //        Console.WriteLine("Response: " + result);
        //    }
        //    response.Close();

        //    // Analizar la respuesta para asegurarte de que la solicitud fue exitosa.
        //    if (statusCode == HttpStatusCode.OK || statusCode == HttpStatusCode.NoContent)
        //    {
        //        Console.WriteLine("La solicitud se ha completado correctamente.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Se ha producido un error al intentar llamar al API. El código de estado devuelto es: " + statusCode);
        //    }
        //    return null;
        //}
    }
}