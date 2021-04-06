using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarRentalServices
{
    [ServiceContract]
    public interface IRentalService
    {

        [OperationContract]
        List<Car> GetCars();

        [OperationContract]
        int AddCar(Car car);

        [OperationContract]
        int UpdateCar(Car currentCar);

        [OperationContract]
        int DeleteCar(int carId);

        [OperationContract]
        List<Client> GetClients();

        [OperationContract]
        int UpdateClient(Client currentClient);

        

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "CarRentalServices.ContractType".
   
}
