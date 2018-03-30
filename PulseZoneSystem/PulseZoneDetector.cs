using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PulseZoneSystem
{
    public class PulseZoneDetector
    {
        //opretter en kø-attribut, som tråden kan trække puls-værdier ud af i run-metoden
        private ConcurrentQueue<DataContainer> _dataQueue;

        private string _age;

        //opretter ITypeOfPerson så jeg kan bruge factory til at bestemme, hvilken type det skal være fra Main
        public ITypeOfPerson TypeOfPerson { get; set; }

        //constructor
        public PulseZoneDetector(ConcurrentQueue<DataContainer> dataQueue, ITypeOfPerson typeOfPerson, string age)
        {
            _dataQueue = dataQueue;
            _age = age;
            TypeOfPerson = typeOfPerson;
        }

        //trådens Run-metode
        public void ReadPulse()
        {
            while (true)
            {
                DataContainer container;
                while (!_dataQueue.TryDequeue(out container)) //trækker data ud af køen
                {
                    //10 s mellem hvert udtræk
                    Thread.Sleep(10000);
                }

                //sætter og udskriver puls-værdien
                int pulse = container.GetPulse();
                Console.WriteLine("Puls: " + pulse);
               

                //udregner pulszone-værdien
                string pulseZone = TypeOfPerson.CalculatePulseZone(pulse, _age);
                Console.WriteLine("Pulszone:" + pulseZone);
                Console.WriteLine();
            }
        }
    }
}
