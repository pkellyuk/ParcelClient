using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ParcelClient.Models;
using RestSharp;

namespace ParcelClient.Lib
{
    public class ParcelLib
    {
        private string ApiEndpoint { get; set; }
        private string ApiClientId { get; set; }
        private string ApiSecret { get; set; }
        private string ApiScope { get; set; }
        private TokenResponse ApiToken { get; set; }

        public ParcelLib(string apiEndpoint, string apiClientId, string apiSecret, string apiScope)
        {
            ApiEndpoint = apiEndpoint;
            ApiClientId = apiClientId;
            ApiSecret = apiSecret;
            ApiScope = apiScope;
        }

        public bool GetToken()
        {
            RestRequest request = new RestRequest();
            request.Method = Method.POST;
            var restclient = new RestClient(ApiEndpoint + "/auth/connect/token");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("client_id", ApiClientId);
            request.AddParameter("client_secret", ApiSecret);
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("scope", ApiScope);
            var tResponse = restclient.Execute(request);
            if(tResponse == null)
            {
                return false;
            }

            string responseJson = tResponse.Content;
            
            if(string.IsNullOrEmpty(responseJson))
            {
                return false;
            }

            ApiToken = JsonConvert.DeserializeObject<TokenResponse>(responseJson);

            if(ApiToken == null)
            {               
                return false;
            }

            if(string.IsNullOrEmpty(ApiToken.AccessToken))
            {
                return false;
            }

            return true;
        }

        public ParcelResponseModel GetQuote(double parcelWeight, string countryFrom, string countryTo)
        {
            // Create the request to get the parcel quote
            ParcelRequestModel parcelRequest = new ParcelRequestModel();
            parcelRequest.CollectionAddress = new CollectionAddress();
            parcelRequest.DeliveryAddress = new DeliveryAddress();
            parcelRequest.Parcels = new List<Parcel>();

            Parcel parcel = new Parcel();
            parcel.Weight = parcelWeight;
            parcelRequest.Parcels.Add(parcel);
    
            parcelRequest.CollectionAddress.Country = countryFrom;
            parcelRequest.DeliveryAddress.Country = countryTo;

            RestRequest request = new RestRequest();
            request.Method = Method.POST;
            var restclient = new RestClient(ApiEndpoint + "/api/quotes");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + ApiToken.AccessToken);
            request.AddJsonBody(parcelRequest);
            var tResponse = restclient.Execute(request);
            string responseJson = tResponse.Content;

            if(string.IsNullOrEmpty(responseJson))
            {
                return null;
            }

            ParcelResponseModel parcelResponseList = JsonConvert.DeserializeObject<ParcelResponseModel>(responseJson);
            return parcelResponseList;
        }
    }
}
