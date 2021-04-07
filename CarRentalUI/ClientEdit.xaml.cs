using CarRentalUI.CarRentalServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarRentalUI
{
    /// <summary>
    /// Interaction logic for ClientEdit.xaml
    /// </summary>
    public partial class ClientEdit : Window
    {
        private RentalServiceClient service = new RentalServiceClient();


        public ClientEdit()
        {
            InitializeComponent();
            dgClient.ItemsSource = service.GetClients().ToList();
        }


        private void dgClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        //    if (this.dgClient.SelectedIndex >= 0)
        //    {
        //        if (this.dgClient.SelectedItems.Count >= 0)
        //        {
        //            if (this.dgClient.SelectedItems[0].GetType() == typeof(Client))
        //            {
        //                Client c = (Client)this.dgClient.SelectedItems[0];
        //                this.tbName.Text = c.FullName;
        //                this.tbCity.Text = c.City;
        //                this.dpBirthDate.SelectedDate = c.Birthdate;
        //                //this.txtSpecialization2.Text = d.Specialization;
        //                //this.txtQualification2.Text = d.Qualification;
        //                //this.txtAge.Text = d.Age.ToString();

        //                //this.updatingDoctorID = d.Id;
        //            }
        //        }
        //    }
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
          //  dgClient.ItemsSource = serv.SearchClients(tbZipCode.Text).ToList();
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            //dgClient.ItemsSource = serv.GetCustomers().ToList();
            //dgClient.SelectedIndex = -1;
            //tbClientFilter.Text = "";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (dgClient.SelectedIndex >= 0)
            {
                int index = dgClient.SelectedIndex;
                var list = service.GetClients();
                var cl = new Client
                {
                    Id = list[index].Id,
                    IdCardNumber = list[index].IdCardNumber,
                    FirstName = tbName.Text,        //SurName még kell
                    Birthdate = dpBirthDate.DisplayDate,
                    ZipCode = list[index].ZipCode,
                    City = list[index].City,
                    AdressLine1 = list[index].AdressLine1,  //AdressLine2 még kell
                    PhoneNumber = list[index].PhoneNumber,
                    LicenseNumber = list[index].LicenseNumber,
                    LicenseIssueDate = list[index].LicenseIssueDate,
                    UserName = list[index].UserName,
                    PasswordHash = list[index].PasswordHash,
                    Salt = list[index].Salt,
                    EmailAdress = list[index].EmailAdress,
                };
                service.UpdateClient(cl);
                dgClient.ItemsSource = service.GetClients().ToList();

            }
        }
                     
    }
}
