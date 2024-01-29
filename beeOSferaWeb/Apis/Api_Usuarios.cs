namespace beeOSferaWeb.Apis;

using beeOSferaWeb.Apis.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

public class Api_Usuarios : Controller
{
    public string obtenerToken(string rutaBase, string usuario, string clave)
    {
        Api_Token token = null;
        string respuesta = "";
        var url = rutaBase + $"login";

        try
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            //request.PreAuthenticate = true;
            //request.Headers.Add("Authorization", "Bearer " + token);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Timeout = 5000;
            HttpWebResponse response = null;
            HttpStatusCode statusCode;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"usuario\":\"" + usuario + "\"," +
                              "\"clave\":\"" + clave + "\"}";

                streamWriter.Write(json);
            }

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
                        token = JsonConvert.DeserializeObject<Api_Token>(responseBody);
                        respuesta = token.token;
                        //Regresa un string del token como respuesa (que se toma en el onget)//
                        return respuesta;
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

    public string enviarCorreo(string rutaBase, string correo, string urll, string urldomain)
    {
        TokenModel resp = null;
        string respuesta = null;

        var url = rutaBase + $"recuperar_clave/enviar_correo";

        try
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            //request.PreAuthenticate = true;
            //request.Headers.Add("Authorization", "Bearer " + token);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Timeout = 5000;
            HttpWebResponse response = null;
            HttpStatusCode statusCode;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"correo\":\"" + correo + "\"," +
                                  "\"urldomain\":\"" + urldomain + "\"," +
                                  "\"url\":\"" + urll + "\"}";

                streamWriter.Write(json);
            }

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
                        //Regresa un string del token como respuesa (que se toma en el onget)//
                        StreamReader reader = new StreamReader(dataStream);
                        string responseBody = reader.ReadToEnd();
                        resp = JsonConvert.DeserializeObject<TokenModel>(responseBody);
                        respuesta = resp.respuesta;
                        respuesta.ToString();
                        //Regresa un string del token como respuesa (que se toma en el onget)//
                        return respuesta;
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

    public string Validar_Token(string token, string rutaBase)
    {
        TokenModel resp = null;
        string respuesta = null;

        var url = rutaBase + $"recuperar_clave/Verificar_Token";

        try
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            //request.PreAuthenticate = true;
            //request.Headers.Add("Authorization", "Bearer " + token);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Timeout = 5000;
            HttpWebResponse response = null;
            HttpStatusCode statusCode;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"token\":\"" + token + "\"}";

                streamWriter.Write(json);
            }

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
                        //Regresa un string del token como respuesa (que se toma en el onget)//
                        StreamReader reader = new StreamReader(dataStream);
                        string responseBody = reader.ReadToEnd();
                        resp = JsonConvert.DeserializeObject<TokenModel>(responseBody);
                        respuesta = resp.respuesta;
                        respuesta.ToString();
                        //Regresa un string del token como respuesa (que se toma en el onget)//
                        return respuesta;
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

    public bool enviarClave(string rutaBase, string clave1, string clave2, string token)
    {
        var url = rutaBase + $"recuperar_clave/cambiar_clave";

        try
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            //request.PreAuthenticate = true;
            //request.Headers.Add("Authorization", "Bearer " + token);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Timeout = 5000;
            HttpWebResponse response = null;
            HttpStatusCode statusCode;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"password\":\"" + clave1 + "\"," +
                              "\"password2\":\"" + clave2 + "\"," +
                              "\"token\":\"" + token + "\"}";

                streamWriter.Write(json);
            }

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
                        return true;

                        //Regresa un string del token como respuesa (que se toma en el onget)//
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
        return false;
    }

    public string validate_token(string rutaBase, string token)
    {
        var url = rutaBase + $"token_validate";

        // Crear una instancia de HttpWebRequest.

        var request = (HttpWebRequest)WebRequest.Create(url);
        // Configurar la solicitud.
        request.Method = "POST";
        request.PreAuthenticate = true;
        request.Headers.Add("Authorization", "Bearer " + token);
        request.ContentType = "application/json";
        request.Accept = "application/json";
        request.Timeout = 5000;

        // Agregar los datos que deseas enviar en el cuerpo de la solicitud.
        string json = "{\"token\":\"" + token + "\"}";

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
}