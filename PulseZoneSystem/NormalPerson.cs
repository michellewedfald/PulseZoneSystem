using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseZoneSystem
{
    public class NormalPerson: ITypeOfPerson
    {
        private string _message;
        
        //puls sendes med fra metode-kaldet i PulseZoneDetector-klassens ReadPulse()-metode
        //age sendes med fra konfigurationsfilen

        //sætter maxpuls = 220 og trækker den indlæste alder fra

        public string CalculatePulseZone(int pulse, string age)
        {
            if (pulse <= (220 - Convert.ToInt32(age)) * 0.6)
            {
                _message = " Meget let belastning";
            }
            if (pulse > (220 - Convert.ToInt32(age)) * 0.6 && pulse <= (220 - Convert.ToInt32(age)) * 0.7)
            {
                _message = " Let belastning";
            }
            if (pulse > (220 - Convert.ToInt32(age)) * 0.7 && pulse <= (220 - Convert.ToInt32(age)) * 0.8)
            {
                _message = " Moderat belastning";
            }
            if (pulse > (220 - Convert.ToInt32(age)) * 0.8 && pulse <= (220 - Convert.ToInt32(age)) * 0.9)
            {
                _message = " Hård belastning";
            }
            if (pulse > (220 - Convert.ToInt32(age)) * 0.9)
            {
                _message = " Maksimal belastning";
            }
            return _message;
        }
    }
}
