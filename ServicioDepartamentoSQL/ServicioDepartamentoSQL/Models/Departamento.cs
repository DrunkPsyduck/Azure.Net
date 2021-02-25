using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServicioDepartamentoSQL.Models
{
    [DataContract]
    [Table("DEPT")]
    public class Departamento
    {
        [Key]
        [Column("DEPT_NO")]
        [DataMember]
        public int IdDepartamento { get; set; }

        [Column("DNOMBRE")]
        [DataMember]
        public String Nombre { get; set; }

        //El orden de las anotaaciones no importa
        [DataMember]
        [Column("LOC")]
        public String Localidad { get; set; }

        //No hace falta el NuGet de SQLServer porque solo es necesario en EntityFrameworkCore
    }
}
