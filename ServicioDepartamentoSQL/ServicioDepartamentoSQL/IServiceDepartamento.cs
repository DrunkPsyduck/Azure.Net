﻿using ServicioDepartamentoSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDepartamentoSQL
{
    [ServiceContract]
    public interface IServiceDepartamento
    {
        [OperationContract]
        List<Departamento> GetDepartamentos();

        [OperationContract]
        Departamento BuscarDepartamento(int id);
    }
}
