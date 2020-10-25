using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace AprilAppConsole_5
{
    class Program
    {
        static void Main(string[] args)
        {
            ParsingClass product = new ParsingClass();

            Console.Write("Пожалуйста, вставьте ссылку на товар: ");
            product = product.GetProduct(Console.ReadLine());

            Console.WriteLine("\nВы выбрали:");
            Console.WriteLine($"Наименование товара: {product.name}\nПроизводитель: {product.manufacturer}\nЦена со скидкой: {product.discontPrice}\nЦена без скидки: {product.price}");

            AddClass.AddProduct(product);
            
            Console.ReadLine();
        }
    }
}
