using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace plannetWPF
{
    public class DateClass
    {
        private int day;
        private string month;
        private int year;

        private DateTime _date;

        public DateClass(DateTime time)
        {
            GetDate = time;
            
            //sa vad daca mai trebuie sa mai lucrez la asta sau o sa las asa
            SetMonth();
        }

        private void SetMonth()
        {
            month = GetDate.ToString( "MMMM" , new CultureInfo("ro-RO"));
            Console.WriteLine(month);

        }


        public DateTime GetDate
        {
            get
            {
                return _date;
            }
            set
            {
                //nu stiu daca sa mai adaug niste formatarii speciale
                _date = value;
            }

        }

        public string GetMonth
        {
            get
            {
                return month;
            }

        }

    }
}
