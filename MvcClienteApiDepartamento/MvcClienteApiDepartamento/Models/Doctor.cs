using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreDoctores.Models
{
    public class Doctor
    {
        [JsonProperty("idDoctor")]
        public int IdDoctor { get; set; }

        public String Apellido { get; set; }
        public String Especialidad { get; set; }
        public int Salario { get; set; }
        public int IdHospital { get; set; }

    }
}
