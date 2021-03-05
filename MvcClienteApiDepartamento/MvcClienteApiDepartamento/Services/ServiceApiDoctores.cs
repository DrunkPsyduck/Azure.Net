using MvcCoreDoctores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MvcCoreDoctores.Services
{
    public class ServiceApiDoctores
    {
        //objetos necesarios
        private String url;
        //indicar consumo json
        MediaTypeWithQualityHeaderValue header;

        public ServiceApiDoctores()
        {
            this.url = "https://apidoctoresmc.azurewebsites.net/";
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public ServiceApiDoctores(String url)
        {
            this.url = url;
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Doctor>> GetDoctoresAsync()
        {
            //necesario un objeto HttpClient
            using (HttpClient client = new HttpClient())
            {
                String request = "api/doctor";
                client.BaseAddress = new Uri(this.url);
                //Limpiar cabecveras para cada peticion
                client.DefaultRequestHeaders.Clear();
                //añadir formato de peticion
                client.DefaultRequestHeaders.Accept.Add(this.header);
                //realizar peticion utilizando el metodo get
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    List<Doctor> doctores = await response.Content.ReadAsAsync<List<Doctor>>();
                    return doctores;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<String>> GetEspecialidadesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                String request = "api/doctor/especialidades";
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    List<String> especialidades = await response.Content.ReadAsAsync<List<String>>();
                    return especialidades;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Doctor> BuscarDoctor(int id)
        {

            using (HttpClient client = new HttpClient())
            {
                String request = "/api/Doctor/" + id.ToString();
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    Doctor doctor = await response.Content.ReadAsAsync<Doctor>();
                    return doctor;
                }
                else {
                    return null; 
                }

            }
        }

       
    }
}
