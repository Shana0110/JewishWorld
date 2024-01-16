using System.Net.Http.Json;
using System.Reflection;
using model;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using ViewModel;
using Newtonsoft.Json;
using System.Text;
using static System.Net.WebRequestMethods;
using Microsoft.VisualBasic;
using MyService;

namespace CheckAPI;

    public class Program
    {
    static async Task Main(string[] args)
    {
        MyApiService myApiService = new MyApiService();
        CityList lst = await myApiService.SelectAllCity();
        // selectCountry
        string URI;
        HttpClient client = new HttpClient();
        URI = "http://localhost:5201/api/Selct/CountrySelector2";
        CountryList countries = await client.GetFromJsonAsync<CountryList>(URI);
        foreach (Country country in countries)
        {
            Console.Out.WriteLineAsync(country.CountryName);
        }
        Console.ReadLine();


        //insertCountry
        URI = "http://localhost:5201/api/Selct/InsertAsCountry2";
        Country country1 = new Country() { CountryName = "Japan" };
        var x = await client.PostAsJsonAsync<Country>(URI, country1);
        await Console.Out.WriteLineAsync(x.StatusCode + " " + x.Content + " " + x.IsSuccessStatusCode);

        // updateCountry
        Country country2 = countries.Last();
        country2.CountryName = "Rusie";
        URI = "http://localhost:5201/api/Selct/UpdateAsCountry2";
        var z = await client.PutAsJsonAsync<Country>(URI, country2);
        Console.WriteLine(z.StatusCode + " " + z.Content + " " + z.IsSuccessStatusCode);
        Console.WriteLine();

        //deleteCountry
        string cD = "";
        try
        {
            using (var cli = new HttpClient())
            {
                string URL = $"http://localhost:5201/api/Selct/DeleteAsCountry2/{countries.Last().Id}";
                var serializeContent = JsonConvert.SerializeObject(countries.Last());
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Delete;
                request.RequestUri = new Uri(URL);
                request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                var apiResponse = await client.SendAsync(request);
                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    cD = "OK";
            }
        }
        catch (Exception ex)
        {
            cD = ex.Message;
        }
        Console.WriteLine("cD= " + cD);

        //selectCity
        CountryDB countryDB = new CountryDB();
        URI = "http://localhost:5201/api/Selct/CitySelector2";
        CityList cities = await client.GetFromJsonAsync<CityList>(URI);
        foreach (City city in cities)
        {
            Console.Out.WriteLineAsync(city.CityName);
        }
        Console.ReadLine();

        // insertCity
        URI = "http://localhost:5201/api/Selct/InsertAsCity2";
        City city1 = new City() { CityName = "Paris", CountryCode = countryDB.SelectById(2) };
        var x2 = await client.PostAsJsonAsync<City>(URI, city1);
        await Console.Out.WriteLineAsync(x2.StatusCode + " " + x2.Content + " " + x2.IsSuccessStatusCode);

        // updateCity
        City city2 = cities.Last();
        city2.CityName = "Madrid";
        URI = "http://localhost:5201/api/Selct/UpdateAsCity2";
        var z2 = await client.PutAsJsonAsync<City>(URI, city2);
        Console.WriteLine(z2.StatusCode + " " + z2.Content + " " + z2.IsSuccessStatusCode);
        Console.WriteLine();

        //deleteCity
        cD = "";
        try
        {
            using (var cli = new HttpClient())
            {
                string URL = $"http://localhost:5201/api/Selct/DeleteAsCity2/{cities.Last().Id}";
                var serializeContent = JsonConvert.SerializeObject(cities.Last());
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Delete;
                request.RequestUri = new Uri(URL);
                request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                var apiResponse = await client.SendAsync(request);
                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    cD = "OK";
            }
        }
        catch (Exception ex)
        {
            cD = ex.Message;
        }
        Console.WriteLine("cD= " + cD);

        //selectPlace
        PlacesDB placeDB = new PlacesDB();
        URI = "http://localhost:5201/api/Selct/PlacesSelector2";
        PlacesList places = await client.GetFromJsonAsync<PlacesList>(URI);
        foreach (Places place in places)
        {
            Console.Out.WriteLineAsync(place.Adress);
        }
        Console.ReadLine();


        //insertPlaces
        CityDB cityDB = new CityDB();
        URI = "http://localhost:5201/api/Selct/InsertAsPlaces2";
        Places p1 = new Places() { Adress = "idid", CityCode = cityDB.SelectById(3) };
        var x3 = await client.PostAsJsonAsync<Places>(URI, p1);
        await Console.Out.WriteLineAsync(x3.StatusCode + " " + x3.Content + " " + x3.IsSuccessStatusCode);

        // updatePlaces
        Places p2 = places.Last();
        p2.Adress = "rere";
        URI = "http://localhost:5201/api/Selct/UpdateAsPlaces2";
        var z3 = await client.PutAsJsonAsync<Places>(URI, p2);
        Console.WriteLine(z3.StatusCode + " " + z3.Content + " " + z3.IsSuccessStatusCode);
        Console.WriteLine();


        //deletePlaces
        cD = "";
        try
        {
            using (var cli = new HttpClient())
            {
                string URL = $"http://localhost:5201/api/Selct/DeleteAsPlaces2/{places.Last().Id}";
                var serializeContent = JsonConvert.SerializeObject(places.Last());
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Delete;
                request.RequestUri = new Uri(URL);
                request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                var apiResponse = await client.SendAsync(request);
                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    cD = "OK";
            }
        }
        catch (Exception ex)
        {
            cD = ex.Message;
        }
        Console.WriteLine("cD= " + cD);


        //selectPopularPlace
        PopularPlacesDB pplaceDB = new PopularPlacesDB();
        URI = "http://localhost:5201/api/Selct/PopularPlacesSelector2";
        PopularPlacesList pplaces = await client.GetFromJsonAsync<PopularPlacesList>(URI);
        foreach (PopularPlace pp in pplaces)
        {
            Console.Out.WriteLineAsync(pp.Adress);
        }
        Console.ReadLine();


        // insertPopularPlaces

        URI = "http://localhost:5201/api/Selct/InsertAsPopularPlaces2";
        PopularPlace pp1 = new PopularPlace() { Adress = "idid", CityCode = cityDB.SelectById(3), Photo = "tyty" };
        var x4 = await client.PostAsJsonAsync<PopularPlace>(URI, pp1);
        await Console.Out.WriteLineAsync(x4.StatusCode + " " + x4.Content + " " + x4.IsSuccessStatusCode);


        // updatePopularPlaces
        PopularPlace pp2 = pplaces.Last();
        pp2.Adress = "rere";
        URI = "http://localhost:5201/api/Selct/UpdateAsPopularPlaces2";
        var z4 = await client.PutAsJsonAsync<PopularPlace>(URI, pp2);
        Console.WriteLine(z4.StatusCode + " " + z4.Content + " " + z4.IsSuccessStatusCode);
        Console.WriteLine();


        //deletePopularPlaces
        cD = "";
        try
        {
            using (var cli = new HttpClient())
            {
                string URL = $"http://localhost:5201/api/Selct/DeleteAsPopularPlaces2/{pplaces.Last().Id}";
                var serializeContent = JsonConvert.SerializeObject(pplaces.Last());
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Delete;
                request.RequestUri = new Uri(URL);
                request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                var apiResponse = await client.SendAsync(request);
                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    cD = "OK";
            }
        }
        catch (Exception ex)
        {
            cD = ex.Message;
        }
        Console.WriteLine("cD= " + cD);


        //selectBeithHabbad

        URI = "http://localhost:5201/api/Selct/BeitHabbadSelector2";
        BeitHabbadList beitHabbads = await client.GetFromJsonAsync<BeitHabbadList>(URI);
        foreach (BeitHabbad b in beitHabbads)
        {
            Console.Out.WriteLineAsync(b.Email);
        }
        Console.ReadLine();


        // insertBeitHabbad
        URI = "http://localhost:5201/api/Selct/InsertAsBeitHabbad2";
        BeitHabbad b1 = new BeitHabbad() { Adress = "tutu", Email = "tete", CityCode = cityDB.SelectById(3), Telephone = "0987" };
        var x5 = await client.PostAsJsonAsync<BeitHabbad>(URI, b1);
        await Console.Out.WriteLineAsync(x5.StatusCode + " " + x5.Content + " " + x5.IsSuccessStatusCode);

        // updateBeitHabbad
        BeitHabbad b2 = beitHabbads.Last();
        b2.Email = "rere";
        URI = "http://localhost:5201/api/Selct/UpdateAsBeitHabbad2";
        var z5 = await client.PutAsJsonAsync<BeitHabbad>(URI, b2);
        Console.WriteLine(z5.StatusCode + " " + z5.Content + " " + z5.IsSuccessStatusCode);
        Console.ReadLine();



        ////deleteBeitHabbad
        cD = "";
        try
        {
            using (var cli = new HttpClient())
            {
                string URL = $"http://localhost:5201/api/Selct/DeleteAsBeitHabbad2/{beitHabbads.Last().Id}";
                var serializeContent = JsonConvert.SerializeObject(beitHabbads.Last());
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Delete;
                request.RequestUri = new Uri(URL);
                request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                var apiResponse = await client.SendAsync(request);
                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    cD = "OK";
            }
        }
        catch (Exception ex)
        {
            cD = ex.Message;
        }
        Console.WriteLine("cD= " + cD);

        //selectkosherrestaurat

        URI = "http://localhost:5201/api/Selct/KosherRestaurantSelector2";
        KosherRestaurantList kosherrestaurats = await client.GetFromJsonAsync<KosherRestaurantList>(URI);
        foreach (KosherRestaurant k in kosherrestaurats)
        {
            Console.Out.WriteLineAsync(k.Adress);
        }
        Console.ReadLine();

        // insertkosherreataurat
        URI = "http://localhost:5201/api/Selct/InsertAsKosherRestaurant2";
        KosherRestaurant k1 = new KosherRestaurant() { Adress = "tutu", CityCode = cityDB.SelectById(3), Telephone = "0987", Name = "tuy", TypeOfFood = "halavi" };
        var x6 = await client.PostAsJsonAsync<KosherRestaurant>(URI, k1);
        await Console.Out.WriteLineAsync(x6.StatusCode + " " + x6.Content + " " + x6.IsSuccessStatusCode);


        // updatekosherrestaurat 
        KosherRestaurant k2 = kosherrestaurats.Last();
        k2.Telephone = "0909";
        URI = "http://localhost:5201/api/Selct/UpdateAsKosherRestaurant2";
        var z6 = await client.PutAsJsonAsync<KosherRestaurant>(URI, k2);
        Console.WriteLine(z6.StatusCode + " " + z6.Content + " " + z6.IsSuccessStatusCode);
        Console.ReadLine();


        //deletekosherrestaurat
        cD = "";
        try
        {
            using (var cli = new HttpClient())
            {
                string URL = $"http://localhost:5201/api/Selct/DeleteAsKosherRestaurant2/" +
                    $"{kosherrestaurats.Last().Id}";
                var serializeContent = JsonConvert.SerializeObject(kosherrestaurats.Last());
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Delete;
                request.RequestUri = new Uri(URL);
                request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                var apiResponse = await client.SendAsync(request);
                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    cD = "OK";
            }
        }
        catch (Exception ex)
        {
            cD = ex.Message;
        }
        Console.WriteLine("cD= " + cD);


        //selectsyagogue
        URI = "http://localhost:5201/api/Selct/SynagogueSelector2";
        SynagogueList ss = await client.GetFromJsonAsync<SynagogueList>(URI);
        foreach (Synagogue s in ss)
        {
            Console.Out.WriteLineAsync(s.Adress);
        }
        Console.ReadLine();

        //insertsyagogue
       URI = "http://localhost:5201/api/Selct/InsertAsSynagogue2";
        Synagogue s1 = new Synagogue() { Adress = "tutu", OpenHour = new TimeOnly(12, 00), CloseHour = new TimeOnly(16, 00), CityCode = cityDB.SelectById(3) };
        var x7 = await client.PostAsJsonAsync<Synagogue>(URI, s1);
        await Console.Out.WriteLineAsync(x7.StatusCode + " " + x7.Content + " " + x7.IsSuccessStatusCode);

        //updatesyagogue
        Synagogue s2 = ss.Last();
        s2.Adress = "ghgh";
        URI = "http://localhost:5201/api/Selct/UpdateAsSynagogue2";
        var z7 = await client.PutAsJsonAsync<Synagogue>(URI, s2);
        Console.WriteLine(z7.StatusCode + " " + z7.Content + " " + z7.IsSuccessStatusCode);
        Console.ReadLine();

        //deletesyagogue
        cD = "";
        try
        {
            using (var cli = new HttpClient())
            {
                string URL = $"http://localhost:5201/api/Selct/DeleteAsSynagogue2" +
                    $"{ss.Last().Id}";
                var serializeContent = JsonConvert.SerializeObject(ss.Last());
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Delete;
                request.RequestUri = new Uri(URL);
                request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                var apiResponse = await client.SendAsync(request);
                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    cD = "OK";
            }
        }
        catch (Exception ex)
        {
            cD = ex.Message;
        }
        Console.WriteLine("cD= " + cD);



        //selectratig
        URI = "http://localhost:5201/api/Selct/RatingSelector2";
        RatingList rs = await client.GetFromJsonAsync<RatingList>(URI);
        foreach (Rating r in rs)
        {
            Console.Out.WriteLineAsync(r.Rate.ToString());
        }
        Console.ReadLine();

        // insertratig
        PopularPlacesDB p = new PopularPlacesDB();
        URI = "http://localhost:5201/api/Selct/InsertAsRating2";
        Rating r1 = new Rating() { Rate = 4, IdPopularPlace = p.SelectById(6) };
        var x8 = await client.PostAsJsonAsync<Rating>(URI, r1);
        await Console.Out.WriteLineAsync(x8.StatusCode + " " + x8.Content + " " + x8.IsSuccessStatusCode);


        // updatekosherrestaurat 
        Rating r2 = rs.Last();
        r2.Rate = 5;
        URI = "http://localhost:5201/api/Selct/UpdateAsRating2";
        var z8 = await client.PutAsJsonAsync<Rating>(URI, r2);
        Console.WriteLine(z8.StatusCode + " " + z8.Content + " " + z8.IsSuccessStatusCode);
        Console.ReadLine();

        //deleteratig
        cD = "";
        try
        {
            using (var cli = new HttpClient())
            {
                string URL = $"http://localhost:5201/api/Selct/DeleteAsRating2" +
                    $"{rs.Last().Id}";
                var serializeContent = JsonConvert.SerializeObject(rs.Last());
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Delete;
                request.RequestUri = new Uri(URL);
                request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                var apiResponse = await client.SendAsync(request);
                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    cD = "OK";
            }
        }
        catch (Exception ex)
        {
            cD = ex.Message;
        }
        Console.WriteLine("cD= " + cD);


        //selectuser
        URI = "http://localhost:5201/api/Selct/UserSelector2";
        UserList us = await client.GetFromJsonAsync<UserList>(URI);
        foreach (User u in us)
        {
            Console.Out.WriteLineAsync(u.Code);
        }
        Console.ReadLine();

        //insertuser
        URI = "http://localhost:5201/api/Selct/InsertAsUser2";
        User u1 = new User() { Name = " gtg", Code = "676" };
        var x9 = await client.PostAsJsonAsync<User>(URI, u1);
        await Console.Out.WriteLineAsync(x9.StatusCode + " " + x9.Content + " " + x9.IsSuccessStatusCode);

        // updateuser 
        User u2 = us.Last();
        u2.Code = "6";
        URI = "http://localhost:5201/api/Selct/UpdateAsUser2";
        var z9 = await client.PutAsJsonAsync<User>(URI, u2);
        Console.WriteLine(z9.StatusCode + " " + z9.Content + " " + z9.IsSuccessStatusCode);
        Console.ReadLine();

        //deleteuser
        cD = "";
        try
        {
            using (var cli = new HttpClient())
            {
                string URL = $"http://localhost:5201/api/Selct/DeleteAsUser2" +
                    $"{us.Last().Id}";
                var serializeContent = JsonConvert.SerializeObject(us.Last());
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Delete;
                request.RequestUri = new Uri(URL);
                request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json"); ;
                var apiResponse = await client.SendAsync(request);
                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    cD = "OK";
            }
        }
        catch (Exception ex)
        {
            cD = ex.Message;
        }
        Console.WriteLine("cD= " + cD);



    }
}
