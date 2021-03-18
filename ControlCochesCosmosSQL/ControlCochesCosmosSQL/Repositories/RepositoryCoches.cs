using ControlCochesCosmosSQL.Data;
using ControlCochesCosmosSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlCochesCosmosSQL.Repositories
{
    public class RepositoryCoches
    {
        CochesContext context;

        public RepositoryCoches(CochesContext context)
        {
            this.context = context;

        }

        public Coche BuscarCoche(String id)
        {
            return this.context.coches.SingleOrDefault(x => x.Id == id);
        }

        public void InsertarCoche(String id, String marca, String modelo, int velocidad)
        {
            Coche car = new Coche();
            car.Id = id;
            car.Marca = marca;
            car.Modelo = modelo;
            car.Velocidad = velocidad;
            car.Estado = "Car goes Vroom";
            car.Fecha = DateTime.Now;
            this.context.coches.Add(car);
            this.context.SaveChanges();
        }

        public void Modificar(String id, String marca, String modelo, int velocidad)
        {
            Coche car = this.BuscarCoche(id);
            car.Id = id;
            car.Marca = marca;
            car.Modelo = modelo;
            car.Velocidad = velocidad;
            car.Estado = "Como nuevo";
            car.Fecha = DateTime.Now;
            this.context.coches.Add(car);
            this.context.SaveChanges();
        }

        public void EliminarCoche(String id)
        {
            Coche car = this.BuscarCoche(id);
            car.Estado = "Chatarra";
            this.context.SaveChanges();
        }
    }
}