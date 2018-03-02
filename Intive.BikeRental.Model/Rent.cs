using System;

namespace Intive.BikeRental.Model
{
    public enum RentType
    {
        None = 0,
        Hourly,
        Daily,
        Weekly
    }

    public class Rent
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public Bike Bike { get; set; }

        public RentType RentType { private get; set; }

        public double GetPrice()
        {
            TimeSpan timeSpan = To - From;

            switch (RentType)
            {
                case RentType.Hourly:
                    return Math.Floor(5 * (timeSpan.TotalMinutes / 60));
                case RentType.Daily:
                    return Math.Floor(20 * (timeSpan.TotalMinutes / 1440));
                case RentType.Weekly:
                    return Math.Floor(60 * (timeSpan.TotalMinutes / 10080));
                default:
                    throw new ArgumentNullException("RentType not specified");
            }
        }
    }
}