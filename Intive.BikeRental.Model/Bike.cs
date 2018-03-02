using System;

namespace Intive.BikeRental.Model
{
    public class Bike 
    {
        public int BikeId { get; set; }

        public string Brand { get; set; }

        public DateTime Model { get; set; }

        private bool _isRented = false;

        //public bool IsRented
        //{
        //    get => _isRented;
        //    set => _isRented = value;
        //}
    }
}