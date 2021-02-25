using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDoctoresSQL.Models
{
    [DataContract]
    [Table("DOCTOR")]
    public class Doctor
    {
        [Key]
        [Column("DOCTOR_NO")]
        [DataMember]
        public int IdDoctor { get; set; }

        [Column("APELLIDO")]
        [DataMember]
        public String Apellido { get; set; }

        [Column("ESPECIALIDAD")]
        [DataMember]
        public String Especialidad { get; set; }

        [Column("SALARIO")]
        [DataMember]
        public int Salario { get; set; }

        [Column("HOSPITAL_COD")]
        [DataMember]
        public int IdHospital{ get; set; }

    }
}
