using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Web.Models;

namespace Web.Service
{
    public class UsuarioService
    {

        private string _path;
        private HttpClient _client;
        private string _especificPath;

        public UsuarioService()
        {
            _path = ConfigurationManager.AppSettings["apiPrincipalPath"];
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_path);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public IEnumerable<UsuarioViewModel> GetUsuarios(string especificPath)
        { 
            IEnumerable<UsuarioViewModel> usuarios = null;
            HttpResponseMessage response = _client.GetAsync(especificPath).Result;
            if (response.IsSuccessStatusCode)
            {
                usuarios = response.Content.ReadAsAsync<IEnumerable<UsuarioViewModel>>().Result;
            }
            return usuarios;
        }

        public UsuarioViewModel GetUsuario(int id, string especificPath)
        {
            UsuarioViewModel usuario = null;
            HttpResponseMessage response = _client.GetAsync(string.Format("{0}/{1}",especificPath, id)).Result;
            if (response.IsSuccessStatusCode)
            {
                usuario = response.Content.ReadAsAsync<UsuarioViewModel>().Result;
            }
            return usuario;

        }

        public async Task<bool> SaveUsuario(UsuarioViewModel model, string especificPath)
        {
            
            HttpResponseMessage response = await _client.PostAsJsonAsync(especificPath, model);
            response.EnsureSuccessStatusCode();
            return true;         
           

        }

        public async Task<bool> UpdateUsuario(UsuarioViewModel model, string especificPath)
        {
            
            HttpResponseMessage response = await _client.PutAsJsonAsync(especificPath, model);
            response.EnsureSuccessStatusCode();
            return true;


        }

        public async Task<bool> DeleteUsuario(int id, string especificPath)
        {

            HttpResponseMessage response = await _client.DeleteAsync(string.Format("{0}/{1}", especificPath, id));
            response.EnsureSuccessStatusCode();
            return true;


        }


    }
}