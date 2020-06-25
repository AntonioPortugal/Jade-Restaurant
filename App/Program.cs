using DataAccess.Contexts;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new RestaurantContext();
            database.Database.EnsureCreated();

        }

    }

}
