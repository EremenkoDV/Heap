using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Stopwatch();

            //Heap<int> heap = new Heap<int>(true);
            //Heap<string> heap = new Heap<string>();
            //List<string> list = new List<string>();

            //list.Add("05");
            //list.Add("03");
            //list.Add("08");
            //list.Add("06");
            //list.Add("01");
            //list.Add("10");
            //list.Add("21");
            //list.Add("11");
            //list.Add("16");
            //list.Add("09");
            //list.Add("02");
            //list.Add("04");
            //list.Add("07");
            var rnd = new Random();
            List<int> list = new List<int>();
            for (int i = 0; i < 50; i++)
                list.Add(rnd.Next(-1000, 1000));

            timer.Start();
            Heap<int> heap = new Heap<int>(list);
            timer.Stop();
            string timer1 = timer.Elapsed.ToString();

            int j = 0;
            int beforeItem = heap.Top;
            foreach (int item in heap)
            {
                Console.WriteLine("item[" + String.Format("{0,3}", j++) + "]=" + String.Format("{0,6}", item) + " : " + (beforeItem >= item));
                beforeItem = item;
            }

            Console.WriteLine("--------------------------");
            timer.Restart();
            //Heap<int> heap = new Heap<int>();
            //heap = new Heap<int>();
            for (int i = 0; i < 50; i++)
                heap.Add(rnd.Next(-1000, 1000));
            timer.Stop();
            string timer2 = timer.Elapsed.ToString();
            //heap.Add(100);
            //heap.Add(500);
            //heap.Add(200);
            //heap.Add(700);
            //heap.Add(300);
            //heap.Add(400);
            //heap.Add(800);
            //heap.Add(900);
            //heap.Add(600);
            //heap.Add("Привет");
            //heap.Add("Здорова");
            //heap.Add("Hi");
            //heap.Add("Hello");
            //heap.Add("Salute");
            //heap.Add("Saludo");
            //heap.Add("Здравствуйте");
            //heap.Add("Ciao");
            //heap.Add("Bonjour");
            //heap.Add("Hallo");
            //heap.Add("안녕");
            //heap.Add("¡Hola!");

            //bool result1 = heap.Remove(300);
            //bool result2 = heap.Remove(200);
            //bool result3 = heap.Remove(500);

            timer.Restart();
            j = 0;
            beforeItem = heap.Top;
            foreach (int item in heap)
            {
                Console.WriteLine("item[" + String.Format("{0,3}", j++) + "]=" + String.Format("{0,6}", item) + " : " + (beforeItem >= item));
                beforeItem = item;
            }
            timer.Stop();
            string timer3 = timer.Elapsed.ToString();
            Console.WriteLine("timer1 : " + timer1);
            Console.WriteLine("timer2 : " + timer2);
            Console.WriteLine("timer3 : " + timer3);
        }
    }
}
