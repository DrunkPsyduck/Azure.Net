using ServiceDoctoresSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDoctoresSQL
{
    [ServiceContract]
    public interface IServiceDoctor
    {
        [OperationContract]
        List<Doctor> GetDoctores();

        [OperationContract]
        Doctor BuscarDoctor(int id);
    }
}
