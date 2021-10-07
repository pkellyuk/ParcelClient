using System.Collections.Generic;


namespace ParcelClient.Models
{
    public class CollectionAddress
    {
        public string Country { get; set; }
    }

    public class DeliveryAddress
    {
        public string Country { get; set; }
    }

    public class Parcel
    {
        public double Weight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class ParcelRequestModel
    {
        public CollectionAddress CollectionAddress { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public List<Parcel> Parcels { get; set; }
    }


}
