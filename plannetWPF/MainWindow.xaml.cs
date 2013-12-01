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
using System.Globalization;

namespace plannetWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NotifyIcon notifyIcon;
        bool moveable = false;
        System.Drawing.Point currPosition;

        public MainWindow()
        {
            InitializeComponent();
            DateClass date = new DateClass(DateTime.Now);
            
            //nu stiu sigur ce inseamna asta
            day.Content = date.GetDate.Day > 9 ? date.GetDate.Day.ToString() : "0" + date.GetDate.Day ;
            month.Content = UpperCaseFirstLetter( date.GetMonth);
            year.Content = date.GetDate.Year;

           
            
            
        }

        private void closeLBL_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            moveable = true;
            Console.WriteLine(e.GetPosition(this));
            currPosition = new System.Drawing.Point((int)e.GetPosition(this).X, (int)e.GetPosition(this).Y);
            
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            moveable = false;
        }

        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {


            if (moveable)
            {
                Left = System.Windows.Forms.Control.MousePosition.X - currPosition.X;
                Top = System.Windows.Forms.Control.MousePosition.Y - currPosition.Y;
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            //pentru masurarea textului
            FormattedText dayFText = GetTextSize(day.Content.ToString(), "Candara", 60);
            FormattedText monthFText = GetTextSize(month.Content.ToString(), "Segoe", 12);
            FormattedText yearFText = GetTextSize(year.Content.ToString(), "Candara", 22);
                                                   

            Console.WriteLine(dayFText.Width + " " + monthFText.Width + " " + yearFText.Width + " " + dateCollection.Width);
            day.Margin = new Thickness((dateCollection.Width - dayFText.Width) / 2 - 10,
                                        day.Margin.Top,
                                        (dateCollection.Width - dayFText.Width) / 2,
                                        0);
            month.Margin = new Thickness((dateCollection.Width - monthFText.Width)/2 -10,
                                          month.Margin.Top,
                                          (dateCollection.Width - monthFText.Width) / 2,
                                          month.Margin.Bottom);
            year.Margin = new Thickness((dateCollection.Width - yearFText.Width) / 2 - 10,
                                          year.Margin.Top,
                                          (dateCollection.Width - yearFText.Width) / 2,
                                          year.Margin.Bottom);




        }

        private FormattedText GetTextSize(string textToReturnFormat, string fontName, int fontSize)
        {
            FormattedText returnedFText = new FormattedText(textToReturnFormat,
                                                            new CultureInfo("ro-RO"),
                                                            System.Windows.FlowDirection.LeftToRight,
                                                            new Typeface(fontName),
                                                            fontSize,
                                                            System.Windows.Media.Brushes.Black);
            return returnedFText;
        }

        private string UpperCaseFirstLetter(string input)
        {
            return input[0].ToString().ToUpper() + input.Substring(1);
           
        }
        
        

    }
}
