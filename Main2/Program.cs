using model;
using ViewModel;
using MyService;

//CityDB c=new CityDB();
//CityList cl=c.SelectAll();
//foreach(City city in cl)
//{
//    Console.WriteLine(city.CityName);
//}


//Country c1 = new Country() { CountryName = "England" };
//CountryDB countryDB = new CountryDB();
//countryDB.Insert(c1);
//int x = countryDB.SaveChanges();
//Console.WriteLine(x);


//City ct = new City() { CityName = "London", CountryCode = countryDB.SelectById(3) };
//CityDB db = new CityDB();
//db.Insert(ct);
//int c2 = db.SaveChanges();
//Console.WriteLine(c2);

//City c3 = new City();
//CityDB db2 = new CityDB();
//CityList lst = db2.SelectAll();
//c3 = lst[4];
//db2.Delete(c3);
//int c = db2.SaveChanges();
//Console.WriteLine(c);

//Country c3 = new Country();
//CountryDB db2 = new CountryDB();
//CountryList lst = db2.SelectAll();
//c3 = lst[2];
//db2.Delete(c3);
//int c = db2.SaveChanges();
//Console.WriteLine(c);

//City p = new City();
//CountryDB cr= new CountryDB();
//CityDB db = new CityDB();
//CityList lst = db.SelectAll();
//p = lst[2];
//p.CityName = "Nice";
//p.CountryCode = cr.SelectById(2) ;
//db.Update(p);
//int x=db.SaveChanges();
//Console.WriteLine(x);

//Country p = new Country();
//CountryDB db = new CountryDB();
//CountryList lst = db.SelectAll();
//p = lst[1];
//p.CountryName = "France";
//db.Update(p);
//int x = db.SaveChanges();
//Console.WriteLine(x);

CityDB cityDb = new CityDB();
//PlacesDB placesDB = new PlacesDB();
//City c = cityDb.SelectAll()[1];
//Places p1 = new Places() { Adress = "Park", CityCode = c };
//placesDB.Insert(p1);
//int x = placesDB.SaveChanges();
//Console.WriteLine(x);

//Places c3 = new Places();
//PlacesDB db2 = new PlacesDB();
//PlacesList lst = db2.SelectAll();
//c3 = lst.Last();
//db2.Delete(c3);
//int c = db2.SaveChanges();
//Console.WriteLine(c);

//Places p = new Places();
//CityDB cgt = new CityDB();
//PlacesDB db = new PlacesDB();
//PlacesList lst = db.SelectAll();
//p = lst.Last();
//p.Adress = "Nice";
//p.CityCode = cgt.SelectById(1);
//db.Update(p);
//int x = db.SaveChanges();
//Console.WriteLine(x);

//KosherRestaurant kr = new KosherRestaurant() { Telephone = "058401029", TypeOfFood = "halavi", Name = "shana", CityCode = cityDb.SelectById(3), Adress = "dorini12" };
//KosherRestaurantDB db = new KosherRestaurantDB();
//db.Insert(kr);
//int c2 = db.SaveChanges();
//Console.WriteLine(c2);

//KosherRestaurant c3;
//KosherRestaurantList lst = db.SelectAll();
//c3 = lst.Last();
////db.Delete(c3);
////int c = db.SaveChanges();
////Console.WriteLine(c);

//c3.Name = "orit";
//db.Update(c3);
//int x = db.SaveChanges();
//Console.WriteLine(x);

//BeitHabbad bt = new BeitHabbad() { Telephone = "057890", Adress = "sdfghjmk", Email = "werty", CityCode = cityDb.SelectById(3) };
//BeitHabbadDB db= new BeitHabbadDB();
//db.Insert(bt);
//int b = db.SaveChanges();
//Console.WriteLine(b);

//BeitHabbad b2;
//BeitHabbadList lst = db.SelectAll();
//b2 = lst.Last();
////b2.Email = "rtyu";
////db.Update(b2);
////int b = db.SaveChanges();
////Console.WriteLine(b);

//db.Delete(b2);
//int b = db.SaveChanges();
//Console.WriteLine(b);

//PopularPlace popularPlace = new PopularPlace() { Adress = "gfds", CityCode = cityDb.SelectById(7), Photo = "ertyu" };
//PopularPlacesDB db= new PopularPlacesDB();
//db.Insert(popularPlace);
//int x = db.SaveChanges();
//Console.WriteLine(x);

//PopularPlace pp;
//PopularPlacesList lst = db.SelectAll();
//pp = lst.Last();
////pp.Photo = "werr";
////db.Update(pp);
//int x = db.SaveChanges();
//Console.WriteLine(x);

//db.Delete(pp);
//int x = db.SaveChanges();
//Console.WriteLine(x);

//User c1 = new User() { Code = "23455", Name = "shana" };
//UserDB userDB = new UserDB();
//userDB.Insert(c1);
//int x = userDB.SaveChanges();
//Console.WriteLine(x);

//User user;
//UserList userList= userDB.SelectAll();
//user=userList.Last();
//user.Name = "orit";
//userDB.Update(user);
//int x = userDB.SaveChanges();
//Console.WriteLine(x);

//userDB.Delete(user);
//int x = userDB.SaveChanges();
//Console.WriteLine(x);

//Synagogue s = new Synagogue() { OpenHour = new TimeOnly(12, 00), CloseHour = new TimeOnly(16, 00), Adress = "werty", CityCode = cityDb.SelectById(7) };
//SynagogueDB synagogueDb = new SynagogueDB();
//synagogueDb.Insert(s);
//int r = synagogueDb.SaveChanges();
//Console.WriteLine(r);

//Synagogue se;
//SynagogueList slst = synagogueDb.SelectAll();
//se = slst.Last();
//se.OpenHour = new TimeOnly(13, 00, 00);
//synagogueDb.Update(se);
//int x = synagogueDb.SaveChanges();
//Console.WriteLine(x);

//synagogueDb.Delete(se);
//int x = synagogueDb.SaveChanges();
//Console.WriteLine(x);

//PopularPlacesDB pp=new PopularPlacesDB();
//Rating rating = new Rating() { IdPopularPlace=pp.SelectById(37),Rate=5 };
//RatingDB ratingDB = new RatingDB();
////ratingDB.Insert(rating);
////int r = ratingDB.SaveChanges();
////Console.WriteLine(r);

//Rating rt;
//RatingList rtList = ratingDB.SelectAll();
//rt = rtList.Last();
////rt.Rate = 6;
////ratingDB.Update(rt);
////int r = ratingDB.SaveChanges();
////Console.WriteLine(r);

//ratingDB.Delete(rt);
//int r = ratingDB.SaveChanges();
//Console.WriteLine(r);





