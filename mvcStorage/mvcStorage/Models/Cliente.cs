using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcStorage.Models
{
    public class Cliente : TableEntity
    {
        //Constructor por defecto
        public Cliente(){ }
        public Cliente(String idcliente, String empresa)
        {
            this.IdCliente = idcliente;
            this.Empresa = empresa;
            this.RowKey = idcliente;
            this.PartitionKey = empresa;
        }

        public String IdCliente { get; set; }
        public String Nombre { get; set; }
        public String Edad { get; set; }
        public String Empresa { get; set; }
    }
}
