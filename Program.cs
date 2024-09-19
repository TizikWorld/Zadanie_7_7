using System;
using System.Runtime.InteropServices;
using static System.Console;
using static System.Net.Mime.MediaTypeNames;

namespace Zadanie_7_7
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            HomeDelivery devhome = new HomeDelivery();

            CheckData checkData = new CheckData();

            int nummenu;

            WriteLine($"Здравствуйте, это служба доставки FastDev. Какой способ доставки вы хотите использовать?" +
                $"\n1. Доставка на дом\n2. Пункт выдачи\n3. Самовывоз из магазина\n");

            do
            {
                Console.WriteLine("Ответ дайте цифрой");

                if (int.TryParse(Console.ReadLine(), out nummenu))
                {
                    Console.WriteLine("Вы ввели число {0}", nummenu);
                    break;
                }
            } while (checkData.CheckNum(nummenu));


            switch (nummenu)


            devhome.Address = "Тверская улица, 3, Москва, 125009";

            Product cake = new Product("Торт", 850, 500);

            devhome.CorrectAdressToHome(cake);



        }


        class CheckData
        {
            public bool CheckNum(int age)
            {
                bool check;

                if (age > 0 & age < 4)
                    return check = false;
                else return check = true;
            }
        }
        abstract class Delivery
        {
            public string Address;

            public void Confirmation()
            {
                Console.WriteLine("Введите Да для подтверждения\n");
                string temp = Console.ReadLine();
                if (temp == "Да" || temp == "да")
                    Console.WriteLine("Заказ подтвержден, ожидайте доставки");
                else
                    Console.WriteLine("Заказ отменен");
            }
        }

        class HomeDelivery : Delivery
        {
            //string adress;

            public void CorrectAdressToHome(Product Delivery)
            {
                Console.WriteLine($"Подтвердите введенный адрес {Address} для доставки на дом следующего" +
                    $" товара:\n{Delivery.Name} \nВес {Delivery.Weight} г \nЦена {Delivery.Price} Руб. \n");
                Confirmation();
            }
            
            /*
            public override void Confirmation()
            {
                this.Confirmation();
                Console.WriteLine("Заказ будет доставлен до двери");
            }
            */
                /* ... */
            }

        class PickPointDelivery : Delivery
        {
            /* ... */
        }

        class ShopDelivery : Delivery
        {
            /* ... */
        }

        class Product
        {
            //public TProd prod;

            public string Name { get; }
            public int Weight { get; }
            public float Price { get; }

            public Product(string name, int weight, float price){
                
                Name = name; Weight = weight; Price = price;
                
                }

            
        }

        class Order<TDelivery,TStruct> where TDelivery : Delivery
        {
            public TDelivery Delivery;

            public int Number;


            public string Description;

            public void DisplayAddress()
            {
                Console.WriteLine(Delivery.Address);
            }

            // ... Другие поля
        }




    }
}
