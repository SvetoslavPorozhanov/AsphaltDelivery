namespace AsphaltDelivery.Data.Models
{
    public class TruckDriver
    {
        public int DriverId { get; set; }

        public virtual Driver Driver { get; set; }

        public int TruckId { get; set; }

        public virtual Truck Truck { get; set; }
    }
}
