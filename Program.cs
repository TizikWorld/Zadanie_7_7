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

            devhome.Address = "Тверская улица, 3, Москва, 125009";

            Product cake = new Product("Торт", 850, 500);

            int nummenu=0;
            StartDev.Start();
           
            do
            {
                Console.WriteLine("Ответ дайте числом");                                
            } while (!int.TryParse(Console.ReadLine(), out nummenu)|| checkData.CheckNum(nummenu));

            switch (nummenu)
            {
                case 1:
                    WriteLine("Выбрана доставка на дом");
                    devhome.CorrectAdressToHome(cake);
                    break;
                case 2:
                    WriteLine("Выбрана доставка с помощью пункта выдачи");
                    PickPointDelivery pickdelivery = new PickPointDelivery();
                    pickdelivery.Address = "Москва, ТЦ Аврора";
                    pickdelivery.InfoDel();
                    break;
                case 3:
                    WriteLine("Выбрана доставка из магазина");
                    ShopDelivery shopDelivery = new ShopDelivery();
                    shopDelivery.Shop();                    
                    break;              
            }       
        }

        static class StartDev
        {
            static public void Start()
            {
                WriteLine($"Здравствуйте, это служба доставки. Какой способ доставки вы хотите использовать?" +
                $"\n1. Доставка на дом\n2. Пункт выдачи\n3. Самовывоз из магазина\n");
            }
        }

        class CheckData
        {
            public bool CheckNum(int age)
            {
                bool check;

                if (age > 0 & age < 4)
                    return check = false;
                else
                {
                    Console.WriteLine("Число должно быть от 1 до 3");
                    return check = true;
                }
            }
        }
        abstract class Delivery
        {
            public string Address;

            //public abstract void Send();

            public virtual void InfoDel()
            {
                Console.WriteLine($"Адрес доставки выбран: {Address}\n");
            }


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

            public override void InfoDel()
            {
                Console.WriteLine($"Адрес пункта выдачи: {Address}");
            }

            /* ... */
        }

        private class ShopDelivery : Delivery
        {
            /* ... */
            private protected string AdrShop = "Москва, Краснопресненская 19" ;
            private protected int phone = 585858;
        public void Shop()
            {
                WriteLine($"Адрес магазина: {AdrShop} , номер телефона {phone}");
            }                         
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
