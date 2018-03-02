using System.Collections.Generic;
using System.Linq;

namespace Intive.BikeRental.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public List<Rent> RentalsList { get; set; }

        public double CheckPrice()
        {
            var totalPrice = RentalsList.Sum(x => x.GetPrice());

            // 4. Family Rental, is a promotion that can include from 3 to 5 Rentals (of any type) 
            // with a discount of 30% of the total price
            if (RentalsList.Count > 2 && RentalsList.Count < 6)
            {
                totalPrice -= totalPrice * 0.3;
            }

            return totalPrice;
        }
    }
}