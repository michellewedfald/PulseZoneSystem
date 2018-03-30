using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseZoneSystem
{
    public interface ITypeOfPerson
    {
        string CalculatePulseZone(int pulse, string age);
    }
}
