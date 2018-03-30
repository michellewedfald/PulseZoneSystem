using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PulseZoneSystem;

namespace Unit.Test.PulseZoneSystem
{
    [TestFixture]
    public class TestPulsZoneAtlet
    {
        private Atlet uut;

        [SetUp]
        public void SetUp()
        {
            uut = new Atlet();
        }

        //Alder er sat lig 0 og derfor er maxpuls 220. Grænseværdierne er fundet ud fra denne maxpuls, og disse grænseværdier er testet. 
        //Alle andre værdier er partitions-ækvivalenser
        [Test]
        public void DetectPulseZone_Pulse55_ReturnsMegetLet()
        {
            int pulse = 55;

            string result = uut.CalculatePulseZone(pulse, "0");

            Assert.That(result, Is.EqualTo(" Meget let belastning"));
        }

        [Test]
        public void DetectPulseZone_Pulse154_ReturnsMegetLet()
        {
            int pulse = 154;

            string result = uut.CalculatePulseZone(pulse, "0");

            Assert.That(result, Is.EqualTo(" Meget let belastning"));
        }


        [Test]
        public void DetectPulseZone_Pulse155_ReturnsLet()
        {
            int pulse = 155;

            string result = uut.CalculatePulseZone(pulse, "0");

            Assert.That(result, Is.EqualTo(" Let belastning"));
        }

        [Test]
        public void DetectPulseZone_Pulse176_ReturnsLet()
        {
            int pulse = 176;

            string result = uut.CalculatePulseZone(pulse, "0");

            Assert.That(result, Is.EqualTo(" Let belastning"));
        }
        [Test]
        public void DetectPulseZone_Pulse177_ReturnsModerat()
        {
            int pulse = 177;

            string result = uut.CalculatePulseZone(pulse, "0");

            Assert.That(result, Is.EqualTo(" Moderat belastning"));
        }
        [Test]
        public void DetectPulseZone_Pulse198_ReturnsModerat()
        {
            int pulse = 198;

            string result = uut.CalculatePulseZone(pulse, "0");

            Assert.That(result, Is.EqualTo(" Moderat belastning"));
        }
        [Test]
        public void DetectPulseZone_Pulse199_ReturnsHård()
        {
            int pulse = 199;

            string result = uut.CalculatePulseZone(pulse, "0");

            Assert.That(result, Is.EqualTo(" Hård belastning"));
        }
        [Test]
        public void DetectPulseZone_Pulse209_ReturnsHård()
        {
            int pulse = 209;

            string result = uut.CalculatePulseZone(pulse, "0");

            Assert.That(result, Is.EqualTo(" Hård belastning"));
        }
        [Test]
        public void DetectPulseZone_Pulse210_ReturnsMaksimal()
        {
            int pulse = 210;

            string result = uut.CalculatePulseZone(pulse, "0");

            Assert.That(result, Is.EqualTo(" Maksimal belastning"));
        }
        [Test]
        public void DetectPulseZone_Pulse220_ReturnsMaksimal()
        {
            int pulse = 220;

            string result = uut.CalculatePulseZone(pulse, "0");

            Assert.That(result, Is.EqualTo(" Maksimal belastning"));
        }

    }
}
