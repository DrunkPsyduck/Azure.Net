using CoreCochesCosmosDB.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCochesCosmosDB.Services
{
    public class ServiceCosmosDB
    {
        DocumentClient client;
        String bbdd;
        String collection;

        public ServiceCosmosDB(IConfiguration configuration)
        {
            String endpoint = configuration["CosmosDb:endpoint"];
            String primarykey = configuration["CosmosDb:primarykey"];
            this.bbdd = "Vehiculos BBDD";
            this.collection = "VehiculosCollection";
            this.client =
                new DocumentClient(new Uri(endpoint), primarykey);
        }


        public async Task CrearBbddVEhiculosAsync()
        {
            Database bbdd = new Database() { Id = this.bbdd };
            await this.client.CreateDatabaseAsync(bbdd);
        }

        public async Task CrearColeccionVehiculosAsync()
        {
            DocumentCollection coleccion = new DocumentCollection() { Id = this.collection };
            await this.client.CreateDocumentCollectionAsync(UriFactory.CreateDatabaseUri(this.bbdd), coleccion);
        }

        public async Task InsertarVehiculo(Vehiculo car)
        {
            Uri uri = UriFactory.CreateDocumentCollectionUri(this.bbdd, this.collection);
            await this.client.CreateDocumentAsync(uri, car);
        }

        public List<Vehiculo> GetVehiculos()
        {
            FeedOptions options = new FeedOptions() { MaxItemCount = -1 };
            String sql = "SELECT * FROM c";
            Uri uri = UriFactory.CreateDocumentCollectionUri(this.bbdd, this.collection);
            IQueryable<Vehiculo> consulta = this.client.CreateDocumentQuery<Vehiculo>(uri, sql, options);
            return consulta.ToList();
        }

        public async Task<Vehiculo> FindVehiculoAsync(String id)
        {
            Uri uri = UriFactory.CreateDocumentUri(this.bbdd, this.collection, id);
            Document document = await this.client.ReadDocumentAsync(uri);
            MemoryStream memory = new MemoryStream();
            using (var stream = new StreamReader(memory))
            {
                document.SaveTo(memory);

                memory.Position = 0;

                //deserialize
                Vehiculo car = JsonConvert.DeserializeObject<Vehiculo>(stream.ReadToEnd());
                return car;
            }
        }

        public async Task ModificarVehiculo(Vehiculo car)
        {
            Uri uri = UriFactory.CreateDocumentUri(this.bbdd, this.collection, car.Id);

            await this.client.ReplaceDocumentAsync(uri, car);
        }

        public async Task EliminarVehiculo(String id)
        {
            Uri uri = UriFactory.CreateDocumentUri(this.bbdd, this.collection, id);

            await this.client.DeleteDocumentAsync(uri);
        }

        public List<Vehiculo> BuscarVehiculosMarca(String marca)
        {
            FeedOptions options = new FeedOptions() { MaxItemCount = -1 };

            Uri uri = UriFactory.CreateDocumentCollectionUri(this.bbdd, this.collection);
            String sql = "select * from c where c.Marca = '" + marca + "'";

            IQueryable<Vehiculo> query = this.client.CreateDocumentQuery<Vehiculo>(uri, sql, options);

            IQueryable<Vehiculo> queryLambda = this.client.CreateDocumentQuery<Vehiculo>(uri, sql, options).Where(z => z.Marca == marca);

            return query.ToList();
        }

        public List<Vehiculo> CrearCoches()
        {
            List<Vehiculo> coches = new List<Vehiculo>()
            {
                new Vehiculo
                {
                    Id = "1", Marca="Toyota", Modelo=" Spinter Trueno GT APEX", Motor = new Motor {Tipo = "4AGE", Caballos=150, Potencia=150}, VelocidadMaxima=160
                },

                 new Vehiculo
                {
                    Id = "2", Marca="Aston Martin", Modelo="DB11", Motor = new Motor {Tipo = "AMG", Caballos=650, Potencia=650}, VelocidadMaxima=320
                },
                  new Vehiculo
                {
                    Id = "3", Marca="Xiaomi", Modelo="Patinete Electrico", VelocidadMaxima=160
                }

            };
            return coches;
        }

    }
}
