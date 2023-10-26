using System; 
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Drink> drinks = new List<Drink>();
            List<OrderItem> orders = new List<OrderItem>();

            //新增飲料品項
            AddNewDrink(drinks);

            //列出所有飲料品項
            DisplayDrinkMenu(drinks);

            //訂購飲料
            OrderDrink(drinks, orders);

            //計算售價
            CalculateAmount(orders);

        }

        private static void CalculateAmount(List<OrderItem> myOrders)
        {
            double total = 0.0;
            string message = "";
            double sellPrice = 0.0;

            Console.WriteLine("-------------------------------------------------------");
            foreach(OrderItem orderItem in myOrders) total += orderItem.Subtotal;

            if (total >= 500)
            {
                message = "訂購滿500元以上者8折";
                sellPrice = total * 0.8;
            }
            else if (total >= 300)
            {
                message = "訂購滿300元以上者85折";
                sellPrice = total * 0.85;
            }
            else if (total >= 200)
            {
                message = "訂購滿200元以上者9折";
                sellPrice = total * 0.9;
            }
            else
            {
                message = "訂購未滿200元不打折";
                sellPrice = total;
            }

            Console.WriteLine($"您總共訂購{myOrders.Count}項飲料，總計{total}元。{message}，總計需付款{sellPrice}元。");
            Console.WriteLine("-------------------------------------------------------");
        }

        private static void OrderDrink(List<Drink> myDrinks, List<OrderItem> myOrders)
        {
            Console.WriteLine();
            Console.WriteLine("請開始訂購飲料，按下x鍵，並按下Enter鍵結束訂單。");
            string s;
            int index, quantity, subtotal;
            while (true)
            {
                
                Console.Write("請輸入品名編號？ ");
                s = Console.ReadLine();
                if (s == "x")
                {
                 
                    Console.WriteLine("謝謝惠顧，歡迎下次再來。");
                    break;
                }
                
                else index = Convert.ToInt32(s);
                
                  if (index <= -1 || index >= 6)
                    {
                        Console.WriteLine("沒有這個編號，請輸入目前已出現的編號");
                        continue;
                    }
                
                Drink drink = myDrinks[index];

                Console.Write("請輸入數量？ ");
                s = Console.ReadLine();
                if (s == "x")
                {

                    Console.WriteLine("謝謝惠顧，歡迎下次再來。");
                    break;
                }
                else quantity = Convert.ToInt32(s);

                
                subtotal = drink.Price * quantity;

                Console.WriteLine($"您訂購{drink.Name}{drink.Size}{quantity}杯，每杯{drink.Price}元，小計{subtotal}元");
                myOrders.Add(new OrderItem() { Index = index, Quantity = quantity, Subtotal = subtotal });
            }
        }

        private static void DisplayDrinkMenu(List<Drink> myDrinks)
        {
            //列出所有飲料品項
            //for (int i=0; i< drinks.Count; i++)
            //{
            //    Console.WriteLine($"{drinks[i].Name} {drinks[i].Size} {drinks[i].Price}");
            //}
            Console.WriteLine("飲料清單\n");
            Console.WriteLine(String.Format("{0,-5}{1,-5}{2,5}{3,7}","編號","品名","大中","價格"));
            int i = 0;
            foreach (Drink drink in myDrinks)
            {
                Console.WriteLine($"{i,-7}{drink.Name,-8}{drink.Size,-3}{drink.Price,9:C1}");
                i++;
            }
        }

        private static void AddNewDrink(List<Drink> myDrinks)
        {
            //新增飲料品項
            //Drink drink1 = new Drink() { Name = "紅茶", Size = "大杯", Price = 30 };
            //drinks.Add(drink1);
            myDrinks.Add(new Drink() { Name = "紅茶", Size = "大杯", Price = 30 });
            myDrinks.Add(new Drink() { Name = "紅茶", Size = "中杯", Price = 20 });
            myDrinks.Add(new Drink() { Name = "綠茶", Size = "大杯", Price = 25 });
            myDrinks.Add(new Drink() { Name = "綠茶", Size = "中杯", Price = 20 });
            myDrinks.Add(new Drink() { Name = "咖啡", Size = "大杯", Price = 60 });
            myDrinks.Add(new Drink() { Name = "咖啡", Size = "中杯", Price = 50 });
        }
    }
}
