using CarRentalServices.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarRentalServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class RentalService : IRentalService
    {
        public List<Car> GetCars()
        {
            List<Car> carList = new List<Car>();
            using (var ctx = new CarRentalModel())
            {

                var lstCar = from k in ctx.Car select k;
                foreach (var item in lstCar)
                {

                    try
                    {
                        Car car = new Car();
                        car.Id          = item.Id;         
                        car.LicensePlate   = item.LicensePlate;
                        car.CategoryId     = item.CategoryId;
                        car.LocationId     = item.LocationId;
                        car.Brand          = item.Brand;
                        car.Model          = item.Model;
                        car.ProductionYear = item.ProductionYear;
                        car.KmClock        = item.KmClock;
                        car.Fuel           = item.Fuel;
                        car.Color          = item.Color;
                        car.Seats          = item.Seats;
                        car.Gearbox        = item.Gearbox;
                        car.Horsepower     = item.Horsepower;
                        car.Image          = item.Image;
                        car.Remark         = item.Remark;
                        carList.Add(car);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return carList;
            }
        }

        public int AddCar(Car car)
        {
           
           using (var ctx = new CarRentalModel())
           {
               ctx.Car.Add(car);
               return ctx.SaveChanges();
           }
          
        }

        public int UpdateCar(Car currentCar)
        {
            using (var ctx = new CarRentalModel())
            {
                ctx.Entry(currentCar).State = EntityState.Modified;

                int Retval = ctx.SaveChanges();
                return Retval;
            }

        }

        public int DeleteCar(int carId)
        {
            int Retval = -1;
            using (var ctx = new CarRentalModel())
            {
                var curCar = (from c in ctx.Car
                            where c.Id == carId
                            select c).FirstOrDefault();
                if (curCar != null)
                {
                    ctx.Car.Remove(curCar);
                    ctx.SaveChanges();
                    Retval = 0;
                }

                return Retval;
            }
        }


        public List<Client> GetClients()
        {
                List<Client> clientList = new List<Client>();
                using (var ctx = new CarRentalModel())
                {

                    var lstClient = from k in ctx.Client select k;
                    foreach (var item in lstClient)
                    {

                        try
                        {
                            Client cl = new Client();
                            cl.Id = item.Id;
                            cl.IdCardNumber = item.IdCardNumber;
                            cl.FirstName = item.FirstName;
                            cl.SurName = item.SurName;
                            cl.Birthdate = item.Birthdate;
                            cl.ZipCode = item.ZipCode;
                            cl.City = item.City;
                            cl.AdressLine1 = item.AdressLine1;
                            cl.AdressLine2 = item.AdressLine2;
                            cl.PhoneNumber = item.PhoneNumber;
                            cl.LicenseNumber = item.LicenseNumber;
                            cl.LicenseIssueDate = item.LicenseIssueDate;
                            cl.UserName = item.UserName;
                            cl.PasswordHash = item.PasswordHash;
                            cl.Salt = item.Salt;
                            cl.EmailAdress = item.EmailAdress;   
                            clientList.Add(cl);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    return clientList;
                }
            
        }

        public int UpdateClient(Client currentClient)
        {         
                using (var ctx = new CarRentalModel())
                {
                    ctx.Entry(currentClient).State = EntityState.Modified;

                    int Retval = ctx.SaveChanges();
                    return Retval;
                }
            
        }
       
    }
}
