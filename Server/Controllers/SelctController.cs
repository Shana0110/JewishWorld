 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;
using ViewModel;

namespace Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SelctController : ControllerBase
    {
        
        [HttpGet]
        [ActionName("CountrySelector2")]

        public CountryList SelectAllCountry2()
        {
            CountryDB db = new CountryDB();
            CountryList countries =  db.SelectAll();
            return countries;
        }
        
        [HttpPost]
        public int InsertAsCountry2(Country country)
        {
            CountryDB db = new CountryDB();
            db.Insert(country);
            int x = db.SaveChanges();
            return x;
        }
        
        [HttpPut]
        public int UpdateAsCountry2([FromBody] Country country)
        {
            CountryDB db = new CountryDB();
            db.Update(country);
            int x = db.SaveChanges();
            return x;
        }
       
        [HttpDelete("{id}")]
        public int DeleteAsCountry2(int id)
        {
            Country c = (new CountryDB().SelectAll()).Find(x => x.Id == id);
            CountryDB db = new CountryDB();
            db.Delete(c);
            int x = db.SaveChanges();
            return x;
        }

        
        [HttpGet]
        [ActionName("CitySelector2")]
        public CityList SelectAllCity2()
        {
            CityDB db = new CityDB();
            CityList cities = db.SelectAll();
            return cities;
        }
        
        [HttpPost]
        public int InsertAsCity2(City city)
        {
            CityDB db = new CityDB();
            db.Insert(city);
            int x =db.SaveChanges();
            return x;
        }
        [HttpPut]
       
        [HttpPut]
        public int UpdateAsCity2([FromBody] City city)
        {
            CityDB db = new CityDB();
            db.Update(city);
            int x = db.SaveChanges();
            return x;
        }
        
        [HttpDelete("{id}")]
        public int DeleteAsCity2(int id)
        {
            City ct = (new CityDB().SelectAll()).Find(x => x.Id == id);
            CityDB db = new CityDB();
            db.Delete(ct);
            int x = db.SaveChanges();
            return x;
        }


        
        [HttpGet]
        [ActionName("PlacesSelector2")]
        public PlacesList SelectAllplaces2()
        {
            PlacesDB db = new PlacesDB();
            PlacesList places = db.SelectAll();
            return places;
        }
       
        [HttpPost]
        public int InsertAsPlaces2(Places places)
        {
            PlacesDB db = new PlacesDB();
            db.Insert(places);
            int x = db.SaveChanges();
            return x;
        }
       
        [HttpPut]
        public int UpdateAsPlaces2([FromBody] Places place)
        {
            PlacesDB db = new PlacesDB();
            db.Update(place);
            int x = db.SaveChanges();
            return x;
        }
        
        [HttpDelete("{id}")]
        public int DeleteAsPlaces2(int id)
        {
            Places pl = (new PlacesDB().SelectAll()).Find(x => x.Id == id);
            PlacesDB db = new PlacesDB();
            db.Delete(pl);
            int x = db.SaveChanges();
            return x;
        }

       
        [HttpGet]
        [ActionName("PopularPlacesSelector2")]
        public PopularPlacesList SelectAllPopularPlaces2()
        {
            PopularPlacesDB db = new PopularPlacesDB();
            PopularPlacesList popularPlaces = db.SelectAll();
            return popularPlaces;
        }
       
        [HttpPost]
        public int InsertAsPopularPlaces2(PopularPlace popularPlace)
        {
            PopularPlacesDB db = new PopularPlacesDB();
            db.Insert(popularPlace);
            int x = db.SaveChanges();
            return x;
        }
        
        [HttpPut]
        public int UpdateAsPopularPlaces2([FromBody] PopularPlace popularPlace)
        {
            PopularPlacesDB db = new PopularPlacesDB();
            db.Update(popularPlace);
            int x = db.SaveChanges();
            return x;
        }
        
        [HttpDelete("{id}")]
        public int DeleteAsPopularPlaces2(int id)
        {
            PopularPlace pp = (new PopularPlacesDB().SelectAll()).Find(x => x.Id == id);
            PopularPlacesDB db = new PopularPlacesDB();
            db.Delete(pp);
            int x = db.SaveChanges();
            return x;
        }

       
        [HttpGet]
        [ActionName("BeitHabbadSelector2")]
        public BeitHabbadList SelectAllBeitHabbad2()
        {
            BeitHabbadDB db = new BeitHabbadDB();
            BeitHabbadList beitHabbad = db.SelectAll();
            return beitHabbad;
        }
       
        [HttpPost]
        public int InsertAsBeitHabbad2(BeitHabbad beitHabbad)
        {
            BeitHabbadDB db = new BeitHabbadDB();
            db.Insert(beitHabbad);
            int x = db.SaveChanges();
            return x;
        }
        
        [HttpPut]
        public int UpdateAsBeitHabbad2([FromBody] BeitHabbad beitHabbad)
        {
            BeitHabbadDB db = new BeitHabbadDB();
            db.Update(beitHabbad);
            int x = db.SaveChanges();
            return x;
        }
        
        [HttpDelete("{id}")]
        public int DeleteAsBeitHabbad2(int id)
        {
            BeitHabbad bh = (new BeitHabbadDB().SelectAll()).Find(x => x.Id == id);
            BeitHabbadDB db = new BeitHabbadDB();
            db.Delete(bh);
            int x = db.SaveChanges();
            return x;
        }



      
        [HttpGet]
        [ActionName("KosherRestaurantSelector2")]
        public KosherRestaurantList SelectAllKosherRestaurant2()
        {
            KosherRestaurantDB db = new KosherRestaurantDB();
            KosherRestaurantList kosherRestaurants = db.SelectAll();
            return kosherRestaurants;
        }
        
        [HttpPost]
        public int InsertAsKosherRestaurant2(KosherRestaurant kosherRestaurant)
        {
            KosherRestaurantDB db = new KosherRestaurantDB();
            db.Insert(kosherRestaurant);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        
        [HttpPut]
        public int UpdateAsKosherRestaurant2([FromBody] KosherRestaurant kosherRestaurant)
        {
            KosherRestaurantDB db = new KosherRestaurantDB();
            db.Update(kosherRestaurant);
            int x = db.SaveChanges();
            return x;
        }
       
        [HttpDelete("{id}")]
        public int DeleteAsKosherRestaurant2(int id)
        {
            KosherRestaurant kr = (new KosherRestaurantDB().SelectAll()).Find(x => x.Id == id);
            KosherRestaurantDB db = new KosherRestaurantDB();
            db.Delete(kr);
            int x = db.SaveChanges();
            return x;
        }


       
        [HttpGet]
        [ActionName("SynagogueSelector2")]
        public SynagogueList SelectAllSynagogue2()
        {
            SynagogueDB db = new SynagogueDB();
            SynagogueList synagogues = db.SelectAll();
            return synagogues;
        }
        
        [HttpPost]
        public int InsertAsSynagogue2(Synagogue synagogue)
        {
            SynagogueDB db = new SynagogueDB();
            db.Insert(synagogue);
            int x = db.SaveChanges();
            return x;
        }
       
        [HttpPut]
        public int UpdateAsSynagogue2([FromBody] Synagogue synagogue)
        {
            SynagogueDB db = new SynagogueDB();
            db.Update(synagogue);
            int x = db.SaveChanges();
            return x;
        }
       
        [HttpDelete("{id}")]
        public int DeleteAsSynagogue2(int id)
        {
            Synagogue s = (new SynagogueDB().SelectAll()).Find(x => x.Id == id);
            SynagogueDB db = new SynagogueDB();
            db.Delete(s);
            int x = db.SaveChanges();
            return x;
        }


        [HttpGet]
        [ActionName("RatingSelector2")]
        public RatingList SelectAllRating2()
        {
            RatingDB db = new RatingDB();
            RatingList ratings = db.SelectAll();
            return ratings;
        }
       
        [HttpPost]
        public int InsertAsRating2(Rating rating)
        {
            RatingDB db = new RatingDB();
            db.Insert(rating);
            int x = db.SaveChanges();
            return x;
        }
        
        [HttpPut]
        public int UpdateAsRating2([FromBody] Rating rating)
        {
            RatingDB db = new RatingDB();
            db.Update(rating);
            int x = db.SaveChanges();
            return x;
        }
       
        [HttpDelete("{id}")]
        public int DeleteAsRating2(int id)
        {
            Rating r = (new RatingDB().SelectAll()).Find(x => x.Id == id);
            RatingDB db = new RatingDB();
            db.Delete(r);
            int x = db.SaveChanges();
            return x;
        }

       
        [HttpGet]
        [ActionName("UserSelector2")]
        public UserList SelectAllUser2()
        {
            UserDB db = new UserDB();
            UserList users = db.SelectAll();
            return users;
        }
       
        [HttpPost]
        public int InsertAsUser2(User user)
        {
            UserDB db = new UserDB();
            db.Insert(user);
            int x = db.SaveChanges();
            return x;
        }
        
        [HttpPut]
        public int UpdateAsUser2([FromBody] User user)
        {
            UserDB db = new UserDB();
            db.Update(user);
            int x = db.SaveChanges();
            return x;
        }
        
        [HttpDelete("{id}")]
        public int DeleteAsUser2(int id)
        {
            User u = (new UserDB().SelectAll()).Find(x => x.Id == id);
            UserDB db = new UserDB();
            db.Delete(u);
            int x = db.SaveChanges();
            return x;
        }
    }
}

