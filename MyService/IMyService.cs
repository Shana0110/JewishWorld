using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace MyService
{
    public interface IMyService
    {
        public Task<CountryList> SelectAllCountry();
        public Task<int> InsertAsCountry(Country country);
        public Task<int> UpdateAsCountry(Country country);
        public Task<int> DeleteAsCountry(Country country);


        public Task<CityList> SelectAllCity();
        public Task<int> InsertAsCity(City city);
        public Task<int> UpdateAsCity(City city);
        public Task<int> DeleteAsCity(City city);


        public Task<PlacesList> SelectAllplaces();
        public Task<int> InsertAsPlaces(Places places);
        public Task<int> UpdateAsPlaces(Places places);
        public Task<int> DeleteAsPlaces(Places places);


        public Task<PopularPlacesList> SelectAllPopularPlaces();
        public Task<int> InsertAsPopularPlaces(PopularPlace popularPlace);
        public Task<int> UpdateAsPopularPlaces(PopularPlace popularPlace);
        public Task<int> DeleteAsPopularPlaces(PopularPlace popularPlace);


        public Task<BeitHabbadList> SelectAllBeitHabbad();
        public Task<int> InsertAsBeitHabbad(BeitHabbad beitHabbad);
        public Task<int> UpdateAsBeitHabbad(BeitHabbad beitHabbad);
        public Task<int> DeleteAsBeitHabbad(BeitHabbad beitHabbad);


        public Task<KosherRestaurantList> SelectAllKosherRestaurant();
        public Task<int> InsertAsKosherRestaurant(KosherRestaurant kosherRestaurant);
        public Task<int> UpdateAsKosherRestaurant(KosherRestaurant kosherRestaurant);
        public Task<int> DeleteAsKosherRestaurant(KosherRestaurant kosherRestaurant);


        public Task<SynagogueList> SelectAllSynagogue();
        public Task<int> InsertAsSynagogue(Synagogue synagogue);
        public Task<int> UpdateAsSynagogue(Synagogue synagogue);
        public Task<int> DeleteAsSynagogue(Synagogue synagogue);


        public Task<RatingList> SelectAllRating();
        public Task<int> InsertAsRating(Rating rating);
        public Task<int> UpdateAsRating(Rating rating);
        public Task<int> DeleteAsRating(Rating rating);


        public Task<UserList> SelectAllUser();
        public Task<int> InsertAsUser(User user);
        public Task<int> UpdateAsUser(User user);
        public Task<int> DeleteAsUser(User user);











    }
}
