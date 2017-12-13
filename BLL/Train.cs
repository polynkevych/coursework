using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem
{
    public class Train
    {
        public List<Wagon> Wagons = new List<Wagon>();

        public void AddWagon(Wagon wagon)
        {
            Wagons.Add(wagon);
        }

        public void DeleteWagon(Wagon wagon)
        {

        }

    }
}
