using System;
using Npgsql;
using SipBiteUnite.Models;
using System.Text;
using Bogus;

namespace SipBiteUnite
{
    internal class Program
    {
        #region InsertData
        public static void InsertRandomDataIntoBeers(int numberOfRecords)
        {
            var faker = new Faker<Beer>()
                .RuleFor(b => b.Name, f => f.Commerce.ProductName())
                .RuleFor(b => b.Type, f => f.Commerce.ProductAdjective())
                .RuleFor(b => b.Producer, f => f.Company.CompanyName())
                .RuleFor(b => b.Description, f => f.Lorem.Sentence());

            using (NpgsqlConnection connection = new NpgsqlConnection("Host=127.0.0.1;Port=5432;Database=SipByteDatabase;Username=postgres;Password=admin"))
            {
                connection.Open();

                for (int i = 0; i < numberOfRecords; i++)
                {
                    var beer = faker.Generate();

                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "INSERT INTO beer (name, type, producer, description) VALUES (@name, @type, @producer, @description)";
                        cmd.Parameters.AddWithValue("@name", beer.Name);
                        cmd.Parameters.AddWithValue("@type", beer.Type);
                        cmd.Parameters.AddWithValue("@producer", beer.Producer);
                        cmd.Parameters.AddWithValue("@description", beer.Description);

                        cmd.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }
        public static void InsertRandomDataIntoFoods(int numberOfRecords)
        {
            var faker = new Faker<Food>()
                .RuleFor(f => f.Name, f => f.Commerce.ProductName())
                .RuleFor(f => f.Category, f => f.Commerce.Categories(1)[0])
                .RuleFor(f => f.Description, f => f.Lorem.Sentence());

            using (NpgsqlConnection connection = new NpgsqlConnection("Host=127.0.0.1;Port=5432;Database=SipByteDatabase;Username=postgres;Password=admin"))
            {
                connection.Open();

                for (int i = 0; i < numberOfRecords; i++)
                {
                    var food = faker.Generate();

                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "INSERT INTO food (name, category, description) VALUES (@name, @category, @description)";
                        cmd.Parameters.AddWithValue("@name", food.Name);
                        cmd.Parameters.AddWithValue("@category", food.Category);
                        cmd.Parameters.AddWithValue("@description", food.Description);

                        cmd.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }
        public static void InsertRandomDataIntoRatings(int numberOfRecords)
        {
            var faker = new Faker<Rating>()
                .RuleFor(r => r.IdBeer, f => f.Random.Number(1, 20)) 
                .RuleFor(r => r.IdFood, f => f.Random.Number(1, 20))
                .RuleFor(r => r.Rating1, f => f.Random.Number(100, 500) / 100f) 
                .RuleFor(r => r.IdUser, f => f.Random.Number(1, 20)); 

            using (NpgsqlConnection connection = new NpgsqlConnection("Host=127.0.0.1;Port=5432;Database=SipByteDatabase;Username=postgres;Password=admin"))
            {
                connection.Open();

                for (int i = 0; i < numberOfRecords; i++)
                {
                    var rating = faker.Generate();

                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "INSERT INTO rating (id_beer, id_food, rating, id_user) VALUES (@idBeer, @idFood, @rating, @idUser)";
                        cmd.Parameters.AddWithValue("@idBeer", rating.IdBeer);
                        cmd.Parameters.AddWithValue("@idFood", rating.IdFood);
                        cmd.Parameters.AddWithValue("@rating", rating.Rating1);
                        cmd.Parameters.AddWithValue("@idUser", rating.IdUser);

                        cmd.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }
        public static void InsertRandomDataIntoUsers(int numberOfRecords)
        {
            var faker = new Faker<User>()
                .RuleFor(u => u.IsLogined, f => f.Random.Bool())
                .RuleFor(u => u.Name, f => f.Name.FullName())
                .RuleFor(u => u.Login, f => f.Internet.UserName())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.Email, f => f.Internet.Email());

            using (NpgsqlConnection connection = new NpgsqlConnection("Host=127.0.0.1;Port=5432;Database=SipByteDatabase;Username=postgres;Password=admin"))
            {
                connection.Open();

                for (int i = 0; i < numberOfRecords; i++)
                {
                    var user = faker.Generate();

                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "INSERT INTO \"User\" (is_logined, name, login, password, email) VALUES (@isLogined, @name, @login, @password, @email)";
                        cmd.Parameters.AddWithValue("@isLogined", user.IsLogined);
                        cmd.Parameters.AddWithValue("@name", user.Name);
                        cmd.Parameters.AddWithValue("@login", user.Login);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        cmd.Parameters.AddWithValue("@email", user.Email);

                        cmd.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }
        public static void InsertRandomDataIntoShopssum(int numberOfRecords)
        {
            var shopIds = GetShopIdsFromDatabase(); 
            var BeerId = GetBeerIdsFromDatabase(); 

            var faker = new Faker<Shopssum>()
                .RuleFor(s => s.ShopId, f => f.PickRandom(shopIds))
                .RuleFor(s => s.BeerId, f => f.PickRandom(BeerId))
                .RuleFor(s => s.Price, f => f.Random.Decimal(1, 1000))
                .RuleFor(s => s.Url, f => f.Internet.Url());

            using (NpgsqlConnection connection = new NpgsqlConnection("Host=127.0.0.1;Port=5432;Database=SipByteDatabase;Username=postgres;Password=admin"))
            {
                connection.Open();

                for (int i = 0; i < numberOfRecords; i++)
                {
                    var shopssum = faker.Generate();

                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "INSERT INTO shopssum (shop_id, beer_id, price, url) VALUES (@shopId, @beerId, @price, @url)";
                        cmd.Parameters.AddWithValue("@shopId", shopssum.ShopId);
                        cmd.Parameters.AddWithValue("@beerId", shopssum.BeerId);
                        cmd.Parameters.AddWithValue("@price", shopssum.Price);
                        cmd.Parameters.AddWithValue("@url", shopssum.Url);

                        cmd.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }
        private static List<int> GetShopIdsFromDatabase()
        {
            List<int> shopIds = new List<int>();

            using (NpgsqlConnection connection = new NpgsqlConnection("Host=127.0.0.1;Port=5432;Database=SipByteDatabase;Username=postgres;Password=admin"))
            {
                connection.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT id FROM shops", connection))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            shopIds.Add(reader.GetInt32(0));
                        }
                    }
                }

                connection.Close();
            }

            return shopIds;
        }
        private static List<int> GetBeerIdsFromDatabase()
        {
            List<int> BeerId = new List<int>();

            using (NpgsqlConnection connection = new NpgsqlConnection("Host=127.0.0.1;Port=5432;Database=SipByteDatabase;Username=postgres;Password=admin"))
            {
                connection.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT id FROM beer", connection))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BeerId.Add(reader.GetInt32(0));
                        }
                    }
                }

                connection.Close();
            }

            return BeerId;
        }
        public static void InsertRandomDataIntoShops(int numberOfRecords)
        {
            var faker = new Faker<Shop>()
                .RuleFor(s => s.Name, f => f.Company.CompanyName());

            using (NpgsqlConnection connection = new NpgsqlConnection("Host=127.0.0.1;Port=5432;Database=SipByteDatabase;Username=postgres;Password=admin"))
            {
                connection.Open();

                for (int i = 0; i < numberOfRecords; i++)
                {
                    var shop = faker.Generate();

                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "INSERT INTO shops (name) VALUES (@name)";
                        cmd.Parameters.AddWithValue("@name", shop.Name);

                        cmd.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }
        #endregion
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            //InsertRandomDataIntoBeers(30);
            //InsertRandomDataIntoFoods(30);
            //InsertRandomDataIntoUsers(40);
            //InsertRandomDataIntoRatings(40);
            //InsertRandomDataIntoShops(30);
            //InsertRandomDataIntoShopssum(30);

            using (var context = new SipByteDatabaseContext())
            {
                var beers = context.Beers.ToList();
                Console.WriteLine("Дані з таблиці Beer:");
                foreach (var beer in beers)
                {
                    Console.WriteLine($"ID: {beer.Id}, Name: {beer.Name}, Type: {beer.Type}, Producer: {beer.Producer}, Description: {beer.Description}");
                }

                var foods = context.Foods.ToList();
                Console.WriteLine("\nДані з таблиці Food:");
                foreach (var food in foods)
                {
                    Console.WriteLine($"ID: {food.Id}, Name: {food.Name}, Category: {food.Category}, Description: {food.Description}");
                }

                var ratings = context.Ratings.ToList();
                Console.WriteLine("\nДані з таблиці Ratings:");
                foreach (var rating in ratings)
                {
                    Console.WriteLine($"ID: {rating.Id}, ID Beer: {rating.IdBeer}, ID Food: {rating.IdFood}, Rating: {rating.Rating1}, ID User: {rating.IdUser}");
                }

                var shops = context.Shops.ToList();
                Console.WriteLine("\nДані з таблиці Shops:");
                foreach (var shop in shops)
                {
                    Console.WriteLine($"ID: {shop.Id}, Name: {shop.Name}");
                }

                var shopssums = context.Shopssums.ToList();
                Console.WriteLine("\nДані з таблиці Shopssums:");
                foreach (var shopssum in shopssums)
                {
                    Console.WriteLine($"Shop ID: {shopssum.ShopId}, Beer ID: {shopssum.BeerId}, Price: {shopssum.Price}, URL: {shopssum.Url}");
                }

                var users = context.Users.ToList();
                Console.WriteLine("\nДані з таблиці Users:");
                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}, Is Logined: {user.IsLogined}, Login: {user.Login}, Password: {user.Password}");
                }
            }

            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
