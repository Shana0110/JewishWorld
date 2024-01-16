using model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyService
{
    public class MyApiService : IMyService
    {
        public async Task<CountryList> SelectAllCountry()
        {
            HttpClient client = new HttpClient();
            CountryList countries = null;
            try
            {
                string URI = "http://localhost:5201/api/Selct/CountrySelector2";
                countries = await client.GetFromJsonAsync<CountryList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return countries;
        }
        public async Task<int> InsertAsCountry(Country country)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/InsertAsCountry2";
            HttpResponseMessage respon=await client.PostAsJsonAsync<Country>(URI, country);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
            
        }
        public async Task<int> UpdateAsCountry(Country country)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/UpdateAsCountry2";
            HttpResponseMessage respon = await client.PostAsJsonAsync<Country>(URI, country);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
        }
        public async Task<int> DeleteAsCountry(Country country)
        {
            HttpClient client = new HttpClient();
            try
            {
                using (var cli = new HttpClient())
                {
                    string URI = $"http://localhost:5201/api/Selct/DeleteAsCountry2/{country.Id}";
                    var serializeContent = JsonConvert.SerializeObject(country);
                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(URI);
                    request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                    var apiResponse = await client.SendAsync(request);
                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                        return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            return 0;
        }


        public async Task<CityList> SelectAllCity()
        {
            HttpClient client = new HttpClient();
            CityList cities = null;

            try
            {
                string URI = "http://localhost:5201/api/Selct/CitySelector2";
                try
                {
                    cities = await client.GetFromJsonAsync<CityList>(URI);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return cities;

        }
        public  async Task<int> InsertAsCity(City city)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/InsertAsCity2";
            HttpResponseMessage respon = await client.PostAsJsonAsync<City>(URI, city);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
        }
        public async Task<int> UpdateAsCity(City city)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/UpdateAsCity2";
            HttpResponseMessage respon = await client.PostAsJsonAsync<City>(URI, city);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
        }
        public async Task<int> DeleteAsCity(City city)
        {
            HttpClient client = new HttpClient();
            try
            {
                using (var cli = new HttpClient())
                {
                    string URI = $"\"http://localhost:5201/api/Selct/DeleteAsCity2/{city.Id}";
                    var serializeContent = JsonConvert.SerializeObject(city);
                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(URI);
                    request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                    var apiResponse = await client.SendAsync(request);
                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                        return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            return 0;
        }



        public async Task<PlacesList> SelectAllplaces()
        {
            HttpClient client = new HttpClient();
            PlacesList places = null;
            try
            {
                string URI = "http://localhost:5201/api/Selct/PlacesSelector2";
                places = await client.GetFromJsonAsync<PlacesList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return places;
        }
        public async Task<int> InsertAsPlaces(Places places)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/InsertAsPlaces2";
            HttpResponseMessage respon = await client.PostAsJsonAsync<Places>(URI, places);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
        }
        public async Task<int> UpdateAsPlaces(Places places)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/UpdateAsPlaces2";
            HttpResponseMessage respon = await client.PostAsJsonAsync<Places>(URI, places);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
        }
        public async Task<int> DeleteAsPlaces(Places places)
        {
            HttpClient client = new HttpClient();
            try
            {
                using (var cli = new HttpClient())
                {
                    string URI = $"http://localhost:5201/api/Selct/DeleteAsPlaces2/{places.Id}";
                    var serializeContent = JsonConvert.SerializeObject(places);
                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(URI);
                    request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                    var apiResponse = await client.SendAsync(request);
                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                        return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            return 0;
        }



        public async Task<PopularPlacesList> SelectAllPopularPlaces()
        {
            HttpClient client = new HttpClient();
            PopularPlacesList pplaces = null;
            try
            {
                string URI = "http://localhost:5201/api/Selct/PopularPlacesSelector2";
                pplaces = await client.GetFromJsonAsync<PopularPlacesList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return pplaces;
        }
        public  async Task<int> InsertAsPopularPlaces(PopularPlace popularPlace)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/InsertAsPopularPlaces2";
            HttpResponseMessage respon = await client.PostAsJsonAsync<PopularPlace>(URI, popularPlace);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
        }
        public async Task<int> UpdateAsPopularPlaces(PopularPlace popularPlace)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/UpdateAsPopularPlaces2";
            HttpResponseMessage respon = await client.PostAsJsonAsync<PopularPlace>(URI, popularPlace);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
        }
        public async Task<int> DeleteAsPopularPlaces(PopularPlace popularPlace)
        {
            HttpClient client = new HttpClient();
            try
            {
                using (var cli = new HttpClient())
                {
                    string URI = $"http://localhost:5201/api/Selct/DeleteAsPopularPlaces2/{popularPlace.Id}";
                    var serializeContent = JsonConvert.SerializeObject(popularPlace);
                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(URI);
                    request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                    var apiResponse = await client.SendAsync(request);
                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                        return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            return 0;
        }




        public async Task<BeitHabbadList> SelectAllBeitHabbad()
        {
            HttpClient client = new HttpClient();
            BeitHabbadList beitHabbads = null;
            try
            {
                string URI = "http://localhost:5201/api/Selct/BeitHabbadSelector2";
                beitHabbads = await client.GetFromJsonAsync<BeitHabbadList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return beitHabbads;
            
        }
        public async Task<int> InsertAsBeitHabbad(BeitHabbad beitHabbad)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/InsertAsBeitHabbad2";
            HttpResponseMessage respon = await client.PostAsJsonAsync<BeitHabbad>(URI, beitHabbad);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
        }
        public async Task<int> UpdateAsBeitHabbad(BeitHabbad beitHabbad)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/UpdateAsBeitHabbad2";
            HttpResponseMessage respon = await client.PostAsJsonAsync<BeitHabbad>(URI, beitHabbad);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
        }
        public async Task<int> DeleteAsBeitHabbad(BeitHabbad beitHabbad)
        {
            HttpClient client = new HttpClient();
            try
            {
                using (var cli = new HttpClient())
                {
                    string URI = $"http://localhost:5201/api/Selct/DeleteAsBeitHabbad2/{beitHabbad.Id}";
                    var serializeContent = JsonConvert.SerializeObject(beitHabbad);
                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(URI);
                    request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                    var apiResponse = await client.SendAsync(request);
                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                        return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            return 0;
        }




        public async Task<KosherRestaurantList> SelectAllKosherRestaurant()
        {
            HttpClient client = new HttpClient();
            KosherRestaurantList k = null;
            try
            {
                string URI = "http://localhost:5201/api/Selct/KosherRestaurantSelector2";
                k= await client.GetFromJsonAsync<KosherRestaurantList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return k;
        }
        public async Task<int> InsertAsKosherRestaurant(KosherRestaurant kosherRestaurant)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/InsertAsKosherRestaurant2";
            HttpResponseMessage respon = await client.PostAsJsonAsync<KosherRestaurant>(URI, kosherRestaurant);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
        }

        public async Task<int> UpdateAsKosherRestaurant(KosherRestaurant kosherRestaurant)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/UpdateAsKosherRestaurant2";
            HttpResponseMessage respon = await client.PostAsJsonAsync<KosherRestaurant>(URI, kosherRestaurant);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
        }
        public async Task<int> DeleteAsKosherRestaurant(KosherRestaurant kosherRestaurant)
        {
            HttpClient client = new HttpClient();
            try
            {
                using (var cli = new HttpClient())
                {
                    string URI = $"http://localhost:5201/api/Selct/DeleteAsKosherRestaurant2/{kosherRestaurant.Id}";
                    var serializeContent = JsonConvert.SerializeObject(kosherRestaurant);
                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(URI);
                    request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                    var apiResponse = await client.SendAsync(request);
                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                        return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            return 0;
        }






        public async Task<SynagogueList> SelectAllSynagogue()
        {
            HttpClient client = new HttpClient();
            SynagogueList s = null;
            try
            {
                string URI = "http://localhost:5201/api/Selct/SynagogueSelector2";
                s = await client.GetFromJsonAsync<SynagogueList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return s;
        }
        public async Task<int> InsertAsSynagogue(Synagogue synagogue)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/InsertAsSynagogue2";
            HttpResponseMessage respon = await client.PostAsJsonAsync<Synagogue>(URI, synagogue);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
        }
        public async Task<int> UpdateAsSynagogue(Synagogue synagogue)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/UpdateAsSynagogue2";
            HttpResponseMessage respon = await client.PostAsJsonAsync<Synagogue>(URI, synagogue);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
        }
        public async Task<int> DeleteAsSynagogue(Synagogue synagogue)
        {
            HttpClient client = new HttpClient();
            try
            {
                using (var cli = new HttpClient())
                {
                    string URI = $"\"http://localhost:5201/api/Selct/DeleteAsSynagogue2/{synagogue.Id}";
                    var serializeContent = JsonConvert.SerializeObject(synagogue);
                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(URI);
                    request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                    var apiResponse = await client.SendAsync(request);
                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                        return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            return 0;
        }





        public async Task<RatingList> SelectAllRating()
        {
            HttpClient client = new HttpClient();
            RatingList r = null;
            try
            {
                string URI = "http://localhost:5201/api/Selct/RatingSelector2";
                r = await client.GetFromJsonAsync<RatingList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return r;
        }
        public async Task<int> InsertAsRating(Rating rating)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/InsertAsRating2";
            HttpResponseMessage respon = await client.PostAsJsonAsync<Rating>(URI, rating);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
        }
        public async Task<int> UpdateAsRating(Rating rating)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/UpdateAsRating2";
            HttpResponseMessage respon = await client.PostAsJsonAsync<Rating>(URI, rating);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
        }

        public async Task<int> DeleteAsRating(Rating rating)
        {
            HttpClient client = new HttpClient();
            try
            {
                using (var cli = new HttpClient())
                {
                    string URI = $"\"http://localhost:5201/api/Selct/DeleteAsRating2/{rating.Id}";
                    var serializeContent = JsonConvert.SerializeObject(rating);
                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(URI);
                    request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                    var apiResponse = await client.SendAsync(request);
                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                        return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            return 0;
        }






        public  async Task<UserList> SelectAllUser()
        {
            HttpClient client = new HttpClient();
            UserList u = null;
            try
            {
                string URI = "http://localhost:5201/api/Selct/UserSelector2";
                u = await client.GetFromJsonAsync<UserList>(URI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return u;
        }
        public async Task<int> InsertAsUser(User user)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/InsertAsUser2";
            HttpResponseMessage respon = await client.PostAsJsonAsync<User>(URI ,user);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
        }
        public async Task<int> UpdateAsUser(User user)
        {
            HttpClient client = new HttpClient();
            string URI = "http://localhost:5201/api/Selct/UpdateAsUser2";
            HttpResponseMessage respon = await client.PostAsJsonAsync<User>(URI, user);
            if (respon.IsSuccessStatusCode)
                return 1;
            return 0;
        }
        public async Task<int> DeleteAsUser(User user)
        {
            HttpClient client = new HttpClient();
            try
            {
                using (var cli = new HttpClient())
                {
                    string URI = $"http://localhost:5201/api/Selct/DeleteAsUser2/{user.Id}";
                    var serializeContent = JsonConvert.SerializeObject(user);
                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(URI);
                    request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                    var apiResponse = await client.SendAsync(request);
                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                        return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            return 0;
        }
    } 
}
