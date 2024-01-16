using model;
using MyService;

namespace ConsoleApp1
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            MyApiService apiService = new MyApiService();
            CountryList countries = await apiService.SelectAllCountry();
            foreach(Country country in countries)
            {
                Console.WriteLine(country.CountryName);
            }
            Console.ReadLine();
            
        }
    }
}