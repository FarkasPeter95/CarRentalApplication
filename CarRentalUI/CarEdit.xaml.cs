using CarRentalUI.CarRentalServiceReference;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for CarEdit.xaml
    /// </summary>
    public partial class CarEdit : Window
    {
        public List<Car> carViewSource = new List<Car>();      


        private RentalServiceClient service = new RentalServiceClient();


        public CarEdit()
        {
            InitializeComponent();
            dgCar.ItemsSource = service.GetCars().ToList();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            RentalServiceClient service = new RentalServiceClient();

            tbLicensePlate.Text = "";
            cobCategory.Text = "";
            tbBrand.Text = "";
            tbModel.Text = "";
            tbYear.Text = "";
            tbKmClock.Text = "";
            cobFuel.Text = "";
            tbColor.Text = "";
            tbSeats.Text = "";
            tbGearbox.Text = "";
            tbHorsepower.Text = "";
            tbCarFilter.Text = "";
            tbImagePath.Text = "";
            dgCar.SelectedIndex = -1;
        //    tbCarID.Text = Convert.ToString(service.NextCarId());
            ImageViewer.Source = null;
            btnSave.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnAdd.IsEnabled = true;
            btnDeleteImage.IsEnabled = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Car c = new Car();
            try
            {
                c.LicensePlate = tbLicensePlate.Text;
                c.CategoryID = 1;   //Még nem jó       
                c.LocationID = 1;    //Még nem jó      
                c.Brand = tbBrand.Text;
                c.Model = tbModel.Text;
                c.ProductionYear = Convert.ToInt32(tbYear.Text);
                c.KmClock = Convert.ToInt32(tbKmClock.Text);
                c.Fuel = cobFuel.Text;
                c.Color = tbColor.Text;
                c.Seats = Convert.ToInt32(tbSeats.Text);
                c.Gearbox = tbGearbox.Text;
                c.Horsepower = Convert.ToInt32(tbHorsepower.Text);
                c.Image = "nincs";        //Még nem jó                 

                if (service.AddCar(c) == 1)
                {
                    if (imgLocation != "")
                    {
                        string path = "C:/CarRentalImages/" + tbCarID.Text + System.IO.Path.GetExtension(imgLocation);
                        System.IO.File.Copy(imgLocation, path, true);
                        c.Id = Convert.ToInt32(tbCarID.Text);
                        c.Image = path;
                        service.UpdateCarImage(c);

                    }
                    dgCar.ItemsSource = service.GetAllCars();
                    System.Windows.MessageBox.Show("Autó hozzáadva", "Sikeres felvétel", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else if (service.AddCar(c) == 0)
                {
                    System.Windows.MessageBox.Show("Hozzáadás nem lehetséges, nem megfelelő adatok!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex + "Hozzáadás nem lehetséges, nem megfelelő adatok!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
           
            if (dgCar.SelectedIndex >= 0)
            {
                int index = dgCar.SelectedIndex;
                var list = service.GetCars();            


                MessageBoxResult result = System.Windows.MessageBox.Show("Biztos, hogy törli a(z) " + list[index].Brand + " " + list[index].Model + " adatait az adatbázisból?",
                                                "Megerősítés",
                                              MessageBoxButton.YesNo,
                                              MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    service.DeleteCar(list[index].CarID);
                    if (list[index].Image != "")
                    {
                        File.Delete(list[index].Image);
                    }
                    dgCar.ItemsSource = service.GetCars();
                        System.Windows.MessageBox.Show("Autó törölve", "Sikeres törlés", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }                
                //else
                //{
                //    System.Windows.MessageBox.Show("Törlés nem lehetséges, nincs kijelölve autó!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                //}
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (dgCar.SelectedIndex >= 0)
            {
                int index = dgCar.SelectedIndex;
                var list = service.GetCars();
                var c = new Car
                {
                  CarID          =  list[index].CarID,                   
                  LicensePlate   =  tbLicensePlate.Text,                 
                  CategoryID     =  list[index].CategoryID,   //Még nem jó        
                  LocationID     =  list[index].LocationID,    //Még nem jó                          
                  Brand          =  tbBrand.Text,                                    
                  Model          =  tbModel.Text,                                       
                  ProductionYear =  Convert.ToInt32(tbYear.Text),                                    
                  KmClock        =  Convert.ToInt32(tbKmClock.Text),                                    
                  Fuel           =  cobFuel.Text,                         
                  Color          =  tbColor.Text,                                    
                  Seats          =  Convert.ToInt32(tbSeats.Text),                       
                  Gearbox        =  tbGearbox.Text,          
                  Horsepower     =  Convert.ToInt32(tbHorsepower.Text),
                  Image          =  "nincs",        //Még nem jó                   
                };
                service.UpdateCar(c);
                dgCar.ItemsSource = service.GetCars().ToList();
            }
        }

        string imgLocation = "";
        private void btnBrowseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (dialog.ShowDialog() == true)
            {
                imgLocation = dialog.FileName.ToString();
               // tbImagePath.Text = imgLocation;
                ImageViewer.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }

        private void btnDeleteImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelete.IsEnabled = true;
            btnSave.IsEnabled = true;
            btnAdd.IsEnabled = false;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
