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
        string imgLocation = "";


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
                c.CategoryId = 1;   //Még nem jó       
                c.LocationId = 1;    //Még nem jó      
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
                if (imgLocation != "")   
                {
                    string path = "C:/CarRentalImages/" + c.Brand + c.Model + c.ProductionYear + System.IO.Path.GetExtension(imgLocation);
                    System.IO.File.Copy(imgLocation, path, true);
                    c.Image = path;
                }
                if (service.AddCar(c) == 1)
                {
                    
                    dgCar.ItemsSource = service.GetCars();
                    System.Windows.MessageBox.Show("Autó hozzáadva", "Sikeres felvétel", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
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
                    ImageViewer.Source = null;
                    service.DeleteCar(list[index].Id);
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
                    Id = list[index].Id,
                    LicensePlate = tbLicensePlate.Text,
                    CategoryId = list[index].CategoryId,   //Még nem jó        
                    LocationId = list[index].LocationId,    //Még nem jó                          
                    Brand = tbBrand.Text,
                    Model = tbModel.Text,
                    ProductionYear = Convert.ToInt32(tbYear.Text),
                    KmClock = Convert.ToInt32(tbKmClock.Text),
                    Fuel = cobFuel.Text,
                    Color = tbColor.Text,
                    Seats = Convert.ToInt32(tbSeats.Text),
                    Gearbox = tbGearbox.Text,
                    Horsepower = Convert.ToInt32(tbHorsepower.Text),
                };
                  if (imgLocation != "")
                  {
                    string path = "C:/CarRentalImages/" + c.Brand + c.Model + c.ProductionYear + System.IO.Path.GetExtension(imgLocation);
                    System.IO.File.Copy(imgLocation, path, true);
                    c.Image = path;
                  }
                  else
                  {
                    c.Image = "nincs";   //Még nem jó 
                  }                                                  
                service.UpdateCar(c);
                dgCar.ItemsSource = service.GetCars().ToList();
            }
        }

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
            //Car c = new Car();

            //c.Brand = tbBrand.Text;
            //c.Model = tbModel.Text;

            //MessageBoxResult result = System.Windows.MessageBox.Show("Biztos, hogy törli a(z) " + c.Brand + " " + c.Model + " autó képét?",
            //                                 "Megerősítés",
            //                               MessageBoxButton.YesNo,
            //                               MessageBoxImage.Question);
            //if (result == MessageBoxResult.Yes)
            //{
            //    ImageViewer.Source = null;
            //    imgLocation = "";
            //    File.Delete(c.Image);
            //    //tbImagePath.Text = "";
            //    c.Image = "nincs";     //Még nem jó
            //    service.UpdateCar(c);
            //    dgCar.ItemsSource = service.GetCars();
            //}
        }

        private void dgCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnSave.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnAdd.IsEnabled = false;
            imgLocation = "";
            //if (tbImagePath.Text == "")
            //{
            //    btnDeleteImage.IsEnabled = false;
            //}
            //else btnDeleteImage.IsEnabled = true;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
