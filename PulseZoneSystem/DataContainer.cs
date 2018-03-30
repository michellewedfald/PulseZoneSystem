using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseZoneSystem
{
    public class DataContainer
    {
        private int _pulse;

        public int GetPulse()
        {
            return _pulse;
        }

        public void SetPulse(int value)
        {
            _pulse = value;
        }
    }
}
