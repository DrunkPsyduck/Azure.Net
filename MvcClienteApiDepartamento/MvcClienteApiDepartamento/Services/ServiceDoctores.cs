using Newtonsoft.Json;
using NugetDoctorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MvcClienteApiDepartamento.Services
{
    public class ServiceDoctores
    {
        private Uri uriapi;
        private MediaTypeWithQualityHeaderValue Header;

        public ServiceDoctores(String url)
        {
            this.uriapi = new Uri(url);
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApi<T>(String Request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response = await client.GetAsync(Request);

                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Doctor>> GetDoctoresAsync()
        {
            String request = "api/doctores";
            return await this.CallApi<List<Doctor>>(request);
        }

        public async Task<Doctor> GetDoctorAsync(int id)
        {
            String request = "api/doctores/" + id;
            return await this.CallApi<Doctor>(request);
        }

        public async Task InsertarDoctorAsync(int id, String apellido, String especialidad, int hospital, int salario)
        {
            using (HttpClient client = new HttpClient())
            {
                String Request = "api/doctores";
                client.BaseAddress = this.uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                String json = this.GetDoctorJson(id, apellido, especialidad, hospital, salario);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PostAsync(Request, content);
            }
        }

        public async Task UpdateDoctorAsync(int id, String apellido, String especialidad, int hospital, int salario)
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/doctores";
                client.BaseAddress = this.uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);

                String json = this.GetDoctorJson(id, apellido, especialidad, hospital, salario);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PutAsync(request, content);
            }
        }

        public async Task DeleteDoctorAsync(int id)
        {
            using(HttpClient client = new HttpClient())
            {
                String request = "api/doctores/" + id;
                client.BaseAddress = this.uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                await client.DeleteAsync(request);
            }
        }

        public async Task IncrementarSalariosAsync(int incremento, int hospital)
        {
            using(HttpClient client = new HttpClient())
            {
                String request = "api/doctores/IncrementarSalario/" + incremento + "/" + hospital;
                client.BaseAddress = this.uriapi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);

                await client.PutAsync(request, new StringContent(""));
            }
        }

        private String GetDoctorJson(int id, String apellido, String especialidad, int hospital, int salario)
        {
            Doctor doc = new Doctor();
            doc.IdDoctor = id;
            doc.Apellido = apellido;
            doc.Especialidad = especialidad;
            doc.Hospital = hospital;
            doc.Especialidad = especialidad;

            return JsonConvert.SerializeObject(doc);
        }

        public async Task<List<String>> GetEspecialidadesAsync()
        {
            String request = "api/Doctores/Especialidades";
            List<String> especialidades = await this.CallApi<List<String>>(request);
            return especialidades;
        }

        public async Task<List<Doctor>> GetDoctoresEspecialidadAsync(List<String> especialidades)
        {
            String request = "api/Doctores/DoctoresEspecialidad?";
            String data = "";
            foreach(String espe in especialidades)
            {
                data += "especialidad=" + espe + "&";
            }

            data = data.Trim('&');

            return await this.CallApi<List<Doctor>>(request + data);
            
        }
    }
}
