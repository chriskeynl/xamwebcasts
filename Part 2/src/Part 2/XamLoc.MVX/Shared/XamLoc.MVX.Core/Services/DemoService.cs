using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using XamLoc.MVX.Core.Models;

namespace XamLoc.MVX.Core.Services
{
	public interface IDemoService
	{
		Task<DashboardStatistics> GetDashboardStatistics();
		Task<List<Developer>> GetDevelopers();
		Task<bool> PostDeveloper(string name, string country);
		Task<string> GetCountryFromLatLong(double lattitude, double longitude);
	}

    public class DemoService:IDemoService
    {
        public async Task<DashboardStatistics> GetDashboardStatistics()
        {
            try
            {
                var mobileService = new MobileServiceClient("http://oscxamdemoapi20160902105611.azurewebsites.net");

                var arguments = new Dictionary<string, string>
                {
                    {"ZUMO-API-VERSION", "2.0.0" }
                };

                var result = await mobileService.InvokeApiAsync<DashboardStatistics>("DashboardStatistics", HttpMethod.Get, arguments);
                if (result != null)
                    return result;

            }
            catch (Exception)
            {
            }

            return new DashboardStatistics
            {
                NumberOfDevelopers = 0,
                NumberOfCountries = 0
            };
        }

        public async Task<List<Developer>> GetDevelopers()
        {
            try
            {
                var mobileService = new MobileServiceClient("http://oscxamdemoapi20160902105611.azurewebsites.net");

                var arguments = new Dictionary<string, string>
                {
                    {"ZUMO-API-VERSION", "2.0.0" }
                };

                var result = await mobileService.InvokeApiAsync<List<Developer>>("Developer", HttpMethod.Get, arguments);
                if (result != null)
                    return result;

            }
            catch (Exception)
            {
            }

            return new List<Developer>();
        }

        public async Task<bool> PostDeveloper(string name, string country)
        {
            try
            {
                var mobileService = new MobileServiceClient("http://oscxamdemoapi20160902105611.azurewebsites.net");
                if (string.IsNullOrEmpty(name))
                    name = "Anonymous";

                var arguments = new Dictionary<string, string>
                {
                    {"ZUMO-API-VERSION", "2.0.0" },
                    {"Name",name},
                    {"Country",country},
                    {"Token","DerF#1gkon__234lkv2j5ct384hg"}
                };

                await mobileService.InvokeApiAsync<List<Developer>>("Developer", HttpMethod.Post, arguments);
                return true;
            }
            catch (Exception)
            {
            }

            return false;
        }

        public async Task<string> GetCountryFromLatLong(double lattitude, double longitude)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    var lat = lattitude.ToString().Replace(",", ".");
                    var lon = longitude.ToString().Replace(",", ".");

                    var httpClient = new HttpClient();
                    var url = string.Format("https://maps.googleapis.com/maps/api/geocode/json?latlng={0},{1}&language=en", lat, lon);
                    var result = await httpClient.GetAsync(url);
                    var resultString = await result.Content.ReadAsStringAsync();
                    var geoResult = JsonConvert.DeserializeObject<GeoResponse>(resultString);

                    if (geoResult == null)
                        return null;

                    var adressResults = geoResult.Result.SelectMany(gr => gr.Adresses).Where(a => a.Types.Contains("country")).ToList();
                    if (adressResults != null && adressResults.Count() > 0)
                    {
                        return adressResults.First().LongName;
                    }
                }
                catch (Exception)
                {
                    Debug.WriteLine("Failed to resolve country from lat lon");
                }

                return null;
            });
        }
    }
}