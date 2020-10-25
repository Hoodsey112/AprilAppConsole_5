using System;
using System.Data.Entity;
using System.Data.SQLite;

namespace AprilAppConsole_5
{
    class AddClass
    {
        public static void AddProduct(ParsingClass product)
        {
            try
            {
                using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=.\ProductParsingDB.db"))
                {
                    connect.Open();
                    string insertQuery = $"insert into Products (name, discontPrice, price, manufacturer) values ('{product.name}', {product.discontPrice}, {product.price}, '{product.manufacturer}')";
                    using (SQLiteCommand command = new SQLiteCommand(insertQuery, connect))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("\nЗапись успешно добавлена в базу");
            }
            catch(SQLiteException ex)
            {
                Console.WriteLine($"\nВо время добавления записи произошла ошибка.\n{ex.Message}");
            }
        }
    }
}
