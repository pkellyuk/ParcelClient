using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using ParcelClient.Models;
using ParcelClient.Lib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ParcelClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelController : ControllerBase
    {
        private readonly ILogger<ParcelController> _logger;

        public ParcelController(ILogger<ParcelController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ParcelResponseModel GetQuote([FromBody] QuoteRequest quoteRequest)
        {
            // call to ParcelLib
            ParcelLib parcelLib = new ParcelLib(Config.ApiEndpoint, Config.ApiClientId, Config.ApiSecret, Config.ApiScope);
            if(parcelLib.GetToken() != true)
            {
                return null;
            }

            ParcelResponseModel parcelResponse = parcelLib.GetQuote(Convert.ToDouble(quoteRequest.parcelWeight), quoteRequest.countryFrom, quoteRequest.countryTo);

            // create a key column on each quote to help react index the result object
            int x = 0;
            foreach(Quote quote in parcelResponse.Quotes)
            {
                quote.key = x;
                x++;
            }

            // sort the results
            parcelResponse.Quotes = parcelResponse.Quotes.OrderBy(x => x.TotalPrice).ToList();
            return parcelResponse;
        }
    }
}
