using MvcClienteApiDepartamento.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MvcClienteApiDepartamento.Services
{
    public class ServiceDepartamentos
    {
        Uri uriapi;
        MediaTypeWithQualityHeaderValue Header;

        private async Task<T> CallApi<T>(String request) 
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                } else
                {
                    return default(T);
                }
            }
        }
        public ServiceDepartamentos(String url)
        {
            this.uriapi = new Uri(url);
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/departamento";
                client.BaseAddress = this.uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);

                HttpResponseMessage response = await client.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    List<Departamento> data = await response.Content.ReadAsAsync<List<Departamento>>();
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Departamento> BuscarDepartamentoAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/departamento/" + id;
                client.BaseAddress = this.uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    Departamento departamento = await response.Content.ReadAsAsync<Departamento>();
                    return departamento;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task EliminarDepartamentoAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/departamento/" + id;
                client.BaseAddress = this.uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response = await client.GetAsync(request);

                await client.DeleteAsync(request);
            }
        }

        public async Task InsertarDepartamentoAsync(int id, String nombre, String localidad)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/departamento/" + id;
                client.BaseAddress = this.uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);

                Departamento dept = new Departamento();
                dept.IdDepartamento = id;
                dept.Nombre = nombre;
                dept.Localidad = localidad;

                String json = JsonConvert.SerializeObject(dept);

                //enviar información al servidor se utiliza OBJETOS CONTENT
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                //Aunque parezca redundate debe ir especificado, si no daría error

                await client.PostAsync(request, content);                
            }
        }

        public async Task ModificarDepartamentoAsync(int id, String nombre, String localidad)
        {
            using(HttpClient client = new HttpClient())
            {
                String request = "api/departamento";
                client.BaseAddress = this.uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);

                Departamento dept = new Departamento();
                dept.IdDepartamento = id;
                dept.Nombre = nombre;
                dept.Localidad = localidad;

                String json = JsonConvert.SerializeObject(dept);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                await client.PutAsync(request, content);
            }
        }

    }

}

