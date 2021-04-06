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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRentalUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClientEdit clientWindow;
        private CarEdit carWindow;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnCarEdit_Click(object sender, RoutedEventArgs e)
        {
            if (carWindow == null)
                carWindow = new CarEdit();
            carWindow.Show();
            carWindow.Focus();

        }

        private void btnClientEdit_Click(object sender, RoutedEventArgs e)
        {
            if (clientWindow == null)
                clientWindow = new ClientEdit();           
            clientWindow.Show();
            clientWindow.Focus();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (clientWindow != null)
                clientWindow.Close();
            if (carWindow != null)
                carWindow.Close();
        }
    }
}
