using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using mvcStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcStorage.Services
{
    public class ServiceStorageTables
    {
        private CloudTable table;
        public ServiceStorageTables(String keys) {
            CloudStorageAccount account = CloudStorageAccount.Parse(keys);
            CloudTableClient client = account.CreateCloudTableClient();
            this.table = client.GetTableReference("cliente");
            this.table.CreateIfNotExistsAsync();
        }

        public async Task CreateClientAsync(String idcliente, String Nombre, String edad, String empresa)
        {
            Cliente cliente = new Cliente(idcliente, empresa);
            cliente.Nombre = Nombre;
            cliente.Edad = edad;
            TableOperation insert = TableOperation.Insert(cliente);
            await this.table.ExecuteAsync(insert);
        }
        public async Task<List<Cliente>> GetClienteAsync()
        {
            TableQuery<Cliente> query = new TableQuery<Cliente>();
            TableQuerySegment<Cliente> segment = await this.table.ExecuteQuerySegmentedAsync(query, null);
            return segment.Results;
        }

        public async Task<List<String>> GetEmpresasAsync()
        {
            TableQuery<Cliente> query = new TableQuery<Cliente>();
            TableQuerySegment<Cliente> segment = await this.table.ExecuteQuerySegmentedAsync(query, null);
            return segment.Select(z => z.Empresa).Distinct().ToList();
        }

        public async Task<List<Cliente>> GetClientesEmpresaAsync(String empresa) {
            TableQuery<Cliente> query = new TableQuery<Cliente>();
            TableQuerySegment<Cliente> segment = await this.table.ExecuteQuerySegmentedAsync(query, null);
            return segment.Where(z => z.Empresa == empresa).ToList();
        }
    }
}
