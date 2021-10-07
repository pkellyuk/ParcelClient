using System.Collections.Generic;
using System;

namespace ParcelClient.Models
{
    public class Details
    {
        public string IncludedCover { get; set; }
        public string MaxWeight { get; set; }
    }

    public class AvailableExtra
    {
        public string Type { get; set; }
        public double Price { get; set; }
        public double Vat { get; set; }
        public double Total { get; set; }
        public Details Details { get; set; }
    }

    public class Links
    {
        public string ImageSmall { get; set; }
        public string Imagelarge { get; set; }
        public string ImageSvg { get; set; }
        public string Courier { get; set; }
        public string Service { get; set; }
    }

    public class Service
    {
        public string DropOffProviderCode { get; set; }
        public string CourierName { get; set; }
        public string CourierSlug { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string CollectionType { get; set; }
        public string DeliveryType { get; set; }
        public Links Links { get; set; }
        public double? MaxHeight { get; set; }
        public double? MaxWidth { get; set; }
        public double MaxLength { get; set; }
        public double MaxWeight { get; set; }
        public double MaxCover { get; set; }
        public bool IsPrinterRequired { get; set; }
        public string ShortDescriptions { get; set; }
        public string Overview { get; set; }
        public string Features { get; set; }
        public bool RequiresDimensions { get; set; }
        public string Classification { get; set; }
    }

    public class Quote
    {
        public int key { get; set; }
        public List<AvailableExtra> AvailableExtras { get; set; }
        public double Discount { get; set; }
        public List<object> Extras { get; set; }
        public Service Service { get; set; }
        public double TotalPrice { get; set; }
        public double TotalPriceExVat { get; set; }
        public double TotalVat { get; set; }
        public double UnitPrice { get; set; }
        public double VatRate { get; set; }
        public DateTime Collection { get; set; }
        public DateTime CutOff { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public double IncludedCover { get; set; }
        public object TariffSystem { get; set; }
        public object Distance { get; set; }
        public bool RequiresCommercialInvoice { get; set; }
    }

    public class ParcelResponseModel
    {
        public List<Quote> Quotes { get; set; }
    }


}
