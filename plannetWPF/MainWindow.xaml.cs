using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace plannetWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NotifyIcon notifyIcon;
        

        public MainWindow()
        {
            InitializeComponent();
            DateClass date = new DateClass(DateTime.Now);
            
            //nu stiu sigur ce inseamna asta
            day.Content = date.GetDate.Day;
            month.Content = date.GetMonth;
            year.Content = date.GetDate.Year;

            month.Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));

            Console.WriteLine(month.Width + " " + DateCollection.Width);
            
            
        }

        private void closeLBL_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
