using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseZoneSystem
{
    public class TypeOfPersonFactory
    {
        private ITypeOfPerson typeOfPerson;

        //opretter persontype ud fra hvad der indlæses fra konfigurationsfilen
        public ITypeOfPerson Create(string type)
        {
            if (type == "Normal")
            {
                Console.WriteLine();
                Console.WriteLine("NORMAL PERSON");
                Console.WriteLine();
                return typeOfPerson = new NormalPerson();
            }
            if (type == "Atlet")
            {
                Console.WriteLine();
                Console.WriteLine("ATLET");
                Console.WriteLine();
                return typeOfPerson = new Atlet();
            }
            throw new ArgumentException("Typen kendes ikke");
        }
    }
}
