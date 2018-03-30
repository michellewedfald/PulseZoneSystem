using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PulseZoneSystem
{
    public class PulseGenerator
    {
        
        //Kø som GeneratePulse skal lægge puls overi

        private readonly ConcurrentQueue<DataContainer> _dataQueue;

        //opretter en random
        private Random _rnd = new Random();

        //constructor
        public PulseGenerator(ConcurrentQueue<DataContainer> dataQueue)
        {
            _dataQueue = dataQueue;
        }

        //Run-metoden for tråden
        public void GeneratePulse()
        {
            while (true)
            {
                //tryk sættes til en random-værdi mellem 20 og 40
                int pulse = _rnd.Next(55, 221);
                DataContainer reading = new DataContainer();
                reading.SetPulse(pulse);
                _dataQueue.Enqueue(reading);
                Thread.Sleep(10000); //10 s mellem hver puls bliver lagt i tråden
            }
        }

    }
}
