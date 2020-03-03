using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BulkLoadAssociated.Bean;
using BulkLoadAssociated.Modelos;


namespace BulkLoadAssociated
{
    internal static class AssociateManagement
    {
        static public HttpClient client = new HttpClient();
        static public Properties.Settings appConfig = new Properties.Settings();

        public static async Task<ResponseCommon> RegisterAssociated(AssociatedModel associated)
        {
            ResponseCommon responseCommon = new ResponseCommon();
            try 
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(appConfig.RegisterAssociatedURL, associated);
                response.EnsureSuccessStatusCode();
                // Regresar respuesta
                responseCommon = await response.Content.ReadAsAsync<ResponseCommon>();
                return responseCommon;
            }
            catch (Exception ex)
            {
                responseCommon.explain = ex.Message;
                Log.WriteLog(ex.Message);
                responseCommon.status = -1;
                return responseCommon;
            }
        }
    }
}
