using System;

namespace TrainSystem
{
    public struct Date
    {
        public int Day;
        public int Month;
        public int Year;

        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public Date(DateTime dateTime)
        {
            Day = dateTime.Day;
            Month = dateTime.Month;
            Year = dateTime.Year;
        }
    }
}
