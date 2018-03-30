using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PulseZoneSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Configuration

            //opretter sti
            var path = Directory.CreateDirectory(@"C:\Users\MichelleWedfald\Desktop\ST3ITS2-172-201607371-MichelleWedfaldNielsen\PulseZoneSystem\PulseZoneSystem\bin");
            var currentDirectory = Directory.GetCurrentDirectory();

            //opretter et configurations-objekt
            Configuration configuration = new Configuration();

            //DET HER ER FOR AT KREERE DEN FØRSTE FIL
            //configuration.Name = "Lars Larsen";
            //configuration.Age = "40";
            //configuration.typeOfPerson = "Normal";
            //string configpath0 = Path.Combine(path.FullName, "Configuration.xml");
            //XMLPerson.Save(configuration, configpath0);


            //henter startup-info fra xml-fil
            try
            {
                string configpath = Path.Combine(currentDirectory, "Configuration.xml");
                configuration = XMLPerson.Load(configpath);
                Console.WriteLine("Navn: " + configuration.Name + "\n" + "Age: " + configuration.Age);
            }
            //hvis det ikke lykkedes, gemmes en fil med fejl x 3, som herefter loades og vises hvorefter consollen lukkes
            catch (Exception e)
            {
                configuration.Name = "Fejl";
                configuration.Age = "Fejl";
                configuration.typeOfPerson = "Fejl";
                string configpath2 = Path.Combine(currentDirectory, "default.configuration.xml");
                XMLPerson.Save(configuration, configpath2);
                configuration = XMLPerson.Load(configpath2);
                Console.WriteLine(e);
                throw;
            }

            //sætter attributter til det indlæste fra filen
            var name = configuration.Name;
            var age = configuration.Age;
            var type = configuration.typeOfPerson;



            //opretter objekter
            ConcurrentQueue<DataContainer> queue = new ConcurrentQueue<DataContainer>();

            PulseGenerator pulseGenerator = new PulseGenerator(queue);

            TypeOfPersonFactory factory = new TypeOfPersonFactory();

            //sender kø, configurationstypen som via factory skaber en type samt alder
            PulseZoneDetector pulseZoneDetector = new PulseZoneDetector(queue, factory.Create(type), age);

            
            //opretter tråde og starter dem
            Thread generatorThread = new Thread(pulseGenerator.GeneratePulse);
            Thread detectorThread = new Thread(pulseZoneDetector.ReadPulse);

            generatorThread.Start();
            detectorThread.Start();

        }
    }
}
