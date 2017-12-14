using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSystem;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.ReadLine();
        }


        private void TestSearchByDate()
        {
            var trainsManager = new TrainsManager();

            var train1 = new Train(0, "dir1");
            var wagon1 = new Wagon();
            foreach (var seat in wagon1.Seats)
            {
                seat.Book(new Date(01, 01, 2000));
            }
            train1.AddWagon(wagon1);
            trainsManager.AddTrain(train1);

            var train2 = new Train(1, "dir1");
            var wagon2 = new Wagon();
            bool first = false;
            foreach (var seat in wagon2.Seats)
            {
                if (!first)
                {
                    first = true;
                    continue;
                }
                seat.Book(new Date(01, 01, 2000));
            }
            train2.AddWagon(wagon2);
            trainsManager.AddTrain(train2);

            //var suitableTrains = trainsManager.GetUnbookedTrains(new Date(01, 01, 2000));
            //foreach (var train in suitableTrains)
            //    Console.WriteLine(train.Id);
        }
    }
}
