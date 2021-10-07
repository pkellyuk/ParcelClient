using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelClient.Models
{
    public class QuoteRequest
    {
        public string parcelWeight { get; set; }
        public string countryFrom { get; set; }
        public string countryTo { get; set; }
    }
}
