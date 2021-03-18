using System;
using System.Collections.Generic;
using ControlCochesCosmosSQL.Models;
using ControlCochesCosmosSQL.Repositories;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ControlCochesCosmosSQL
{
    public class Function1
    {
        RepositoryCoches repo;

        public Function1(RepositoryCoches repos)
        {
            this.repo = repos;
        }

        [FunctionName("functioncosmos")]
        public void Run([CosmosDBTrigger(
            databaseName: "coches",
            collectionName: "cohes",
            ConnectionStringSetting = "cosmosdb",
            CreateLeaseCollectionIfNotExists = true,
            LeaseCollectionName = "leases")]IReadOnlyList<Document> input, ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                var data = JsonConvert.SerializeObject(input);
                log.LogInformation("Coche cosmos: " + data);
                List<Coche> coches = JsonConvert.DeserializeObject<List<Coche>>(data);
                Coche car = coches[0];

                if(this.repo.BuscarCoche(car.Id) == null)
                {
                    this.repo.InsertarCoche(car.Id, car.Marca, car.Modelo, car.Velocidad);
                } else
                {
                    this.repo.Modificar(car.Id, car.Marca, car.Modelo, car.Velocidad);
                }

                log.LogInformation("Documents modified " + input.Count);
                log.LogInformation("Coches sql " + coches[0].Marca + ", " + coches[0].Modelo);
            }
        }
    }
}
